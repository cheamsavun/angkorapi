namespace AngkorAPI.Entities;

public class Customer : BasePerson
{
    [MaxLength(20)]
    [Required]
    [GenAutoNumber]
    [GenNameLookup]
    public string Code { get; set; }

    public bool IsCorp { get; set; }
    public bool IsLocal { get; set; }
    public SysList Industry { get; set; }
    public SysList Nationality { get; set; }
    public string VATIN { get; set; }

    public virtual ICollection<CustomerContact> Contacts { get; set; }

    [GenPreSave]
    public void MapSave(Customer c)
    {
        if (c.IsCorp) { }
        else
        {
            c.Name = $"{c.FirstName} {c.LastName}";
            c.NameLoc = $"{c.FirstNameLoc} {c.LastNameLoc}";
        }
    }
}
