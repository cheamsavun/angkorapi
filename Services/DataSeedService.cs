using AngkorAPI.Enums;
using Angkorsoft.Core.Enums;

namespace AngkorAPI.Services;

public class DataSeedService : IHostedService
{
    private readonly IServiceProvider serviceProvider;
    private readonly ICoreDbContext coreContext;
    private readonly IAppDbContext appDbContext;

    public DataSeedService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        var provider = serviceProvider.CreateScope().ServiceProvider;
        coreContext = provider.GetRequiredService<ICoreDbContext>();
        appDbContext = provider.GetRequiredService<IAppDbContext>();
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
       
        coreContext.ChangeTracker.AutoDetectChangesEnabled = true;

        await SeedSystemSettings();
        await SeedAutoNumbers();
        await SeedMsgTpls();
        await SeedLOVHeaders();
        await SeedLOVs();

    }

    private async Task SeedLOVs()
    {
        var data = new List<SysList>();

        data.AddRange(GenList(LOVHeaders.TitleOfCurtesy, new() {
            new(1,"Mr."),
            new(2,"Mrs."),
            new(3,"Ms."),
            new(4,"Dr."),
        }));

        data.AddRange(GenList(LOVHeaders.Gender, new() {
            new(1,"Male"),
            new(2,"Female"),
            new(3,"Other")
        }));

        data.AddRange(GenList(LOVHeaders.Nationality, new() {
            new(1,"Cambodian")
        }));

        data.AddRange(GenList(LOVHeaders.Country, new() {
            new(1,"Cambodia")
        }));

        data.AddRange(GenList(LOVHeaders.Marital_Status, new() {
            new(1,"Single"),
            new(2,"Married"),
            new(3,"Divorced"),
            new(4,"Widower")
        }));

        await _SeedLists(data);
    }
    private List<SysList> GenList(LOVHeaders appList, List<IdName> values)
    {
        var ret = new List<SysList>();
        foreach (var itm in values)
        {
            ret.Add(new SysList() { ListId = (short)appList, Value = itm.Id, Name = itm.Name });
        }
        return ret;
    }
    private async Task SeedSystemSettings()
    {
        var data = new List<SysSetting>(){
            new SysSetting(){ SettingName="ALLOW_MAX_FILE_SIZE", SettingValue="8", Description="Size in MB"},
            new SysSetting(){ SettingName="ALLOW_FILE_EXT", SettingValue="jpg, png, jpeg, gif, tiff, psd, pdf, doc, docx, xls, xlsx, csv, ppt, pptx, odt, rtf, zip", Description="File extensions without dot and separated by comma"},

            new SysSetting(){ SettingName="APP_PATH", SettingValue="http://localhost:3006", Description="Web application URL address"},
            new SysSetting(){ SettingName="ACC_CREATE_PWD_URL", SettingValue="http://localhost:3006/account/create-pwd", Description="URL web address for verify account and create password."},
            new SysSetting(){ SettingName="SMTP_SERVER", SettingValue="mail.domain.com", Description="Mail Server Address"},
            new SysSetting(){ SettingName="SMTP_PORT", SettingValue="587", Description="Mail server port"},
            new SysSetting(){ SettingName="SMTP_USER", SettingValue="user1", Description=""},
            new SysSetting(){ SettingName="SMTP_PASSWORD", SettingValue="SuperPwd", Description=""},
            new SysSetting(){ SettingName="SMTP_SENDER", SettingValue="AngkorAPI.Test Portal", Description="Sender name"},
            new SysSetting(){ SettingName="SMTP_TIMEOUT", SettingValue="20", Description="In second"},

            new SysSetting(){ SettingName="SMS_DEVMODE", SettingValue="1", Description="1=true or 0 = false"},
            new SysSetting(){ SettingName="SMS_API_URL", SettingValue="https://cloudapi.plasgate.com/api/send", Description=""},
            new SysSetting(){ SettingName="SMS_API_PARAM", SettingValue="username=user;password=password;sender=SMS Info;to={to};content={content}", Description=""},
            new SysSetting(){ SettingName="SMS_API_FORMAT", SettingValue="form", Description="API parameter format: form or json"},
            new SysSetting(){ SettingName="MSG_PUSH_DELAY", SettingValue="1000", Description="Delay in milliseconds from one to another call to message API server (both SMS and Email)."},

        };

        foreach (var d in data)
            coreContext.SysSettings.AddIfNotExists(d, x => x.SettingName == d.SettingName);
        await coreContext.SaveChangesAsync();

    }

    private async Task SeedLOVHeaders()
    {
        var headers = Enum.GetValues(typeof(LOVHeaders)).Cast<LOVHeaders>()
                .Select(lst => new SysListHeader
                {
                    Id = (short)lst,
                    Name = lst.ToString().RemoveSpecialCharacters(" ")
                });

        foreach (var h in headers)
            coreContext.SysListHeaders.AddIfNotExists(h, x => x.Id == h.Id);
        await coreContext.SaveChangesAsync();
    }

    private async Task _SeedLists(IEnumerable<SysList> values)
    {
        foreach (var lov in values)
            coreContext.SysLists.AddIfNotExists(lov, x => x.ListId == lov.ListId && x.Value == lov.Value);
        await coreContext.SaveChangesAsync();
    }

    private async Task SeedAutoNumbers()
    {
        var data = new List<SysAutoNum>(){
            new SysAutoNum(){Entity="CUSTOMER", Format="\"C\"[R6]", NextNumber=1},
            new SysAutoNum(){Entity="EMPLOYEE", Format="\"E\"[R6]", NextNumber=1},
            new SysAutoNum(){Entity="ITEM", Format="\"I\"[R6]", NextNumber=1},
            new SysAutoNum(){Entity="CATEGORY", Format="\"C\"[R6]", NextNumber=1}
        };
        foreach (var d in data)
            coreContext.SysAutoNums.AddIfNotExists(d, x => x.Entity == d.Entity);
        await coreContext.SaveChangesAsync();
    }

    private async Task SeedMsgTpls()
    {
        var data = new List<SysMsgTpl>(){
            new SysMsgTpl() {Name="ACCOUNT_CREATION_SMS", Body="Account registered. Please use this number {{VerifyCode}} to verify.", Type=MessageTypes.SMS, Description="Sms template to send to risk members once login is created"},
            new SysMsgTpl() {Name="ACCOUNT_CREATION_EMAIL", Subject="Account login registered", Body="Greetings !!! <br />Your account has been registered. Please click on this link to create your password. <p> {{CreatePwdLink}} </p>", Type=MessageTypes.Email, Description="Email template to send to risk members once login is created"},
        };
        foreach (var d in data)
            coreContext.SysMsgTpls.AddIfNotExists(d, x => x.Name == d.Name);
        await coreContext.SaveChangesAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

}
