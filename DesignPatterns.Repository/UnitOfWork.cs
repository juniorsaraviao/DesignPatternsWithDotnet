using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
   public class UnitOfWork : IUnitOfWork
   {
      private DesignPatternsContext _context;

      public UnitOfWork(DesignPatternsContext context)
      {
         _context = context;
      }

      public IRepository<Beer> _beers;
      public IRepository<Brand> _brand;
      public IRepository<Beer> Beers
      {
         get
         {
            return _beers ??= new Repository<Beer>(_context);
         }
      }

      public IRepository<Brand> Brand
      {
         get
         {
            return _brand ??= new Repository<Brand>(_context);
         }
      }

      public void Save()
      {
         _context.SaveChanges();
      }
   }
}
