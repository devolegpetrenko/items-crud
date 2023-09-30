using frontend;
using frontend.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("backend", (serviceProvider, client) =>
{
    var configuration = serviceProvider.GetService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["BackendHostUrl"]);
});

builder.Services.AddTransient<IItemsService, ItemsService>();

builder.Services.AddAntDesign();

await builder.Build().RunAsync();
