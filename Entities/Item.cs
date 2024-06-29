namespace AngkorAPI.Entities;

public class Item : BaseCodeNameEntity
{

  public ItemTypes ItemType { get; set; }

  public Category Category { get; set; }

  [GenDefaultValue(0)]
  public decimal Cost { get; set; }

  public bool ShowInCatalog { get; set; }

}

