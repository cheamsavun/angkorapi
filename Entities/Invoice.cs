

namespace AngkorAPI.Entities;

public class Invoice : BaseEntity
{
    [Required]
    [GenListQueryParam]
    [GenDefaultValue(BizDocTypes.Invoice)]
    public BizDocTypes DocType { get; set; }
    
    [MaxLength(20)]
    [Required]
    [GenSearchable]
    [GenAutoNumber]
    public string Number { get; set; }

    [Required]
    public DateOnly DocDate { get; set; }
    
    [Required]
    public DateOnly NextDate { get; set; }

    public int RefID { get; set; }
    public string RefType { get; set; }

    [Required]
    [GenSearchable]
    public Customer Customer { get; set; }

    [MaxLength(800)]
    public string CustomerAddress { get; set; }

    public Employee Employee { get; set; }
    

    [MaxLength(400)]
    public string InvoiceNote { get; set; }
    public decimal GrossAmount { get; set; }
    public decimal GrossAmountFc { get; set; }
    [MaxLength(20)]
    public string DiscountValue { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal DiscountAmountFc { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }
    public decimal TotalAmountFc { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TaxAmountFc { get; set; }
    public decimal GrandTotal { get; set; }
    public decimal GrandTotalFc { get; set; }

    [MaxLength]
    public string Notes { get; set; }
    
    [Required]
    public decimal TotalPaid { get; set; }

    public string ShipToAddress { get; set; }
    public SysList ShipVia { get; set; }
    public string TrackingNumber { get; set; }
    public string CustomerNotes { get; set; }
    
    public string CommissionValue { get; set; }
    public decimal CommissionAmount { get; set; }
    
    [GenIgnoreUpdate]
    [GenDefaultValue(InvoiceStates.Draft)]
    public InvoiceStates State { get; set; }
    
    [GenIgnoreListOutput]
    public ICollection<InvoiceLine> Lines { get; set; }

    
    [GenIgnoreSave]
    [GenIgnoreListOutput]
    [GenDefaultValue(false)]
    public bool SysCreated { get; set; }

    [GenMapBeforeCreate]
    private async Task MapOnInsert(Invoice inv, IAppDbContext context) {
        inv.State = InvoiceStates.Draft;
        inv.TotalPaid = 0;
    }


}

