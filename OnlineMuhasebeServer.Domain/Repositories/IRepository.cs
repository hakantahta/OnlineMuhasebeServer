using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void CreateDbContextInstance(DbContext context);
        DbSet<T> Entity { get; set; }
    }
}
