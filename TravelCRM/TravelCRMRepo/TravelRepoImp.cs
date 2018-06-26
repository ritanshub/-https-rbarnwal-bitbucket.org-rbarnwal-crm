using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelCRMEntities;
using System.Linq.Expressions;
using TravelCRMData;

namespace TravelCRMRepo
{
        public class Repository<T> : IRepository<T> where T : class   {
            private readonly ApplicationContext context;
            private DbSet<T> entities;
            string errorMessage = string.Empty;

            public Repository(ApplicationContext context)
            {
                this.context = context;
                entities = context.Set<T>();
            }

            public IEnumerable<T> GetAll()
            {
                return entities.AsEnumerable();
            }

            public T GetById(int id)
            {
              return entities.Find(id);
            }
            public void Insert(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Add(entity);
               
            }
            public void Delete(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Remove(entity);
              
            }
            public void Remove(T entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entities.Remove(entity);
            }
             public T Add(T t)
          {

            entities.Add(t);
            context.SaveChanges();
            return t;
          }

        public T Get(Expression<Func<T, bool>> where)
        {
            return entities.SingleOrDefault(where);
        }



        public void Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

       

       

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> match)
        {
            return entities.Where(match).ToList();
        }

        public void Update(T t, object key)
        {
            if (t == null)
                throw new ArgumentNullException("entity");

            T exist = entities.Find(key);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(t);

            }

        }


        //Below Methods should Not used .Willl be removed in future

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public T GetById(string id)
        {
            return entities.Find(id);
        }
    }
}



   




