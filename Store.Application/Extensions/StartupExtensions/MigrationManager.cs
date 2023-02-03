using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Infra.Data.Contexts;
using System;

namespace Store.Application.Extensions.StartupExtensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<SqlServerContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    } catch
                    {
                        
                    }
                }
            }

            return host;
        }
    }
}
