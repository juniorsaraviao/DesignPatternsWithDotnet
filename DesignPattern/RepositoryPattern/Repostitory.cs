using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.RepositoryPattern
{
   public class Repostitory<TEntity> : IRepository<TEntity> where TEntity : class
   {
      private readonly DesignPatternsContext _context;
      private readonly DbSet<TEntity> _dbSet;

      public Repostitory(DesignPatternsContext context)
      {
         _context = context;
         _dbSet = context.Set<TEntity>();
      }

      public void Add(TEntity data)
      {
         _dbSet.Add(data);
      }

      public void Delete(int id)
      {
         var dataToDelete = _dbSet.Find(id);
         _dbSet.Remove(dataToDelete);
      }

      public IEnumerable<TEntity> Get()
      {
         return _dbSet.ToList();
      }

      public TEntity Get(int id)
      {
         return _dbSet.Find(id);
      }

      public void Save()
      {
         _context.SaveChanges();
      }

      public void Update(TEntity data)
      {
         _dbSet.Attach(data);
         _context.Entry(data).State = EntityState.Modified;
      }
   }
}
