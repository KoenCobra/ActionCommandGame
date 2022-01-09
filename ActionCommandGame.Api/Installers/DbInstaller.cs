using ActionCommandGame.Api.Installers.Abstractions;
using ActionCommandGame.Repository;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        private static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ActionCommandGameDbContext");

            services.AddDbContext<ActionCommandGameDbContext>(options =>
            {
                options.UseLoggerFactory(ConsoleLoggerFactory);
                options.EnableSensitiveDataLogging();
                //options.UseInMemoryDatabase("InMemoryDb");
                options.UseSqlServer(connectionString);

            //had to put this back because otherwise the attack, defence, and fuel was not being consumed anymore
            }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);
        }
    }
}
