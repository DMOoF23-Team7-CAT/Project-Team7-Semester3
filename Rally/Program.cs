using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RallyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RallyDbContext") ?? throw new InvalidOperationException("Connection string 'RallyDbContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddControllersWithViews();

//! Added for Razor pages
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RallyDbContext>();
   // context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.MapControllers();


app.UseAuthorization();

//! not needed since its implementet in the MapControllers
//app.UseRouting();
//! not needed since im using top level statenment to sorten it = app.MapControllers();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });
//! the default route is not needed
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
