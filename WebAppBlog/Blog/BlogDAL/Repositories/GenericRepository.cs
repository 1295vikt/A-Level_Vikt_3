using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T item);
        T FindById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> QueryAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        void RemoveById(int id);
        void Remove(T item);
        void Update(T item);
        void Dispose();
    }

    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        readonly DbContext _context;
        readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> QueryAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public void RemoveById(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));           
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
