﻿using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
   public interface IUnitOfWork
   {
      public IRepository<Beer> Beers { get; }
      public IRepository<Brand> Brand { get; }
      public void Save();
   }
}
