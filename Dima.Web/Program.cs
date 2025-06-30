using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Dima.Web;
using Dima.Web.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Dima.Core.Handlers;
using Dima.Web.Handlers;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Configuration.BackednUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty; //TODO: Adicionar excess�o

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddMudServices();


builder.Services.AddTransient<IAccountHandler, AccountHandler>();
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
builder.Services.AddTransient<ILocalHandler, LocalHandler>();
builder.Services.AddTransient<IApontamentoHandler, ApontamentoHandler>();

builder.Services.AddLocalization();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR"); //TODO: Para for�ar o PT-br, se nao via pegar a do sistema.
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

builder.Services.AddHttpClient(Configuration.HttpClientName,opt => 
{
    opt.BaseAddress = new Uri(Configuration.BackednUrl); 
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();
