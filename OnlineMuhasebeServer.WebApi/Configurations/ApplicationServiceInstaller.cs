
using MediatR;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(OnlineMuhasebeServer.Application.AssemblyReference).Assembly);
        }
    }
}
