using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.RepoBase
{
    public interface IDbRepository : IDisposable
    {
        Task<T> AddAsync<T>(T entity) where T : class;
        T Add<T>(T entity) where T : class;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<int> CountAllAsync<T>() where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class;
        void DeleteRange<T>(IEnumerable<T> entities) where T : class;
        Task DeleteByIdAsync<T>(int id) where T : class;
        Task<T> FindByIdAsync<T>(int id) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class;
    }
}