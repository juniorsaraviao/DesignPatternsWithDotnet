using System.Collections.Generic;

namespace DesignPattern.BuilderPattern
{
   public class PreparedDrink
   {
      public List<string> Ingredients = new List<string>();
      public int Milk;
      public int Water;
      public decimal Alcohol;

      public string Result;
   }
}
