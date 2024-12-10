using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.IRepositories
{

        public interface IRepository<T> where T : class, IEntity
        {
            int Create(T entity);
            void Update(T entity);
            void Delete(params int[] id);
            T Get(int id, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null);
            IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null);

        }
    
}
