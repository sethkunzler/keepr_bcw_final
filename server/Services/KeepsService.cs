using Microsoft.AspNetCore.Identity;

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

  internal Keep ViewKeep(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId == userId) return keep; // If the creator sees their own keep, we don't want the view count to go up, I only want to know how many other people saw it. 
    keep.Views++;
    Keep keepViewed = _repository.Update(keep);
    return keepViewed;
  }

  // Writing this made me cry😭 - the A is there to KEEP me sane!!
  internal Keep KeepAKeep(int keepId)
  {
    Keep keep = GetKeepById(keepId);
    keep.Kept++;
    Keep keepKept = _repository.Update(keep);
    return keepKept;
  }
  internal Keep UnKeepAKeep(int keepId)
  {
    Keep keep = GetKeepById(keepId);
    keep.Kept--;
    Keep keepUnKept = _repository.Update(keep);
    return keepUnKept;
  }
  
  internal string DeleteKeep(int keepId, string userId)
  {
    Keep foundKeep = GetKeepById(keepId);
    if (foundKeep.CreatorId != userId) throw new Exception("You are not the Creator of this Keep. Access to delete is restricted to the Creator only");

    _repository.Destroy(keepId);

    return $"{foundKeep.Name} has been deleted";
  }

}