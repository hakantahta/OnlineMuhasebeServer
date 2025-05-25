using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebeServer.Domain
{
    public interface IUnitOfWork
    {
        void CreateDbContextInstance(DbContext context);

        Task<int> SaveChangesAsync();
    }
}
