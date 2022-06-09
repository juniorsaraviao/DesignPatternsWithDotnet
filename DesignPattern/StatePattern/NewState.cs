using System;

namespace DesignPattern.StatePattern
{
   public class NewState : IState
   {
      public void Action(CustomerContext customer, decimal amount)
      {
         Console.WriteLine($"Se le pone dinero a su saldo {amount}");
         customer.Residue = amount;
         customer.SetState(new NotDebtorState());
      }
   }
}
