using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasbeServer.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private String ConnectionString = "";

        //CompanyDbContext in constructor ına componyıd parametresini verip bu parametreyi kullanıcıdan alıp 
        //verdiği şirekte göre connectionstring kullanacağız bu sayede farklı şirketlerin farklı veritabanları olabilecek
        public CompanyDbContext(string companyId, Company company = null)
        {
            if (company != null)
            {
                if (company.UserId == "")
                {
                    ConnectionString = $"Data Source={company.ServerName}; Initial " +
                 $"Catalog={company.DatabaseName};" +
                 $"Integrated Security=True;" +
                 $"Connect Timeout=30;" +
                 $"Encrypt=False;" +
                 $"Trust Server Certificate=True;" +
                 $"Application Intent=ReadWrite;" +
                 $"Multi Subnet Failover=False";
                }
                else
                {
                    ConnectionString = $"Data Source={company.ServerName}; " +
                        $"Initial " +
                    $"Catalog={company.DatabaseName};" +
                    $"User Id={company.UserId}; " +
                    $"Password = {company.Password};" +
                    $"Integrated Security=True;" +
                    $"Connect Timeout=30;" +
                    $"Encrypt=False;" +
                    $"Trust Server Certificate=True;" +
                    $"Application Intent=ReadWrite;" +
                    $"Multi Subnet Failover=False";
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        //OnModelCreating metodu sayesinde artık buraya dbset leri tek tek eklememizew gerek kalmıyor
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReferance).Assembly);
        }

        public class ComponyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            private readonly AppDbContext dbContext;
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext("");
            }
        }


    }
}
