using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.RepoBase
{
    public abstract class DbRepository : IDbRepository
    {
        public DbContext _dbContext;

        public DbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public T Add<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<int> CountAllAsync<T>() where T : class
        {
            var result = 0;
            result = await _dbContext.Set<T>().CountAsync();
            return result;
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove((T)entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove((T)entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync<T>(int id) where T : class
        {
            var entity = await _dbContext.Set<T>().Where(x => ((IEntity)x).Id == id).FirstOrDefaultAsync();
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        public async Task<T> FindByIdAsync<T>(int id) where T : class
        {
            var entity = await _dbContext.Set<T>().Where(x => ((IEntity)x).Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var target = await _dbContext.Set<T>().FirstOrDefaultAsync(x => ((IEntity)x).Id == ((IEntity)entity).Id);
            if (target != null)
            {
                _dbContext.Entry(target).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public void Update<T>(T entity) where T : class
        {
            var target = _dbContext.Set<T>().FirstOrDefault(x => ((IEntity)x).Id == ((IEntity)entity).Id);
            if (target != null)
            {
                _dbContext.Entry(target).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }

        public async Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below.
                // set large fields to null.

                disposedValue = true;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AccountRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion

    }
}