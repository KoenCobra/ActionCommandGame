using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Ui.BlazorWasm;
using ActionCommandGame.Ui.BlazorWasm.Settings;
using ActionCommandGame.Ui.BlazorWasm.Stores;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new AppSettings();
builder.Configuration.GetSection(nameof(AppSettings)).Bind(settings);

builder.Services.AddHttpClient("ActionCommandGame", options =>
{
    options.BaseAddress = new Uri(settings.ApiBaseUrl);
});

builder.Services.AddTransient<GameApi>();
builder.Services.AddTransient<IdentityApi>();
builder.Services.AddTransient<ItemApi>();
builder.Services.AddTransient<PlayerApi>();
builder.Services.AddTransient<PlayerItemApi>();

builder.Services.AddApi(settings.ApiBaseUrl);


builder.Services.AddSingleton<ITokenStore, TokenStore>();
builder.Services.AddSingleton<AppSettings>();


await builder.Build().RunAsync();
