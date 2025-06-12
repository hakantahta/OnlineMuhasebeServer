using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount : Entity
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public Char Type { get; set; } //Ana Grup, Grup, Muavin
    }
}
