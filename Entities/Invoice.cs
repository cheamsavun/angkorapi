
using System.ComponentModel.DataAnnotations.Schema;

namespace AngkorAPI.Entities;

public class Invoice : BaseEntity
{
    
    [MaxLength(20)]
    [Required]
    [GenSearchable]
    [GenAutoNumber]
    public string Number { get; set; }

    [Required]
    [GenListQueryDateRangeOptionalParam]
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


    [GenDefaultValue(1)]
    public decimal XRate { get; set; }

    [MaxLength]
    public string Notes { get; set; }
    
    [Required]
    public decimal TotalPaid { get; set; }

    public string ShipToAddress { get; set; }
    public SysList ShipVia { get; set; }
    public string TrackingNumber { get; set; }
    public string CustomerNotes { get; set; }
    
    
    [GenIgnoreUpdate]
    [GenDefaultValue(InvoiceStates.Draft)]
    public InvoiceStates State { get; set; }

    [NotMapped]
    public bool Approved => State == InvoiceStates.Approved;
    
    [GenIgnoreListOutput]
    public ICollection<InvoiceLine> Lines { get; set; }

    

    // [GenPreCreate]
    // private async Task MapOnInsert(Invoice inv, InvoiceCreateCommand request, IAppDbContext context) {
    //     inv.State = InvoiceStates.Draft;
    //     inv.BaseCurrency = await context.Currencies.FirstOrDefaultAsync(x => x.IsBase);
    //
    //     inv.TotalAmount = request.Lines.Sum(x => x.SubTotal);
    //     inv.TaxAmount = request.Lines.Sum(x => x.SubTotal * x.TaxRate / 100);
    // }
    //
    // [GenPreUpdate]
    // private async Task MapOnSave(Invoice inv, InvoiceUpdateCommand request) {
    //
    //     inv.TotalAmount = request.Lines.Sum(x => x.SubTotal);
    //     inv.TaxAmount = request.Lines.Sum(x => x.SubTotal * x.TaxRate / 100);
    //     inv.GrandTotal = inv.TotalAmount + inv.TaxAmount;
    // }

}

