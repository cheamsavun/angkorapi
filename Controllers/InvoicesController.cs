
namespace AngkorAPI.Controllers;

[GenerateCrudApi(typeof(Invoice), ExportExcel: true, ConsoleLog: false)]
public partial class InvoicesController : ApiControllerBase
{


}
