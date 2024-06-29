namespace AngkorAPI.Entities;

public class Category : BaseCodeNameEntity
{

    public Category Parent { get; set; }
    public byte[] Photo { get; set; }
    public byte[] PhotoThumnail { get; set; }
    
    [GenIgnoreSave]
    [GenIgnoreListOutput]
    public ICollection<Item> Items { get; set; }
}
