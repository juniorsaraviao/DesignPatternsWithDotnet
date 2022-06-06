using DesignPatternAsp.Models.ViewModels;
using DesignPatterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternAsp.Strategies
{
   public class BeerContext
   {
      private IBeerStrategy _strategy;

      public IBeerStrategy Strategy
      {
         set
         {
            _strategy = value;
         }
      }

      public BeerContext(IBeerStrategy strategy)
      {
         _strategy = strategy;
      }

      public void Add(FormBeerViewModel viewModel, IUnitOfWork unitOfWork)
      {
         _strategy.Add(viewModel, unitOfWork);
      }
   }
}
