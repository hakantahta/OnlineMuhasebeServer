using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.AppEntities
{
    public sealed class Company : Entity
    {
        public String Name { get; set; }
        public String? Address { get; set; }
        public String? IdentityNumber { get; set; }
        public String? TaxDepartment { get; set; }
        public String? Tel { get; set; }
        public String? Email { get; set; }

        //veritabanı bilgileri
        public String ServerName { get; set; }
        public String DatabaseName { get; set; }
        public String ServerUserId { get; set; }
        public String ServerPassword { get; set; }
       
    }
}
