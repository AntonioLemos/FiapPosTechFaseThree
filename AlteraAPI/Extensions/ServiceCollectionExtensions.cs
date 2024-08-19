using System.Reflection;
using AlteraAPI.Business;
using AlteraAPI.Business.Interface;
using AlteraAPI.Repository;
using AlteraAPI.Repository.Interface;
using Domain.Models;

namespace AlteraAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGenericServices(this IServiceCollection services, Assembly assembly)
        {
            RepositoriesGeneric(services);
            Business(services);
        }

        private static void RepositoriesGeneric(IServiceCollection services)
        {
            var repositoryMappings = new List<(Type InterfaceType, Type ImplementationType)>
            {
                (typeof(IRepository<CONTATO>), typeof(Repository<CONTATO>)),
                (typeof(IRepository<DDD>), typeof(Repository<DDD>)),
                (typeof(IDDDRepository), typeof(DDDRepository)),
                (typeof(IContatoRepository), typeof(ContatoRepository)),
            };

            foreach (var mapping in repositoryMappings)
            {
                services.AddScoped(mapping.InterfaceType, mapping.ImplementationType);
            }
        }
        private static void Business(IServiceCollection services)
        {
            var repositoryMappings = new List<(Type InterfaceType, Type ImplementationType)>
            {
                (typeof(IContatoBusiness), typeof(ContatoBusiness)),
                (typeof(IDDDBusiness), typeof(DDDBusiness)),
            };

            foreach (var mapping in repositoryMappings)
            {
                services.AddScoped(mapping.InterfaceType, mapping.ImplementationType);
            }
        }
    }
}
