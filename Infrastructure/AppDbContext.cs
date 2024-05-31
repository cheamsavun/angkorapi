using System.Reflection;

namespace AngkorAPI.Infrastructure;

[GenerateDbSets]
public partial class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Only set for PgSql
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
 
    public DbSet<SysListHeader> SysListHeaders { get; set; }
    public DbSet<SysList> SysLists { get; set; }
    public DbSet<SysArea> SysAreas { get; set; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLine> InvoiceLines { get; set; }
   

    public async Task<int> SaveChangesAsync()
    {
        return await SaveChangesAsync(CancellationToken.None);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // all of these are already configured in core
        builder.Entity<SysListHeader>().ToTable("SysListHeaders", "system", t => t.ExcludeFromMigrations());
        builder.Entity<SysList>().ToTable("SysLists", "system", t => t.ExcludeFromMigrations());
        builder.Entity<SysArea>().ToTable("SysAreas", "system", t => t.ExcludeFromMigrations());
        

        builder.HasDefaultSchema("data");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.Entity<Invoice>().HasIndex(p => new { p.DocType, p.Number }).IsUnique();
        
        foreach (var prop in builder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
        {
            if (prop.GetMaxLength() == null)
                prop.SetMaxLength(250);
        }
 
    }
}