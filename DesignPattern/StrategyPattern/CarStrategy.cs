using System;

namespace DesignPattern.StrategyPattern
{
   public class CarStrategy : IStrategy
   {
      public void Run()
      {
         Console.WriteLine("I'm a car and I move with 4 wheels");
      }
   }
}
