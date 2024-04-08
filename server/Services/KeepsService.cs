
namespace keepr_bcw_final.Services;

public class KeepsService
{
  private readonly KeepsRepository _repository;

  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
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
    if (keep == null) throw new Exception($"Invalid Id: {keepId}");
    return keep;
  }

  internal Keep UpdateKeep(int keepId, Keep keepData, string userId)
  {
    Keep keepUpdate = GetKeepById(keepId);
    
    if (keepUpdate.CreatorId != userId) throw new Exception("You are not the Creator, access to edit is restricted to the Creator Only");
    
    keepUpdate.Name = keepData.Name ?? keepUpdate.Name;
    keepUpdate.Description = keepData.Description ?? keepUpdate.Description;

    Keep keep = _repository.Update(keepUpdate);  
    return keep;
  }
}