using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using twin.CommonInterfaces;

namespace twin.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}
