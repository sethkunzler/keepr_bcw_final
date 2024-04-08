namespace keepr_bcw_final.Repositories;

public class KeepsRepository : IRepo<Keep>
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Keep Create(Keep data)
  {
    // this is the very important squirrel string which has all the information to form a request to the MySQuirreL
    // It's like a messenger pigeon but a messenger squirrel 
    string squirrel = @"
    INSERT INTO 
    keeps(name, description, img, creatorId)
    VALUES(@name, @description, @img, @creatorId);

    SELECT 
    keep.*,
    account.*
    FROM keeps keep
    JOIN accounts account ON account.id = keep.creatorId 
    WHERE keep.id = LAST_INSERT_ID();";
    Keep keep = _db.Query<Keep, Profile, Keep>(squirrel, _populateCreator, data).FirstOrDefault();
    return keep;
  }

  public List<Keep> GetAll()
  {
    string sql = @"
    SELECT
    keep.*,
    account.*
    FROM keeps keep
    JOIN accounts account ON keep.creatorId = account.id;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, _populateCreator).ToList(); 
    return keeps;
  }

  public Keep GetById(int id)
  {
    string sql= @"
    SELECT 
    keep.*,
    account.*
    FROM keeps keep
    JOIN accounts account ON account.id = keep.creatorId
    WHERE keep.id = @id;";
    Keep keep = _db.Query<Keep, Profile, Keep>(sql, _populateCreator, new { id }).FirstOrDefault();
    return keep;
  }

  public Keep Update(Keep keepData)
  {
    string sql = @"
    UPDATE keeps 
    Set 
    name = @name,
    description = @description
    WHERE id = @id;

    SELECT
    keep.*,
    account.*
    FROM keeps keep 
    JOIN accounts account ON account.id = keep.creatorId
    WHERE keep.id = @id;";
    Keep keep = _db.Query<Keep, Profile, Keep>(sql, _populateCreator, keepData).FirstOrDefault();
    return keep;
  }

  public void Destroy(int id)
  {
    throw new NotImplementedException();
  }

  private Keep _populateCreator(Keep keep, Profile profile)
  {
    keep.Creator = profile;
    return keep;
  }
}
