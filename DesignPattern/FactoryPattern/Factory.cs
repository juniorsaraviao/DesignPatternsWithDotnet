using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
   // Creator
   public abstract class SaleFactory
   {
      public abstract ISale GetSale();
   }

   // Concrete creator

   public class InternetSaleFactory : SaleFactory
   {
      private decimal _discount;

      public InternetSaleFactory(decimal discount)
      {
         _discount = discount;
      }

      public override ISale GetSale()
      {
         return new InternetSale(_discount);
      }
   }

   public class StoreSaleFactory : SaleFactory
   {
      private decimal _extra;

      public StoreSaleFactory(decimal extra)
      {
         _extra = extra;
      }

      public override ISale GetSale()
      {
         return new StoreSale(_extra);
      }
   }

   // Concret product

   public class InternetSale : ISale
   {
      private decimal _discount;

      public InternetSale(decimal discount)
      {
         _discount = discount;
      }

      public void Sell(decimal total)
      {
         Console.WriteLine($"Venta en tienda - total: {total - _discount}");
      }
   }

   public class StoreSale : ISale
   {
      private decimal _extra;

      public StoreSale(decimal extra)
      {
         _extra = extra;
      }

      public void Sell(decimal total)
      {
         Console.WriteLine($"Venta en tienda - total: {total + _extra}");
      }
   }

   // Producto
   public interface ISale
   {
      public void Sell(decimal total);
   }
}
