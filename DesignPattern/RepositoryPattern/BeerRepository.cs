using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.RepositoryPattern
{
   public class BeerRepository : IBeerRepository
   {
      private readonly DesignPatternsContext _context;

      public BeerRepository(DesignPatternsContext context)
      {
         _context = context;
      }

      public void Add(Beer data)
      {
         _context.Beers.Add(data);
      }

      public void Delete(int id)
      {
         var beer = _context.Beers.Find(id);
         _context.Beers.Remove(beer);
      }

      public IEnumerable<Beer> Get()
      {
         return _context.Beers.ToList();
      }

      public Beer Get(int id)
      {
         return _context.Beers.Find(id);
      }

      public void Update(Beer data)
      {
         _context.Entry(data).State = EntityState.Modified;
      }

      public void Save()
      {
         _context.SaveChanges();
      }      
   }
}
