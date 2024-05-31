namespace AngkorAPI.Entities;

public class InvoiceLine : BaseEntity
{
    [Required]
    public Invoice Invoice { get; set; }

    [Required]
    public Item Item { get; set; }

    [GenIgnoreSave]
    [MaxLength(800)]
    public string ItemName { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountRate { get; set; }
    public decimal DiscountAmt { get; set; }
    public decimal SubTotal { get; set; }

    [MaxLength(4000)]
    public string Remark { get; set; }
    public short OrderIndex { get; set; }

    [GenMapBeforeSave]
    private void MapOnInsert(InvoiceLine line, InvoiceLinesUpdateInput inp,  IAppDbContext context) {
        line.SubTotal = line.Quantity * line.Price * (1 - line.DiscountRate / 100);
        line.ItemName = inp.ItemName;
    }

}
