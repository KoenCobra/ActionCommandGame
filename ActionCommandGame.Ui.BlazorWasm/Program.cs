using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Ui.BlazorWasm;
using ActionCommandGame.Ui.BlazorWasm.Settings;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);

builder.Services.AddApi(settings.ApiBaseUrl);
builder.Services.AddSingleton<AppSettings>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
