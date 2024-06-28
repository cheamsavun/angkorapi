
namespace AngkorAPI.Entities;

public class Customer : BaseEntity
{

    [MaxLength(20)]
    [Required]
    [GenAutoNumber]
    public string Code { get; set; }
    public SysList TitleOfCurtesy { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
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
    public string ContactName { get; set; }

    public string Notes { get; set; }

    public bool IsCorp { get; set; }
    public bool IsLocal { get; set; }

    public Employee AccHandler { get; set; }

    [GenPreSave]
    public void MapSave(Customer c)
    {
        c.Name = $"{c.FirstName} {c.LastName}";
    }

}
