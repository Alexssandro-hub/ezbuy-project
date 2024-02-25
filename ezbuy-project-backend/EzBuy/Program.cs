using System.Configuration;
using EzBuy.AppContext;
using ezBuy.DAO.Layer.BaseTransactionOperations;
using ezBuy.DAO.Layer.EntityFrameworkConnection;
using EzBuy.Interfaces;
using EzBuy.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using ezBuy.Business.Layer.Services;
using ezBuy.Business.Services.Validation;
using ezBuy.Business.Layer.Services.Custom;
using ezBuy.DAO.Layer;
using ezBuy.DAO.Layer.Interfaces;
using ezBuy.DAO.Layer.EFCore;
using EzBuy.Models;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = new List<CultureInfo> { new("en-US") };
    options.SupportedUICultures = new List<CultureInfo> { new("en-US") };

});
 
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
builder.Services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();
builder.Services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>(); 
builder.Services.AddScoped(typeof(FluentValidationService));
builder.Services.AddScoped(typeof(LoginService));
builder.Services.AddScoped(typeof(EncryptPassService));
//builder.Services.AddScoped(typeof(UserRepository));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v0", new OpenApiInfo
    {
        Title = "EzBuy API",
        Version = "v0"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint(url: "../swagger/v0/swagger.json", name: "EzBuy API");

            x.DocumentTitle = "Title Documentation";
            x.DocExpansion(DocExpansion.None);
        });

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
 
