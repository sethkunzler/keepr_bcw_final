namespace keepr_bcw_final.Models;

public class VaultKeep : RepoItem<int> 
{
  public int VaultId { get; set; }
  public int KeepId { get; set; }
  public string CreatorId { get; set; }
  
}