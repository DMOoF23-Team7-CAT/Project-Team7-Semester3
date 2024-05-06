using Rally.Core.Repositories.Base;
using Rally.Application.Interfaces;
using Rally.Application.Services;
using Rally.Core.Repositories;
using Rally.Infrastructure.Repositories;
using Rally.Infrastructure.Repositories.Base;
using Rally.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Rally.Application.Interfaces.Base;
using Rally.Application.Services.Base;
using Microsoft.OpenApi.Models;
using Rally.Core.Entities.Account;
using Rally.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            []
        }
    });
});

builder.Services.AddControllers();

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentBaseRepository, EquipmentBaseRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ISignBaseRepository, SignBaseRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISignRepository, SignRepository>();

// Register services
builder.Services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentBaseService, EquipmentBaseService>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ISignBaseService, SignBaseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISignService, SignService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IRallySeeder, RallySeeder>();


builder.Services.AddDbContext<RallyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RallyContext>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRallySeeder>();
await seeder.SeedAsync();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

//Adds the Identity API endpoints to the application.
app.MapGroup("api/Account")
    .WithTags("Account")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();


