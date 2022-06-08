namespace DesignPattern.StatePattern
{
   public interface IState
   {
      public void Action(CustomerContext customer, decimal amount);
   }
}
