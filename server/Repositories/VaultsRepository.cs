
namespace keepr_bcw_final.Repositories;

public class VaultsRepository : IRepo<Vault>
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Vault Create(Vault data)
  {
    throw new NotImplementedException();
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Vault> GetAll()
  {
    throw new NotImplementedException();
  }

  public Vault GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Vault Update(Vault data)
  {
    throw new NotImplementedException();
  }
}