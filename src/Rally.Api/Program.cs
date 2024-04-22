using AspnetRun.Core.Repositories.Base;
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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentBaseRepository, EquipmentBaseRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ISignBaseRepository, SignBaseRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISignRepository, SignRepository>();

// Register services
builder.Services.AddScoped(typeof(IService<,>), typeof(Service<,>));
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentBaseService, EquipmentBaseService>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ISignBaseService, SignBaseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISignService, SignService>();

//! Register DbContext with local DB
builder.Services.AddDbContext<RallyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

//FIXME -  //! Register DbContext with remote DB
// builder.Services.AddDbContext<RallyContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


