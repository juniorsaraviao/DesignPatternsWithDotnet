using DesignPattern.Models;
using System.Collections.Generic;

namespace DesignPattern.RepositoryPattern
{
   public interface IBeerRepository
   {
      IEnumerable<Beer> Get();
      Beer Get(int id);
      void Add(Beer data);
      void Delete(int id);
      void Update(Beer data);

      void Save();
   }
}
