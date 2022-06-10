using DesignPatterAsp.Models;
using DesignPatternAsp.Configuration;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using Tools;

namespace DesignPatterAsp.Controllers
{
   public class HomeController : Controller
   {
      private readonly IOptions<MyConfig> _config;
      private readonly IRepository<Beer> _repository;
      public HomeController(IOptions<MyConfig> config, IRepository<Beer> repository)
      {
         _config = config;
         _repository = repository;
      }

      public IActionResult Index()
      {
         Log.GetInstance( _config.Value.PathLog ).Save("Entró a index");
         IEnumerable<Beer> lst = _repository.Get();

         return View("Index", lst);
      }

      public IActionResult Privacy()
      {
         Log.GetInstance( _config.Value.PathLog ).Save("Entró a Privacy");
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
