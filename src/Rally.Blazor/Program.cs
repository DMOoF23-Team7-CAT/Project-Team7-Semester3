using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rally.Blazor;
using Rally.Blazor.Services;
using Rally.Blazor.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Set the correct base address for the HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5221/") });

// Register your CategoryService as ICategoryService
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();
