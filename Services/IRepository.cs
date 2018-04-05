using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyApp.Entities;

namespace MyApp.Services
{
    public interface IRepository<T> where T: Entity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync<TParameter>(List<Expression<Func<T, TParameter>>> includeProperties);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync<TParameter>(Guid id, List<Expression<Func<T, TParameter>>> includeProperties);
        IQueryable<T> GetQueryable();
        IQueryable<T> GetQueryable<TParameter>(List<Expression<Func<T, TParameter>>> includeProperties);
        Task<T> AddAsync(T model);
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> modelCollection);
        Task<T> UpdateAsync(T model);
        Task<T> UpdateAsync(IEnumerable<T> modelCollection);
        Task<bool> RemoveAsync(T model);
        Task<bool> RemoveAsync(IEnumerable<T> modelCollection);
        
    }
}