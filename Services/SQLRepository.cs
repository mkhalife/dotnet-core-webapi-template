using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Entities;
using MyApp.Infrastructure;

namespace MyApp.Services
{
    public class SQLRepository<T> : IRepository<T> where T: Entity
    {
        private MyAppContext _context;

        public SQLRepository(MyAppContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T model)
        {
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> modelCollection)
        {
            try
            {
                await _context.AddRangeAsync(modelCollection);
                await _context.SaveChangesAsync();
                return modelCollection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync<TParameter>(List<Expression<Func<T, TParameter>>> includeProperties)
        {
            var query = GetQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync<TParameter>(Guid id, List<Expression<Func<T, TParameter>>> includeProperties)
        {
            var query = GetQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(x => x.Id == id).FirstAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetQueryable<TParameter>(List<Expression<Func<T, TParameter>>> includeProperties)
        {
            var query = GetQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public async Task<bool> RemoveAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAsync(IEnumerable<T> modelCollection)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(IEnumerable<T> modelCollection)
        {
            throw new NotImplementedException();
        }
    }
}
