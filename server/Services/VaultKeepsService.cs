namespace keepr_bcw_final.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repository;
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;

  public VaultKeepsService(VaultKeepsRepository repository, VaultsService vaultsService, KeepsService keepsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
    _keepsService = keepsService;
  }

    internal KeptKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
  {
    // TODO ensure the vault belongs to the logged in user
    int vaultId = vaultKeepData.VaultId;
    Vault vaultToAddTo = _vaultsService.GetVaultById(vaultId, userId);
    if (vaultToAddTo.CreatorId != userId) 
    {
      throw new Exception("You are not the creator of this Vault! access to add keeps to vaults is restricted to the creator only.");
    }
    
    int keepId = vaultKeepData.KeepId;
    _keepsService.KeepAKeep(keepId);

    KeptKeep vaultKeep = _repository.CreateKeptKeep(vaultKeepData);
    return vaultKeep;
  }

  internal void DeleteVaultKeep(int vaultKeepId, string userId)
  {
    KeptKeep keepToRemove = GetKeptKeepById(vaultKeepId);
    
    if (keepToRemove.CreatorId != userId)
    {
      throw new Exception("You are not the Creator of this Vault. Access to remove keeps is restricted to the Creator only");
    }
    int keepId = keepToRemove.KeepId;
    _keepsService.UnKeepAKeep(keepId);

    _repository.Destroy(vaultKeepId);
  }

  internal KeptKeep GetKeptKeepById(int vaultKeepId)
  {
    KeptKeep keptKeep = _repository.GetKeptKeepById(vaultKeepId);

    if (keptKeep == null)
    {
      throw new Exception($"Invalid Kept Keep id: {vaultKeepId}");
    }

    return keptKeep;
  }
}