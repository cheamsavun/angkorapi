namespace AngkorAPI.Entities;

public class Category : BaseCodeNameEntity
{

    [GenIgnoreSave]
    [GenIgnoreListOutput]
    public ICollection<Item> Items { get; set; }
}
