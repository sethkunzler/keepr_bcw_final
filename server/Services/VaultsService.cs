


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

  internal Vault UpdateVault(int vaultId, Vault vaultData, string userId)
  {
    Vault updateVault = GetVaultById(vaultId, userId);
    if (updateVault.CreatorId != userId) throw new Exception("You are not the Creator of this Vault! access too edit is restricted to the Creator only");

    updateVault.Name = vaultData.Name ?? updateVault.Name;
    updateVault.Description = vaultData.Description ?? updateVault.Description;
    updateVault.isPrivate = vaultData.isPrivate ?? updateVault.isPrivate;

    Vault vault = _repository.Update(updateVault);
    return vault;
  }

  internal string DeleteVault(int vaultId, string userId)
  {
    Vault foundVault = GetVaultById(vaultId, userId);
    if (foundVault.CreatorId != userId) throw new Exception("You are not the Creator of this Vault. Access to delete is restricted to the Creator only");

    _repository.Destroy(vaultId);

    return $"{foundVault.Name} has been deleted";
  }
}