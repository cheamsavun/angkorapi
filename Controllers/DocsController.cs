
namespace AngkorAPI.Controllers;
[GenerateCreateCommandController(typeof(SysDoc), Authorize: false)]
[GenerateDeleteCommandController(typeof(SysDoc), Authorize: false, ConsoleLog: false)]
[GenerateListQueryController(typeof(SysDoc), Authorize: false)]
[GenerateInfoQueryController(typeof(SysDoc), Authorize: false)]
public partial class DocsController(ICoreDbContext coreDbContext) : ApiControllerBase
{

    [Authorize]
    [HttpGet("{Id}/View")]
    public async Task<ActionResult> ViewDoc(int Id)
    {
        var bytes = await Mediator.Send(new SysDocViewQuery() { Id = Id });
        return File(bytes, "application/octet-stream");
    }

}
