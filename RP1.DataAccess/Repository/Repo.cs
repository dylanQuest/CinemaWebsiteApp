using Microsoft.EntityFrameworkCore;
using RP1.DataAccess.DataAccess;

namespace RP1.DataAccess.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly AppDBContext _dbContext;
        public DbSet<T> dbSet;
        public Repo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public T? Get(int id)
        {
            if (id == 0)
                return null;
            else
                return dbSet.Find(id);
        }


        public IEnumerable<T> GetAll()
        {
            IQueryable<T> list = dbSet;
            return list.ToList();
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}