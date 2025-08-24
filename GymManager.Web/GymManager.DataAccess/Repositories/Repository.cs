using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, new()
    {

        private readonly GymManagerContext _gymManagerContext;

        protected GymManagerContext Context { get => _gymManagerContext; }


        public Repository(GymManagerContext gymManagerContext) {
            _gymManagerContext= gymManagerContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(   $"{nameof(entity)} entity must not be null" );
            }

            try
            {

                await _gymManagerContext.AddAsync(entity);
                await _gymManagerContext.SaveChangesAsync();

                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception( nameof(entity) + "Could not be saved" );
            }

        }

        public virtual async Task DeleteAsync(TId id)
        {
            var entity = await _gymManagerContext.FindAsync<TEntity>(id);
            _gymManagerContext.Remove<TEntity>(entity);
            await _gymManagerContext.SaveChangesAsync();

        }

        public virtual async Task<TEntity> GetAsync(TId id)
        {
            var entity = await _gymManagerContext.FindAsync<TEntity>(id);
            return entity;
        }

        public virtual IQueryable<TEntity> GetAllAsync()
        {
            try
            {
                return _gymManagerContext.Set<TEntity>();
            }
            catch(Exception ex)
            {
                throw new Exception ( $"Couldn´t retrieve entities: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} entity must not be null");
            }

            try
            {

                 _gymManagerContext.Update(entity);
                await _gymManagerContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(nameof(entity) + "Could not be saved");
            }
        }
    }
}
