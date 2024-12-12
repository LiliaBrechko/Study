using CourseProject.DAL.EF_Infrastructure;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CourseProject.DAL.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class, IEntity
    {
        private readonly DB_Configuration context;

        public Repository(DB_Configuration context)
        {
            this.context = context;
        }

        public int Create(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

        public void Delete(params int[] id)
        {
            foreach (var entityID in id)
            {
                var entityToRemove = context.Set<T>().First(x => x.ID == entityID);
                context.Remove(entityToRemove);
                context.SaveChanges();
            }

        }

        public void Dispose()
        {
            context.Dispose();
        }

        public T Get(int id, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includeFunc != null)
            {
                query = includeFunc(query);
            }

            return query.FirstOrDefault(x => x.ID == id);

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null)
        {
            IQueryable<T> set = context.Set<T>();

            if (predicate != null)
            {
                set = set.Where(predicate);
            }

            if (includeFunc != null)
            {
                set = includeFunc(set);
            }

            return set.ToArray();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
