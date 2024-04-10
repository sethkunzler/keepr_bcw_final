using System.Drawing;

namespace keepr_bcw_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase 
{
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0Provider;
  private readonly AccountService _accountsService;

  public ProfilesController(VaultsService vaultsService, Auth0Provider auth0Provider, AccountService accountsService, KeepsService keepsService)
  {
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
    _accountsService = accountsService;
    _keepsService = keepsService;
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

  [HttpGet("{profileId}/keeps")]
  public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId)
  {
    try
    {
      List<Keep> keeps = _keepsService.GetKeepsByProfileId(profileId);
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}

