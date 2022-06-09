using System;

namespace DesignPattern.StatePattern
{
   public class NotDebtorState : IState
   {
      public void Action(CustomerContext customer, decimal amount)
      {
         if (amount <= customer.Residue)
         {
            customer.Discount(amount);
            Console.WriteLine($"Request accepted, spend {amount} dollars and your residue is {customer.Residue}.");
            if (customer.Residue <= 0)
            {
               customer.SetState(new DebtorState());
            }
         }
         else
         {
            Console.WriteLine($"Operation not executed, you have {customer.Residue} dollars and the cost of the object is {amount} dollars.");
         }
      }
   }
}
