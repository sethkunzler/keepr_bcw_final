namespace keepr_bcw_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase 
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;
  private readonly AccountService _accountsService;

  public ProfilesController(VaultsService vaultsService, Auth0Provider auth0Provider, AccountService accountsService)
  {
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
    _accountsService = accountsService;
  }

    [HttpGet("{profileId}")]
  public ActionResult<Profile> GetProfileById(string profileId)
  {
    try
    {
      Profile profile = _accountsService.GetProfileById(profileId);
      return profile; 
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetVaultsByProfileId(userInfo?.Id, profileId);
      return Ok(vaults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}

