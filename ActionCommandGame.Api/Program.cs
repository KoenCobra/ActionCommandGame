using ActionCommandGame.Api.Installers.Extensions;
using ActionCommandGame.Repository;
using Microsoft.EntityFrameworkCore;

var MyAllowAllOrigins = "_myAllowAllmyOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

// Install services to the container using IInstaller classes.
builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

//Initialize dbContext data
//using var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<ActionCommandGameDbContext>();

//had to put this back because otherwise the attack, defence, and fuel was not being consumed anymore
var dbContext = app.Services.GetRequiredService<ActionCommandGameDbContext>();
if (dbContext.Database.IsInMemory())
{
    dbContext.Initialize();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Action Command Game API v1"));
}

app.UseHttpsRedirection();

app.UseCors(MyAllowAllOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
