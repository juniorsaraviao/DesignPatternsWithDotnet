using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DesignPattern.BuilderPattern
{
   public class PreparedAlcoholicDrinkConcreteBuilder : IBuilder
   {
      private PreparedDrink _preparedDrink;

      public PreparedAlcoholicDrinkConcreteBuilder()
      {
         Reset();
      }

      public void AddIngredients(string ingredients)
      {
         if (_preparedDrink.Ingredients == null)
         {
            _preparedDrink.Ingredients = new List<string>();
         }

         _preparedDrink.Ingredients.Add(ingredients);
      }

      public void Mix()
      {
         string ingredients = _preparedDrink.Ingredients.Aggregate((i, j) => i + ", " + j);
         _preparedDrink.Result = $"Drink made with {_preparedDrink.Alcohol} alcohol and the following ingredients: {ingredients}";
         Console.WriteLine("Mixing ingredients");
      }

      public void Reset()
      {
         _preparedDrink = new PreparedDrink();
      }

      public void Rest(int time)
      {
         Thread.Sleep(time);
         Console.WriteLine("Ready to drink!");
      }

      public void SetAlcohol(decimal alcohol)
      {
         _preparedDrink.Alcohol = alcohol;
      }

      public void SetMilk(int milk)
      {
         _preparedDrink.Milk = milk;
      }

      public void SetWater(int water)
      {
         _preparedDrink.Water = water;
      }

      public PreparedDrink GetPreparedDrink()
      {
         return _preparedDrink;
      }
   }
}
