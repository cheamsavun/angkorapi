# Welcome to Angkor API 

## A C# .NET8.0 project clean architecture CQRS template using code generation from Entities to API Controllers

Cloned from this https://github.com/jasontaylordev/CleanArchitecture but changed some implementations.

### Step 1: Clone from this
```
git clone https://github.com/cheamsavun/angkorapi.git
```

### Step 2: create your entites
See sample codes in Entities folder.

```
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
    // more fields...

    // optional but if you want to assign some default values 
    [GenMapBeforeInsert]
    public void MapSave_or_any_name(Customer c)
    {
        c.Name = $"{c.FirstName} {c.LastName}";
    }
}
```

### Step 3: add database migration
in MacOS/Linux, you can use ./ef-mig-add.sh {version_number}

### Step 4: define your API controller
See sample codes in Controllers folder. Just type in a few lines of code and you get a CRUD API up and runnning. Example:

```
[GenerateCrudApi(typeof(Customer), ExportExcel: true)]
public partial class CustomersController : ApiControllerBase
{
}
```

Enjoy !!!
