namespace keepr_bcw_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase 
{
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0Provider;

  public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider, KeepsService keepsService)
  {
    _vaultsService = vaultsService;
    _keepsService = keepsService;
    _auth0Provider = auth0Provider;
  }

    [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.CreateVault(vaultData);
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{vaultId}")]
  public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpPut("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<Vault>> UpdateVault(int vaultId, [FromBody] Vault vaultData) {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string userId = userInfo.Id;
      Vault updatedVault = _vaultsService.UpdateVault(vaultId, vaultData, userId); 
      return Ok(updatedVault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
  
  [HttpDelete("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<Vault>> DeleteVault(int vaultId) 
  {
    try 
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _vaultsService.DeleteVault(vaultId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [HttpGet("{vaultId}/keeps")]
  public async Task<ActionResult<List<KeptKeep>>> GetKeepsByVaultId(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<KeptKeep> keeps = _keepsService.GetKeepsByVaultId(vaultId, userInfo?.Id);
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
  

}