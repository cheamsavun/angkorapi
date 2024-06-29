namespace AngkorAPI.Entities;

public abstract class BasePerson : BaseEntity
{
    
    public SysList TitleOfCurtesy {get;set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [GenNameLookup]
    [GenSearchable]
    public string Name { get; set;}

    public string FirstNameLoc { get; set; }
    public string LastNameLoc { get; set; }

    [GenSearchable]
    public string NameLoc { get; set;}

    public SysList Gender { get; set; }
    
    public DateOnly BirthDate { get; set; }
    public string IdCard { get; set; }
    public DateOnly IdCardIssueDate { get; set; }
    public string Phone1 { get; set; }

    public string Phone2 { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    
    public byte[] Photo { get; set; }
    public byte[] PhotoTh { get; set; }

    public string ErrMsg { get; set; }

   public string Notes { get; set; }

}
