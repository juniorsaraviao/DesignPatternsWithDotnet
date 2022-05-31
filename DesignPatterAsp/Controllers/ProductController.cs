using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Earn;

namespace DesignPatternAsp.Controllers
{
   public class ProductController : Controller
   {
      private readonly EarnFactory _localEarnFactory;
      private readonly EarnFactory _foreignEarnFactory;

      public ProductController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignEarnFactory)
      {
         _localEarnFactory   = localEarnFactory;
         _foreignEarnFactory = foreignEarnFactory;
      }

      public IActionResult Index(decimal total)
      {
         // factory
         // LocalEarnFactory   localEarnFactory   = new LocalEarnFactory(0.20m);
         // ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

         // products
         var localEarn   = _localEarnFactory.GetEarn();
         var foreignEarn = _foreignEarnFactory.GetEarn();

         // total
         ViewBag.totalLocal   = total + localEarn.Earn(total);
         ViewBag.totalForeign = total + foreignEarn.Earn(total);

         return View();
      }
   }
}
