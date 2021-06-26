using GSalvi.Template.Domain.SeedWork.Models;
using System;
using System.Threading.Tasks;

namespace GSalvi.Template.Domain.SeedWork.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity<TEntity>, IAggregateRoot
    {
        Task AddAsync(TEntity obj);
        Task UpdateAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(Guid id);
    }
}