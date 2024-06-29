
using Angkorsoft.Core.Enums;

namespace AngkorAPI.Enums;

public enum PermissionScope
{
    User = Permissions.CRUDPort,
    Role = Permissions.CRUD + Permissions.Export,

    Customer = Permissions.CRUDPort + Permissions.DataAdmin,
    DocLib = Permissions.List + Permissions.View + Permissions.Create + Permissions.Delete,

    Category = Permissions.CRUDPort,
    Item = Permissions.CRUDPort,
    Invoice = Permissions.CRUDPort + Permissions.Approve + Permissions.RevertApprove + Permissions.DataAdmin,
   
    ApiKey = Permissions.CRUD,  
    ListOfValue = Permissions.CRUD,

    MsgTpl = Permissions.CRUD,
    SysMsg = Permissions.List + Permissions.Delete + Permissions.Export,
    SysJob = Permissions.CRUD,
    Setting = Permissions.List + Permissions.View + Permissions.Update
}
