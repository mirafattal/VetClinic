using Microsoft.EntityFrameworkCore;
using Vet_DAL.Models;

namespace VetClinic.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection addDb(this IServiceCollection service, ConfigurationManager config)
        {
            var ConnectionString = config.GetConnectionString("DefaultConnection");

            service.AddDbContext<VetClinicContext>(options =>
                                 options.UseSqlServer(ConnectionString));
            return service;
        }
    }
}
