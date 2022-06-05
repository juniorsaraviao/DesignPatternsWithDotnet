using System;

namespace DesignPattern.StrategyPattern
{
   public class MotocycleStrategy : IStrategy
   {
      public void Run()
      {
         Console.WriteLine("I'm a motocycle and I move with 2 wheels");
      }
   }
}
