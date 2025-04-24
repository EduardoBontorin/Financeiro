using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Dima.Web;
using Dima.Web.Security;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddMudServices();

builder.Services.AddHttpClient(Configuration.HttpClientName,opt => 
{
    opt.BaseAddress = new Uri(Configuration.BackednUrl);
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();
