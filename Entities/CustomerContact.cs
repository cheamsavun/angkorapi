
namespace AngkorAPI.Entities;

public class CustomerContact : BaseEntity
{
    public Customer Customer { get; set; }

    [Required]
    public string ContactName { get; set; }
    
    public string JobTitle { get; set; }

    [MaxLength(20)]
    public string Phone1 { get; set; }

    [MaxLength(20)]
    public string Phone2 { get; set; }
    public string Email { get; set; }

    [MaxLength(100)]
    public string Note { get; set; }
    
}
