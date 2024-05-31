
using Angkorsoft.Core.Enums;

namespace AngkorAPI.Enums;

public enum PermissionScope
{
    User = Permissions.CRUDPort,
    Role = Permissions.CRUD + Permissions.Export,

    SysArea = Permissions.CRUD,
    FiscalYear = Permissions.CRUD,

    Customer = Permissions.CRUDPort + Permissions.DataAdmin,
    Referer = Permissions.CRUDPort + Permissions.DataAdmin,
    Vendor = Permissions.CRUDPort + Permissions.DataAdmin,
    Employee = Permissions.CRUDPort + Permissions.DataAdmin,
    DocLib = Permissions.List + Permissions.View + Permissions.Create + Permissions.Delete,

    Category = Permissions.CRUDPort,
    Item = Permissions.CRUDPort,
    Quotation = Permissions.List + Permissions.Export + Permissions.View + Permissions.Create + Permissions.Update + Permissions.Approve + Permissions.RevertApprove + Permissions.DataAdmin,

    Invoice = Permissions.CRUDPort + Permissions.Approve + Permissions.RevertApprove + Permissions.DataAdmin,
    Receipt = Permissions.CRUDPort + Permissions.Approve + Permissions.RevertApprove + Permissions.DataAdmin,

    Bill = Permissions.CRUDPort + Permissions.Approve + Permissions.RevertApprove + Permissions.DataAdmin,
    Payment = Permissions.CRUDPort + Permissions.Approve + Permissions.RevertApprove + Permissions.DataAdmin,


    ApiKey = Permissions.CRUD, // + Permissions.Create + Permissions.Delete + Permissions.Update,
    ListOfValue = Permissions.CRUD,

    MsgTpl = Permissions.CRUD,
    SysMsg = Permissions.List + Permissions.Delete + Permissions.Export,
    SysJob = Permissions.CRUD,

    Commission = Permissions.View,
    Setting = Permissions.List + Permissions.View + Permissions.Update,

    WorkRequest = Permissions.List + Permissions.Create + Permissions.View + Permissions.Update + Permissions.DataAdmin,
    WorkRequestItem = Permissions.CRUD,
    Currency = Permissions.CRUD,
    XRate = Permissions.List + Permissions.Create + Permissions.Delete,
    OrgUnit = Permissions.CRUD,
    CreditTerm = Permissions.CRUD,
    AR_Query = Permissions.List,
    AP_Query = Permissions.List,
    JobTitle = Permissions.CRUD,

    Cl001 = Permissions.View,
    Cl002 = Permissions.View,
    Cl003 = Permissions.View,
    Cl004 = Permissions.View,
}
