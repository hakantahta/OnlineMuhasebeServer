
using Microsoft.EntityFrameworkCore;
using OnlineMuhasbeServer.Persistance.Context;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(SectionName)));

            services.AddIdentity<AppUser, AppRole>().
                            AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(OnlineMuhasbeServer.Persistance.AssemblyReferance).Assembly);
        }
    }
}
