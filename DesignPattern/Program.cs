using DesignPattern.DependencyInjectionPatterm;
using DesignPattern.FactoryPattern;
using DesignPattern.Models;
using DesignPattern.Singleton;
using System;
using System.Linq;

namespace DesignPattern
{
   class Program
   {
      static void Main(string[] args)
      {
         using (var context = new DesignPatternsContext())
         {
            var lst = context.Beers.ToList();
            foreach (var beer in lst)
            {
               Console.WriteLine(beer.Name);
            }
         }
      }

      void PreviousSession()
      {
         var log = Log.Instance;
         log.Save("a");
         log.Save("b");

         SaleFactory storeSaleFactory = new StoreSaleFactory(100);
         SaleFactory internetStoreSaleFactory = new InternetSaleFactory(2);

         ISale sale1 = storeSaleFactory.GetSale();
         sale1.Sell(15);

         ISale sale2 = internetStoreSaleFactory.GetSale();
         sale2.Sell(15);

         var beer = new DependencyInjectionPatterm.Beer("Pikantus", "Erdinger");
         var drinkWithBeer = new DrinkWithBeer(10, 1, beer);

         drinkWithBeer.Build();
      }
   }
}
