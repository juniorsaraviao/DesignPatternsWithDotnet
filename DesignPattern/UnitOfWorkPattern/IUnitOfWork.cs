using DesignPattern.Models;
using DesignPattern.RepositoryPattern;

namespace DesignPattern.UnitOfWorkPattern
{
   public interface IUnitOfWork
   {
      public IRepository<Beer> Beers { get; }
      public IRepository<Brand> Brand { get; }
      public void Save();
   }
}
