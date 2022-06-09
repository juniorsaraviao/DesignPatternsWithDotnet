using System;

namespace DesignPattern.StatePattern
{
   public class DebtorState : IState
   {
      public void Action(CustomerContext customer, decimal amount)
      {
         Console.WriteLine("you cannot buy things");
      }
   }
}
