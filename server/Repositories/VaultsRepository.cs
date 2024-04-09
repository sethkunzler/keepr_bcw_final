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
    string sql = @"
    INSERT INTO 
    vaults(name, description, img, isPrivate, creatorId)
    VALUES(@name, @description, @img, @isPrivate, @creatorId);

    SELECT 
    vault.*,
    account.*
    FROM vaults vault
    JOIN accounts account ON vault.creatorId = account.id
    WHERE vault.id = LAST_INSERT_ID();";
    Vault vault = _db.Query<Vault, Profile, Vault>(sql, _populateCreator, data).FirstOrDefault();
    return vault;
  }

    public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  public List<Vault> GetAll()
  {
    throw new NotImplementedException();
  }
  public List<Vault> GetAllVaultsByProfileId(string profileId)
  {
    // FIXME - after keepsCount on Vault is set up
    // string sql = @"
    // SELECT
    // vault.*,
    // COUNT(keep.id) AS keepCount,
    // account.*
    // LEFT JOIN keeps keep ON keep.vaultId = vault.id
    // FROM vaults vault 
    // JOIN accounts account ON vault.creatorId = account.id
    // GROUP BY (vault.id);"

    string sql = @"
    SELECT
    vault.*,
    account.*
    FROM vaults vault 
    JOIN accounts account ON vault.creatorId = account.id
    WHERE vault.creatorId = @profileId;";

    List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, _populateCreator, new {profileId}).ToList();
    return vaults;
  }

  public Vault GetById(int id)
  {
    string sql = @"
    SELECT 
    vault.*,
    account.*
    FROM vaults vault
    JOIN accounts account ON account.id = vault.creatorId
    WHERE vault.id = @id;";

    Vault vault = _db.Query<Vault, Profile, Vault>(sql, _populateCreator, new { id }).FirstOrDefault();
    return vault;
  }

  public Vault Update(Vault data)
  {
    throw new NotImplementedException();
  }

  private Vault _populateCreator(Vault vault, Profile profile)
    {
      vault.Creator = profile;
      return vault;
    }
}