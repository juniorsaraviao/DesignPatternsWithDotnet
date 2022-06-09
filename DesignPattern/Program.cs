using DesignPattern.BuilderPattern;
using DesignPattern.DependencyInjectionPatterm;
using DesignPattern.FactoryPattern;
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using DesignPattern.Singleton;
using DesignPattern.StatePattern;
using DesignPattern.StrategyPattern;
using DesignPattern.UnitOfWorkPattern;
using System;
using System.Linq;

namespace DesignPattern
{
   class Program
   {
      static void Main(string[] args)
      {
         var customerContext = new CustomerContext();
         Console.WriteLine(customerContext.GetState());
         customerContext.Request(100);
         Console.WriteLine(customerContext.GetState());

         customerContext.Request(50);
         Console.WriteLine(customerContext.GetState());

         customerContext.Request(100);
         Console.WriteLine(customerContext.GetState());

         customerContext.Request(50);
         Console.WriteLine(customerContext.GetState());

         customerContext.Request(50);
         Console.WriteLine(customerContext.GetState());
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

      void WorkWithEntityFramework()
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

      void WorkWithContext()
      {
         using (var context = new DesignPatternsContext())
         {
            var beerRepository = new BeerRepository(context);
            var beer = new Models.Beer
            {
               Name = "Cristal",
               Style = "Blonde"
            };
            beerRepository.Add(beer);
            beerRepository.Save();

            foreach (var b in beerRepository.Get())
            {
               Console.WriteLine(b.Name);
            }
         }
      }

      void WorkWithRepository()
      {
         using (var context = new DesignPatternsContext())
         {
            var beerRepository = new Repostitory<Models.Beer>(context);
            //var beer = new Models.Beer { Name = "Fuller", Style = "Strong Ale" };
            //beerRepository.Add(beer);
            beerRepository.Delete(5);
            beerRepository.Save();

            foreach (var b in beerRepository.Get())
            {
               Console.WriteLine(b.Name);
            }

            var brandRepository = new Repostitory<Brand>(context);
            var brand = new Brand { Name = "Fuller" };
            brandRepository.Add(brand);
            brandRepository.Save();

            foreach (var b in brandRepository.Get())
            {
               Console.WriteLine(b.Name);
            }

         }

         void WorkWithUnitOfWork()
         {
            using (var context = new DesignPatternsContext())
            {
               var unitOfWork = new UnitOfWork(context);
               var beers = unitOfWork.Beers;
               var beer = new Models.Beer { Name = "Cuzqueña", Style = "Porter" };
               beers.Add(beer);

               var brands = unitOfWork.Brand;
               var brand = new Models.Brand { Name = "Ambev" };
               brands.Add(brand);

               unitOfWork.Save();
            }
         }

         void WorkWithStrategy()
         {
            var context = new Context(new CarStrategy());
            context.Run();
            context.Strategy = new MotocycleStrategy();
            context.Run();
            context.Strategy = new BicycleStrategy();
            context.Run();
         }

         void WorkWithBuider()
         {
            var builder = new PreparedAlcoholicDrinkConcreteBuilder();
            var barmanDirector = new BarmanDirector(builder);

            barmanDirector.MakePinappleDrink();

            var preparedDrink = builder.GetPreparedDrink();
            Console.WriteLine(preparedDrink.Result);
         }
      }
   }
}
