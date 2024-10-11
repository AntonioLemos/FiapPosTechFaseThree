using Data.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace DeletaAPIIntegrationTest
{
    internal class FiapPostTechIntegrationTestFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var connString = "Server=localhost;Database=Fiap-db-teste;User Id=sa;Password=#sa123456789;TrustServerCertificate=True;";

            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<FiapDataContext>));
                services.AddDbContext<FiapDataContext>(options =>
                    options.UseSqlServer(connString, sqlServerOptions =>
                        sqlServerOptions.EnableRetryOnFailure()
                    ), ServiceLifetime.Scoped);

                using (var serviceProvider = services.BuildServiceProvider())
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        Environment.SetEnvironmentVariable("CI", "true");

                        var scopedServices = scope.ServiceProvider;
                        var cbContext = scopedServices.GetRequiredService<FiapDataContext>();
                        try
                        {
                            cbContext.Database.EnsureDeleted();
                            cbContext.Database.EnsureCreated();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while deleting the database: {ex.Message}");
                            throw;
                        }
                    }
                }
            });
        }
    }
}
