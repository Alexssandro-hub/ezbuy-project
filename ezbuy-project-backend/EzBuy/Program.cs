using System.Configuration;
using EzBuy.AppContext; 
using EzBuy.Interfaces; 
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Text;
using ezBuy.Business.Layer.Services;
using ezBuy.Business.Services.Validation;
using ezBuy.Business.Layer.Services.Custom; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ezBuy.Business.Layer.Services.Interfaces;
using ezBuy.DAO.Layer.Repositories.UserRepository;
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
builder.Services.AddScoped(typeof(FluentValidationService));
builder.Services.AddScoped(typeof(LoginService));
builder.Services.AddScoped(typeof(EncryptPassService)); 
builder.Services.AddScoped<UserRepository<User>>();

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddEndpointsApiExplorer();  
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


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
 
