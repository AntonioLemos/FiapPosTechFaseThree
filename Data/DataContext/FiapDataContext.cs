using Data.Mappings;
using Data.Util;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.DataContext
{
    public class FiapDataContext : DbContext
    {
        public DbSet<CONTATO> CONTATO { get; set; }
        public DbSet<DDD> DDD { get; set; }

        public FiapDataContext()
        {
        }

        public FiapDataContext(DbContextOptions<FiapDataContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "FiapPosTechApi");
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CONTATOMap());
            modelBuilder.ApplyConfiguration(new DDDMap());

            SeedData(modelBuilder);
        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if ((environment?.ToUpper() ?? "") == "Integracao-Test".ToUpper())
                modelBuilder.Entity<CONTATO>().HasData(ContatoList.contatos);

            modelBuilder.Entity<DDD>().HasData(DDDList.ddds);
        }

    }
}



