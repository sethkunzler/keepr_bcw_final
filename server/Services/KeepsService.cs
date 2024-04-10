namespace keepr_bcw_final.Services;

public class KeepsService
{
  private readonly KeepsRepository _repository;
  private readonly VaultsService _vaultsService;

  public KeepsService(KeepsRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _repository.Create(keepData);
    return keep;
  }

  internal List<Keep> GetKeeps()
  {
    List<Keep> keeps = _repository.GetAll();
    return keeps;
  }

  internal Keep GetKeepById(int keepId)
  {
    Keep keep = _repository.GetById(keepId);
    if (keep == null) throw new Exception($"Invalid Keep Id: {keepId}");
    return keep;
  }

  internal List<KeptKeep> GetKeepsByVaultId(int vaultId, string userId)
  {
    _vaultsService.GetVaultById(vaultId, userId);
    
    List<KeptKeep> keeps = _repository.GetKeepsByVaultId(vaultId);
    return keeps;
  }

  internal List<Keep> GetKeepsByProfileId( string profileId)
  {
    List<Keep> keeps = _repository.GetAllKeepsByProfileId(profileId);
    return keeps;
  }

  internal Keep UpdateKeep(int keepId, Keep keepData, string userId)
  {
    Keep keepUpdate = GetKeepById(keepId);
    
    if (keepUpdate.CreatorId != userId) throw new Exception("You are not the Creator of this Keep, access to edit is restricted to the Creator only");
    
    keepUpdate.Name = keepData.Name ?? keepUpdate.Name;
    keepUpdate.Description = keepData.Description ?? keepUpdate.Description;

    Keep keep = _repository.Update(keepUpdate);  
    return keep;
  }

  internal string DeleteKeep(int keepId, string userId)
  {
    Keep foundKeep = GetKeepById(keepId);
    if (foundKeep.CreatorId != userId) throw new Exception("You are not the Creator of this Keep. Access to delete is restricted to the Creator only");

    _repository.Destroy(keepId);

    return $"{foundKeep.Name} has been deleted";
  }

}