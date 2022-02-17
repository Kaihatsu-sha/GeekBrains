using Kaihatsu.Timesheets.Core.Abstraction.Data;
using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.Core.Repository.Service
{
    public class RepositoryService<T> : IRepositoryService<T>
        where T : ItemBase
    {
        protected readonly AppDbContext _dbContext;
        public RepositoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)//TODO : Как вернуть созданную сущность? <T>
        {
            EntityEntry<T> entityEntry = await _dbContext.Set<T>().AddAsync(entity,cancellationToken);
            await _dbContext.SaveChangesAsync();
            //return entityEntry.Entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                T deleteEntity = _dbContext.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
                _dbContext.Remove(deleteEntity);
                _dbContext.SaveChanges();
            });
        }

        public async Task<IQueryable<T>> ReadAllAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _dbContext.Set<T>().AsQueryable());
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
