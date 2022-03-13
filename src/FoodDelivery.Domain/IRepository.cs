using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Domain
{
    public interface IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task<TEntity> FindById(Guid id);
        Task<List<TEntity>> FindAll();
        Task<TEntity> Add(TEntity entity);
        Task<Guid> Remove(Guid id);
    }
}
