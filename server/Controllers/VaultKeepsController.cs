namespace keepr_bcw_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase 
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0Provider;

    public VaultKeepsController(Auth0Provider auth0Provider, VaultKeepsService vaultKeepsService)
    {
        _auth0Provider = auth0Provider;
        _vaultKeepsService = vaultKeepsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
    {
      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        vaultKeepData.CreatorId = userInfo.Id;
        KeptKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData); 
        return Ok(vaultKeep); 
      }
      catch (Exception exception)
      {
        return BadRequest(exception.Message);
      }
    }
}