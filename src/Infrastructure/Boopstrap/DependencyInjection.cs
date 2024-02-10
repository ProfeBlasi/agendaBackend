using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var cone = "Data Source = NB101025; Initial Catalog = Phonebook; Integrated Security = True; TrustServerCertificate=True";
            //"workstation id=mateBlasi.mssql.somee.com;packet size=4096;user id=profeblasi_SQLLogin_1;pwd=77i4e5baeu;data source=mateBlasi.mssql.somee.com;persist security info=False;initial catalog=mateBlasi;TrustServerCertificate=True";
            services.AddDbContext<Context>(op =>
            {
                op.UseSqlServer(cone);
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
