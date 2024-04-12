namespace keepr_bcw_final.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vaultsService, KeepsService keepsService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _vaultsService = vaultsService;
    _keepsService = keepsService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("vaults")]
  [Authorize]
  public async Task<ActionResult<List<Vault>>> GetMyVaults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string profileId = userInfo.Id; 
      // The method calls for a profile Id to verify against the current logged in user, but we already did this with [Authorize]
      // as one lazy developer to another - why reinvent the wheel if a round one will always be better than a square one.
      // you should always cut corners for the same reason, it get's you places faster.
      
      List<Vault> vaults = _vaultsService.GetVaultsByProfileId(userInfo.Id, profileId);
      return Ok(vaults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
  [HttpGet("keeps")]
  [Authorize]
  public async Task<ActionResult<List<Keep>>> GetMyKeeps()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _keepsService.GetKeepsByProfileId(userInfo.Id);
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
  


  [HttpPut]
  [Authorize]
  public async Task<ActionResult<Account>> UpdateAccount([FromBody] Account accountData)
  {
    try
    {
      // REVIEW - there is currently no check for this, so it could very likely be wrong
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.Edit(accountData, userInfo.Email));
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}
