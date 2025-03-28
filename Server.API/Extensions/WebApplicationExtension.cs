﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Server.Infrastructure.Persistence;

namespace Server.API.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication AddSerilog(this WebApplication app)
    {
        // serilog config.
        app.UseSerilogRequestLogging();

        return app;
    }

    public static WebApplication AddAutoMapperValidation(this WebApplication app)
    {
        // add auto mapper validation.
        var scope = app.Services.CreateScope();
        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        mapper.ConfigurationProvider.AssertConfigurationIsValid();

        return app;
    }

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
