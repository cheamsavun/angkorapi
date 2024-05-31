namespace AngkorERP.Controllers;

[GenerateCrudApi(typeof(Item))]
public partial class ItemsController: ApiControllerBase
{
    
    [AuthorizeX("quotation.create, quotation.update")]
    [HttpGet("lookup")]
    public async Task<PagingList<ItemListInfo>> GetPagingList([FromQuery] ItemListQuery query)
    {
        return await Mediator.Send(query);
    }
    
}

