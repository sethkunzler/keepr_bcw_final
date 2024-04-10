
namespace keepr_bcw_final.Repositories;

public class VaultKeepsRepository : IRepo<VaultKeep>
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  public VaultKeep Create(VaultKeep data)
  {
    throw new NotImplementedException();
  }
  public KeptKeep CreateKeptKeep(VaultKeep vaultKeepData)
  {
    // REVIEW 🤨 I don't know about this...
    string sql = @"
    INSERT INTO 
    vaultKeeps(creatorId, vaultId, keepId)
    VALUES(@creatorId, @vaultId, @keepId);

    SELECT 
    vaultKeep.*,
    keep.*,
    account.*
    FROM vaultKeeps vaultKeep
    JOIN keeps keep ON keep.id = vaultKeep.keepId
    JOIN accounts account ON account.id = keep.creatorId
    WHERE vaultKeep.id = LAST_INSERT_ID();";
    KeptKeep keptKeep = _db.Query<VaultKeep, KeptKeep, Account, KeptKeep>(sql, (vaultKeep, keep, account) => 
    {
      keep.Id = vaultKeep.Id;
      keep.KeepId = vaultKeep.KeepId;
      keep.VaultKeepId = vaultKeep.Id;
      keep.VaultId = vaultKeep.VaultId;
      keep.CreatorId = vaultKeep.CreatorId;
      keep.Creator = account;
      // keep.
      return keep;
    }, vaultKeepData).FirstOrDefault();
    return keptKeep;
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<VaultKeep> GetAll()
  {
    throw new NotImplementedException();
  }

  public VaultKeep GetById(int id)
  {
    throw new NotImplementedException();
  }

  public VaultKeep Update(VaultKeep data)
  {
    throw new NotImplementedException();
  }
}