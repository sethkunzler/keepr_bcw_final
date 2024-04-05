namespace keepr_bcw_final.Models;

public abstract class RepoItem
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}