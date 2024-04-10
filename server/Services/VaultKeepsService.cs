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
    KeptKeep vaultKeep = _repository.CreateKeptKeep(vaultKeepData);
    return vaultKeep;
  }
}