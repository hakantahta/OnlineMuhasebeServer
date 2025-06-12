using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasbeServer.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private String ConnectionString = "";

        //CompanyDbContext in constructor ına componyıd parametresini verip bu parametreyi kullanıcıdan alıp 
        //verdiği şirekte göre connectionstring kullanacağız bu sayede farklı şirketlerin farklı veritabanları olabilecek
        public CompanyDbContext(Company company = null)
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
                return new CompanyDbContext();
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate).
                        CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate).
                        CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


    }
}
