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

namespace CourseProject.DAL.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class, IEntity
    {
        public int Create(T entity)
        {
            using var context = new DB_Configuration();
            context.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

        public void Delete(params int[] id)
        {
            using var context = new DB_Configuration();
            foreach (var entityID in id)
            {
                var entityToRemove = context.Set<T>().First(x => x.ID == entityID);
                context.Remove(entityToRemove);
                context.SaveChanges();
            }

        }

        public void Dispose()
        {
            using var context = new DB_Configuration();
            context.Dispose();
        }

        public T Get(int id, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null)
        {
            using var context = new DB_Configuration();
                IQueryable<T> query = context.Set<T>();

            if (includeFunc != null)
            {
                query = includeFunc(query);
            }

            return query.First(x => x.ID == id);

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            using (var context = new DB_Configuration())
            {
                IQueryable<T> set = context.Set<T>();

                if(predicate != null)
                {
                    set = set.Where(predicate);
                }

                return set.ToArray();
            }
        }

        public void Update(T entity)
        {
            using (var context = new DB_Configuration())
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();

            }

        }
    }
}
