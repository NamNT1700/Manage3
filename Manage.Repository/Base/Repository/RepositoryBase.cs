using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Base.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DatabaseContext _context;
        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
            await _context.SaveChangesAsync();
        }
    }
}
