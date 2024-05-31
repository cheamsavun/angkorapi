using Microsoft.EntityFrameworkCore.Migrations;

namespace AngkorAPI.Infrastructure;

public static class ConfigureInfrastructueExtension
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider().CreateScope().ServiceProvider;
        var env = sp.GetRequiredService<IWebHostEnvironment>();
        var config = sp.GetRequiredService<IConfiguration>();
        var connectionString = config.GetConnectionString("DefaultConnection");
        var migrationsAssembly = typeof(AppDbContext).Assembly.FullName;
        services.AddDbContext<AppDbContext>(options =>
        {
            if(env.IsDevelopment()) 
                options.EnableSensitiveDataLogging(true);
            options.UseNpgsql(connectionString, o =>
            {
                o.MigrationsAssembly(migrationsAssembly);
                o.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: "data");
                o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });
        services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>()!);
        // services.AddScoped<AppDbContext>();
        return services;
    }
}