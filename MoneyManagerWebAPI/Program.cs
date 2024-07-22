using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using MoneyManagerWebAPI.Models;
using MoneyManagerWebAPI.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add DbContext  AppDbContext
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySQL(builder.Configuration.GetConnectionString("dbcs")
        ?? throw new InvalidOperationException("dbcs Connection String not found.")));

// Add DbContext  U48
builder.Services.AddDbContext<U483397598MauiMoneyContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("dbcs")
        ?? throw new InvalidOperationException("dbcs Connection string not found.")));



// Add Identification
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();


// Authentication Process Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authentication",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//map identity user 
app.MapIdentityApi<AspNetUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
