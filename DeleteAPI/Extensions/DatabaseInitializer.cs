using System.Data.SqlClient;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DeleteAPI.Extensions
{
    public static class DatabaseInitializer
    {
        public static async Task MigrateDatabaseAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FiapDataContext>();

                try
                {
                    var databaseExists = await dbContext.Database.CanConnectAsync();

                    if (!databaseExists)
                    {
                        await dbContext.Database.EnsureCreatedAsync();
                    }
                    else
                    {
                        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                        if (pendingMigrations.Any())
                        {
                            await dbContext.Database.MigrateAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro durante a migração ou criação do banco: {ex.Message}");
                }
            }
        }
    }
}
