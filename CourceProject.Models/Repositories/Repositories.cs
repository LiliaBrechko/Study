using CourseProject.DAL.EF_Infrastructure;
using CourseProject.DAL.IRepositories;
using CourseProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        public int Create(T entity)
        {
            using (var contex = new DB_Configuration())
            {
                contex.Add(entity);
                contex.SaveChanges();
                return entity.ID;

            }
                
        }

        public void Delete(params int[] id)
        {
            using (var contex = new DB_Configuration())
            {
                foreach (var entityID in id)
                {
                    var entityToRemove = contex.Set<T>().FirstOrDefault(x => x.ID == entityID);
                    contex.Remove(entityToRemove);
                    contex.SaveChanges();
                }
            }
            
        }

        public T Get(int id)
        {
            using(var contex = new DB_Configuration())
            {
                return  contex.Set<T>().FirstOrDefault(x => x.ID == id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using(var contex = new DB_Configuration())
            {
                return contex.Set<T>().ToList();
            }
        }

        public void Update(int id, T entity)
        {
            using(var context  = new DB_Configuration())
            {
                var entityToUpdate = context.Set<T>().FirstOrDefault(x =>x.ID == id);
                context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                context.SaveChanges();

            }
        }
    }
}
