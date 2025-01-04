using Microsoft.EntityFrameworkCore;
using Server.Infrastructure;

namespace Server.API.Extensions;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // apply update-database command here.
        appDbContext.Database.Migrate();
        DataSeeder.SeedData(appDbContext).GetAwaiter().GetResult();

        return app;
    }
}
