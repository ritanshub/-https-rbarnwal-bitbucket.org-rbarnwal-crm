using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TravelCRMEntities;

//public interface IRepository<T> where T : BaseEntities
//{
//    IEnumerable<T> GetAll();
//    T Get(long id);
//    void Insert(T entity);
//    void Update(T entity);
//    void Delete(T entity);
//    void Remove(T entity);
//    void SaveChanges();
//}


public interface IRepository<T> where T : class
{
    // Marks an entity as new
     T Add(T entity);
    // Marks an entity as modified
    // void Update(T entity);

     void Update(T t, object key);
    // Marks an entity to be removed
    void Delete(T entity);
    void Delete(Expression<Func<T, bool>> where);
    // Get an entity by int id
    T GetById(int id);
    // Get an entity using delegate

    T GetById(string id);
    T Get(Expression<Func<T, bool>> where);
    // Gets all entities of type T
    IEnumerable<T> GetAll();
    // Gets entities using delegate
    IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

    
    
}