namespace AngkorAPI.Entities;

public class Employee : BaseEntity
{

    public SysList TitleOfCurtesy {get;set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name { get; set;}

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

   public string Notes { get; set; }
    

    [GenListQueryOptionalParam]
    public bool Expat { get; set; }

    [MaxLength(int.MaxValue)]
    public string Note { get; set; }

    [GenListQueryDateRangeOptionalParam]
    public DateOnly EmployedDate { get; set; }
    public DateOnly ProbationDate { get; set; }
    
    [GenPreSave]
    public void MapSave(Employee data) {
        data.Name = $"{data.FirstName} {data.LastName}";
        // some more default values
    }
}
