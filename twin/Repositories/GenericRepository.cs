using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using twin.Data;
using twin.CommonInterfaces;

namespace twin.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        private readonly ApplicationDbContext m_DbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            m_DbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return m_DbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await m_DbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await m_DbContext.Set<TEntity>().AddAsync(entity);
            await m_DbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            m_DbContext.Set<TEntity>().Remove(entity);
            await m_DbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            m_DbContext.Set<TEntity>().Update(entity);
            await m_DbContext.SaveChangesAsync();
        }
    }
}
