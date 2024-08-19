using Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DeleteAPI.Extensions
{
    public static class DatabaseInitializer
    {
        public static async Task MigrateDatabaseAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<FiapDataContext>();

            try
            {
                // Cria o banco de dados se ele não existir
                if (await dbContext.Database.EnsureCreatedAsync())
                {
                    // Se o banco de dados foi criado, aplica as migrations
                    Console.WriteLine("Database was created. Applying migrations.");
                    await dbContext.Database.MigrateAsync();
                }
                else
                {
                    Console.WriteLine("Database already exists. Applying migrations.");
                    // Aplica as migrations se o banco de dados já existir
                    await dbContext.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // Log e manipulação de erros conforme necessário
                Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
            }
        }
    }
}
