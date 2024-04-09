


namespace keepr_bcw_final.Services;

public class VaultsService
{
  private readonly VaultsRepository _repository;

  public VaultsService(VaultsRepository repository)
  {
    _repository = repository;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _repository.Create(vaultData);
    return vault;
  }

  internal List<Vault> GetVaultsByProfileId(string userId, string profileId)
  {
    List<Vault> vaults = _repository.GetAllVaultsByProfileId(profileId);

    vaults = vaults.FindAll(vault => vault.isPrivate == false || vault.CreatorId == userId);

    return vaults;
  }

  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault vault = _repository.GetById(vaultId);

    if (vault == null) throw new Exception($"Invalid id: {vaultId}");

    if (vault.isPrivate == true && userId != vault.CreatorId)
    {
      throw new Exception($"Invalid Vault ID: {vaultId} 😉🤚❌ This Vault is Private! Access to view is restricted to the creator.");
    }

    return vault;
  }

  
}