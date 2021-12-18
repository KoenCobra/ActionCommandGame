using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Ui.BlazorWasm;
using ActionCommandGame.Ui.BlazorWasm.Settings;
using ActionCommandGame.Ui.BlazorWasm.Stores;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);

builder.Services.AddApi(settings.ApiBaseUrl);
builder.Services.AddSingleton<AppSettings>();

builder.Services.AddSingleton<MemoryStore>();
builder.Services.AddSingleton<ITokenStore, TokenStore>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
