using Angkorsoft.Core.Services;

namespace AngkorAPI.Controllers;

public class SystemController : ApiControllerBase
{
  [Authorize]
  [HttpPost("TestEmail")]
  public async Task<ActionResult> TestEmail(EmailServiceTestCommand command)
  {
    await Mediator.Send(command);
    return Ok();
  }

  [HttpGet("Settings")]
  public async Task<Dictionary<string, string>> GetSystemSettings()
  {
    // only allowed settings
    string[] names = ["ALLOW_FILE_EXT", "ALLOW_MAX_FILE_SIZE", "DATE_FORMAT"];
    var query = new SysSettingListQuery()
    {
      PageSize = 10000
    };
    var settings = await Mediator.Send(query);
    return settings.Data?.Where(x => names.ContainsIgnoreCase(x.SettingName))
      .ToDictionary(x => x.SettingName, x => x.SettingValue);
  }


}
