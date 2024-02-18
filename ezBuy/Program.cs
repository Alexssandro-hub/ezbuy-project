using System.Configuration;
using ezBuy;
using ezBuy.BusinessCore.Validation;
using ezBuy.Infrastructure.DAO_Layer;
using ezBuy.Providers.Interfaces;
using ezBuy.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração para ler a connection string do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
//ConfigureServices(builder.Services, builder.Configuration);

//void ConfigureServices(IServiceCollection services, IConfiguration configuration)
//{  
//    //services.AddScoped(typeof(TenantProvider));
//    //services.AddScoped(typeof(MultiTenantDbContext));
//    //services.AddScoped(typeof(RepositoryFactory));
//    //services.AddScoped(typeof(FluentValidationService));

//    //services.AddDbContext<MultiTenantDbContext>(options =>
//    //    options.UseSqlServer(configuration.GetConnectionString("Server=ezBuy-local;Port=3306;Database=localhost;Uid=adminezbuy;Pwd=adminezbuy")));

//    //services.AddMvc(); 
//}

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "EzBuy API",
//        Version = "v1"
//    });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please insert JWT with Bearer into field",
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey
//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            Array.Empty<string>()
//        }
//    });
//});

//builder.Services.AddAuthentication();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint(url: "../swagger/v1/swagger.json", name: "EzBuy API");

        x.DocumentTitle = "Title Documentation";
        x.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireCors("EzBuyCORSPolicy");
});



app.Run();
