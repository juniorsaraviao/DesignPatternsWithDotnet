using System;

namespace DesignPattern.StrategyPattern
{
   public class BicycleStrategy : IStrategy
   {
      public void Run()
      {
         Console.WriteLine("I'm a bicycle and I move with 2 wheels");
      }
   }
}
