using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Data.Repositories
{
    /// <summary>
    /// Repository abstraction to allow for an intermediate layer between the Infrastructure and Application layers
    /// </summary>
    /// <typeparam name="TEntity">A BaseEntity model that exists within the FactoryContext</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly FactoryContext _context;
        protected readonly DbSet<TEntity> _currentSet;

        protected Repository(FactoryContext context)
        {
            _context = context;
            _currentSet = _context.Set<TEntity>();
        }
        
       

        public Task<long> GetAllCountAsync() => _currentSet.LongCountAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _currentSet.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id)
            => await _currentSet.FindAsync(id);

        public virtual async Task<TEntity> GetByIdAsync(long id)
            => await _currentSet.FindAsync(id);

        public virtual async Task InsertAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.AddRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            _currentSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _currentSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _currentSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}