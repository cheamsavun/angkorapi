namespace AngkorAPI.Controllers;

[GenerateCrudApi(typeof(Item), ConsoleLog: false)]
public partial class ItemsController: ApiControllerBase
{
    
   [AuthorizeX("quotation.create, quotation.update")]
    [HttpGet("lookup")]
    public async Task<PagingList<ItemListInfo>> GetPagingList([FromQuery] ItemListQuery query)
    {
        return await Mediator.Send(query);
    }   
    
}

