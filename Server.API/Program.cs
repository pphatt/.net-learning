using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Server.API.Extensions;
using Server.Application.Extensions;
using Server.Infrastructure.Extensions;
using Serilog;
using Serilog.Events;
using Server.API.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Server.Domain.Entity.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Host.AddLogging();

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = ".Net Learning API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            []
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add auto mapper validation.
app.AddAutoMapperValidation();

// add serilog.
app.AddSerilog();

// add error handling middleware.
app.AddMiddleware();

// add user identity.
app.MapGroup("/api/identity").MapIdentityApi<AppUsers>();

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
