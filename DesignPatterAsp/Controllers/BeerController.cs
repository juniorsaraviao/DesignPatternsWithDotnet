using DesignPatternAsp.Models.ViewModels;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternAsp.Controllers
{
   public class BeerController : Controller
   {
      private readonly IUnitOfWork _unitOfWork;

      public BeerController(IUnitOfWork unitOfWork)
      {
         _unitOfWork = unitOfWork;
      }

      public IActionResult Index()
      {
         IEnumerable<BeerViewModel> beers = _unitOfWork.Beers.Get().Select(x => new BeerViewModel { Id = x.BeerId, Name = x.Name, Style = x.Style });
         return View("Index", beers);
      }
   }
}
