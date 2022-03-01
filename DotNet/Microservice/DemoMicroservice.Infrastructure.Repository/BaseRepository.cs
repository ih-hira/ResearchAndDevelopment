using DemoMicroservice.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoMicroservice.Infrastructure.Repository
{
    public class BaseRepository<TDbContext, T> : IBaseRepository<T> where T : class where TDbContext : DbContext
    {
        protected readonly TDbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context as TDbContext;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
    }
}
