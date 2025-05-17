using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    //CQRS Pattern'ın request kısımlarından biri
    public sealed class CreateCompanyRequest : IRequest<CreateCompanyResponse>
    {
        public String Name { get; set; }

        //veritabanı bilgileri
        public String ServerName { get; set; }
        public String DatabaseName { get; set; }
        public String UserId { get; set; }
        public String Password { get; set; }
    }
}
