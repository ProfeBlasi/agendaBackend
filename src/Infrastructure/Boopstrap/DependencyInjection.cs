using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var cone = "workstation id=mateBlasi.mssql.somee.com;packet size=4096;user id=profeblasi_SQLLogin_1;pwd=77i4e5baeu;data source=mateBlasi.mssql.somee.com;persist security info=False;initial catalog=mateBlasi;TrustServerCertificate=True";
            services.AddDbContext<Context>(op =>
            {
                op.UseSqlServer(cone);
            });
            services.AddScopedServices();
            return services;
        }
    }
}
