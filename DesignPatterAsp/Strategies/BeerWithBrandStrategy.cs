using DesignPatternAsp.Models.ViewModels;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using System;

namespace DesignPatternAsp.Strategies
{
   public class BeerWithBrandStrategy : IBeerStrategy
   {
      public void Add(FormBeerViewModel beerViewModel, IUnitOfWork unitOfWork)
      {
         var beer = new Beer { Name = beerViewModel.Name, Style = beerViewModel.Style };

         var brand = new Brand { Name = beerViewModel.OtherBrand, BrandId = Guid.NewGuid() };
         beer.BrandId = brand.BrandId;

         unitOfWork.Brand.Add(brand);
         unitOfWork.Beers.Add(beer);

         unitOfWork.Save();
      }
   }
}
