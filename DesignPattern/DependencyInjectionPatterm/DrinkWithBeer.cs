using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DependencyInjectionPatterm
{
   public class DrinkWithBeer
   {
      private Beer    _beer;
      private decimal _water;
      private decimal _sugar;

      public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
      {
         _water = water;
         _sugar = sugar;
         _beer  = beer;
      }

      public void Build()
      {
         Console.WriteLine($"Preparamos la bebida que tiene agua {_water} + azucar {_sugar} y cerveza {_beer.Name}");
      }
   }
}
