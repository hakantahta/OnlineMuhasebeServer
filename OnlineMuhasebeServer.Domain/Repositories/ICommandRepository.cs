using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories
{
    public interface ICommandRepository<T> : IRepository<T>
        where T : Entity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task RemoveById(String id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
