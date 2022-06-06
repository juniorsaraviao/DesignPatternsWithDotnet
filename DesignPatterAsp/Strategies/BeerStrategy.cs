using DesignPatternAsp.Models.ViewModels;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using System;

namespace DesignPatternAsp.Strategies
{
   public class BeerStrategy : IBeerStrategy
   {
      public void Add(FormBeerViewModel beerViewModel, IUnitOfWork unitOfWork)
      {
         var beer = new Beer { Name = beerViewModel.Name, Style = beerViewModel.Style, BrandId = (Guid)beerViewModel.BrandId };

         unitOfWork.Beers.Add(beer);
         unitOfWork.Save();
      }
   }
}
