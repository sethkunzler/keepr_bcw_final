namespace keepr_bcw_final.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      // TODO make email start into name
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name?.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture?.Length > 0 ? editData.Picture : original.Picture;
    original.CoverImg = editData.CoverImg?.Length > 0 ? editData.CoverImg : original.CoverImg;
    return _repo.Edit(original);
  }

  internal Profile GetProfileById(string profileId)
  {
    Profile profile = _repo.GetProfileById(profileId);
    if (profile == null) throw new Exception($"Invalid Profile Id: {profileId}");
    return profile;
  }
}
