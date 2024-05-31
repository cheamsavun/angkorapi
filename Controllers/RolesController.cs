
namespace AngkorERP.Controllers;

public class RolesController : ApiControllerBase
{
    [Authorize("role.list")]
    [HttpGet("")]
    public async Task<PagingList<RoleInfo>> List([FromQuery] RolePagingQuery query)
    {
        return await Mediator.Send(query);
    }

    [Authorize("role.view")]
    [HttpGet("{RoleId}")]
    public async Task<RoleInfo> Get(int RoleId)
    {
        var query = new RoleInfoQuery() { RoleId = RoleId };
        return await Mediator.Send(query);
    }

    [Authorize("role.view")]
    [HttpGet("{RoleId}/Permission")]
    public async Task<ActionResult> GetPermission(int RoleId)
    {

        var list = await Mediator.Send(new PermissionListQuery { RoleId = RoleId });
        return Ok(list);
    }

    [Authorize("role.create")]
    [ProducesResponseType(201)]
    [HttpPost]
    public async Task<ActionResult<RoleInfo>> Create([FromBody] RoleCreateCommand command)
    {
        var data = await Mediator.Send(command);
        return Created("", data);
    }

    [Authorize("role.update")]
    [HttpPut("{RoleId}")]
    public async Task<IActionResult> Update(int RoleId, [FromBody] RoleUpdateCommand cmd)
    {
        cmd.RoleId = RoleId;
        await Mediator.Send(cmd);
        return Ok();
    }

    [Authorize("role.update")]
    [HttpPut("{RoleId}/Permission")]
    public async Task<IActionResult> SetPermission(int RoleId, [FromBody] PermissionUpdateCommand cmd)
    {
        cmd.RoleId = RoleId;
        await Mediator.Send(cmd);
        return Ok();
    }

    [Authorize("role.delete")]

    [HttpDelete, Route("{RoleId}")]
    public async Task<ActionResult> Delete(int RoleId)
    {
        await Mediator.Send(new RoleDeleteCommand { RoleId = RoleId });

        return Ok();
    }

}
