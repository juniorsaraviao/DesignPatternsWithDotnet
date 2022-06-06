using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BuilderPattern
{
   public class BarmanDirector
   {
      private IBuilder _builder;

      public BarmanDirector(IBuilder builder)
      {
         _builder = builder;
      }

      public void SetBuilder(IBuilder builder)
      {
         _builder = builder;
      }

      public void MakeMargarita()
      {
         _builder.Reset();
         _builder.SetAlcohol(9);
         _builder.SetWater(30);
         _builder.AddIngredients("2 lemons");
         _builder.AddIngredients("10 grams of salt");
         _builder.AddIngredients("1/2 cup of Tequila");
         _builder.AddIngredients("3/4 cups of orange alcohol");
         _builder.AddIngredients("4 cubs of ice");
         _builder.Mix();
         _builder.Rest(1000);
      }

      public void MakePinappleDrink()
      {
         _builder.Reset();
         _builder.SetAlcohol(20);
         _builder.SetWater(10);
         _builder.SetMilk(500);
         _builder.AddIngredients("1/2 cup of ron");
         _builder.AddIngredients("1/2 cream of coconut");
         _builder.AddIngredients("3/4 cups of pinapple juice");
         _builder.Mix();
         _builder.Rest(2000);
      }
   }
}
