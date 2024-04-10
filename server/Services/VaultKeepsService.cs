namespace keepr_bcw_final.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repository;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }

  internal KeptKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    // TODO ensure the vault belongs to the logged in user

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