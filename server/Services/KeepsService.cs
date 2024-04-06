
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

  internal Keep GetKeepsById(int keepId)
  {
    Keep keep = _repository.GetById(keepId);
    if (keep == null) throw new Exception($"Invalid Id: {keepId}");
    return keep;
  }
}