# Welcome to Angkor API 
## A C# .NET8.0 project template using code generation from Entities to API Controllers

mkdir AngkorAPI

git clone https://github.com/cheamsavun/angkorapi.git

cd AngkorAPI

code .

### Step 1: create your entites
See sample codes in Entities folder

### Step 2: add database migration
in MacOS/Linux, you can use ./ef-mig-add.sh {version_number}

### Step 3: define your API controller
See sample codes in Controllers folder. Just type in a few lines of code and you get a CRUD API up and runnning. Example:

```
[GenerateCrudApi(typeof(Customer), ExportExcel: true)]
public partial class CustomersController : ApiControllerBase
{
}
```
