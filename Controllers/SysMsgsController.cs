
namespace AngkorERP.Controllers;

[GenerateCrudApi(typeof(SysMsg),  UseCoreContext: true)]
public partial class SysMsgsController(IMsgQueueManager msgQueue) : ApiControllerBase
{
    [Authorize("sysmsg.list")]
    [HttpPost("Push")]
    public async Task<ActionResult> Push()
    {
        await msgQueue.PushQueuesAsync();
        // await Mediator.Send(new SysMsgQueuePushCommand());
        return Ok();
    }

    [HttpPut("{Id}/SetRead")]
    public async Task<ActionResult> SetRead(int Id)
    {
        await Mediator.Send(new SysMsgSetReadCommand { Id = Id });
        return Ok();
    }
}