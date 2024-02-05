using Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Boopstrap
{
    public static class ScopedServicesRegister
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            var scopedServices = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IScopedService).IsAssignableFrom(x)).ToList();

            var scopedServicesImplementations = scopedServices.Where(x => x.IsClass && !x.IsAbstract);
            var scopedServicesInterfaces = scopedServices.Where(x => x.IsInterface);

            foreach (var scopedServiceImplementation in scopedServicesImplementations)
            {
                var serviceInterface = scopedServicesInterfaces.FirstOrDefault(x => x.Name == $"I{scopedServiceImplementation.Name}");

                if (serviceInterface == null)
                {
                    continue;
                }

                services.AddTransient(serviceInterface, scopedServiceImplementation);
            }

            return services;
        }
    }
}
