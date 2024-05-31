
namespace AngkorERP.Controllers;

public class UsersController(IWebHostEnvironment environment) : ApiControllerBase
{
    [Authorize("user.list")]
    [HttpGet("")]
    public async Task<PagingList<UserListInfo>> GetUserList([FromQuery] UserListQuery query)
    {
        return await Mediator.Send(query);
    }

    [Authorize("user.view")]
    [HttpGet("{UserId}")]
    public async Task<UserInfo> GetUserInfo([FromQuery] UserInfoQuery query, int UserId)
    {
        query.UserId = UserId;
        return await Mediator.Send(query);
    }

    [Authorize("user.create")]
    [ProducesResponseType(201)]
    [HttpPost]
    public async Task<ActionResult<UserInfo>> Create([FromBody] UserCreateCommand command)
    {
        var data = await Mediator.Send(command);
        return Created("", data);
    }

    [Authorize("user.update")]
    [HttpPut("{UserId}")]
    public async Task<ActionResult> Update(UserUpdateCommand cmd, int UserId)
    {
        cmd.Id = UserId;
        await Mediator.Send(cmd);
        return Ok();
    }

    [Authorize("user.update")]
    [HttpPut("{UserId}/UpdatePassword")]
    public async Task<IActionResult> PasswordUpdateAsync([FromBody] PasswordUpdateCommand cmd, int UserId)
    {
        cmd.UserId = UserId;
        await Mediator.Send(cmd);
        return Ok();
    }

    [Authorize("user.delete")]
    [HttpDelete, Route("{UserId}")]
    public async Task<ActionResult> Delete(int UserId)
    {
        await Mediator.Send(new UserDeleteCommand { UserId = UserId });
        return Ok();
    }

    [Authorize("user.update")]
    [HttpPut("{UserId}/Photo")]
    public async Task<IActionResult> UploadUserPhoto(int UserId, [FromBody] UserPhotoUploadCommand cmd)
    {
        cmd.UserId = UserId;
        await Mediator.Send(cmd);
        return Ok();
    }

    [Authorize("user.view")]
    [HttpGet("{UserId}/Thumbnail")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, "image/jpeg", "application/octet-stream")]
    public async Task<IActionResult> GetThumbnailPhoto(int UserId)
    {
        var bytes = await Mediator.Send(new UserPhotoQuery() { UserId = UserId, FullPicture = false });
        if (bytes == null)
        {
            string filePath = Path.Combine(environment.ContentRootPath, "files//no_photo.png");
            bytes = await ImageSharpExtension.LoadFromFileAsync(filePath);
        }
        return File(bytes, "image/png");
    }

    [Authorize("user.view")]
    [HttpGet("{UserId}/Photo")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, "image/jpeg", "application/octet-stream")]
    public async Task<IActionResult> GetFullPhoto(int UserId)
    {
        var bytes = await Mediator.Send(new UserPhotoQuery() { UserId = UserId, FullPicture = true });
        if (bytes == null)
        {
            string filePath = Path.Combine(environment.ContentRootPath, "files//no_photo.png");
            bytes = await ImageSharpExtension.LoadFromFileAsync(filePath);
        }
        return File(bytes, "image/png");
    }

    [Authorize]
    [HttpGet("Setting/{Name}")]
    public async Task<ActionResult<string>> GetUserSettings(string Name)
    {
        return await Mediator.Send(new UserSettingInfoQuery() { Name = Name });
    }

    [Authorize]
    [HttpPut("Setting")]
    public async Task<ActionResult> SaveUserSettings(UserSettingUpdateCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

}
