namespace DesignPattern.StatePattern
{
   public class CustomerContext
   {
      private IState _state;
      private decimal _residue;

      public CustomerContext()
      {

      }

      public void SetState(IState state)
      {
         _state = state;
      }

      public IState GetState()
      {
         return _state;
      }

      public void Request(decimal amount)
      {
         _state.Action(this, amount);
      }

      public void Discount(decimal amount)
      {
         _residue -= amount;
      }
   }
}
