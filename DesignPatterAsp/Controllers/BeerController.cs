using DesignPatternAsp.Models.ViewModels;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

      [HttpGet]
      public IActionResult Add()
      {
         GetBrandsData();
         return View();
      }

      [HttpPost]
      public IActionResult Add(FormBeerViewModel beerViewModel)
      {
         if (!ModelState.IsValid)
         {
            GetBrandsData();
            return View("Add", beerViewModel);
         }

         var beer = new Beer { Name = beerViewModel.Name, Style = beerViewModel.Style };

         if (beerViewModel.BrandId == null)
         {
            var brand = new Brand();
            brand.Name = beerViewModel.OtherBrand;
            brand.BrandId = Guid.NewGuid();
            beer.BrandId = brand.BrandId;
            _unitOfWork.Brand.Add(brand);
         }
         else
         {
            beer.BrandId = (Guid)beerViewModel.BrandId;
         }

         _unitOfWork.Beers.Add(beer);
         _unitOfWork.Save();

         return RedirectToAction("Index");
      }

      void GetBrandsData()
      {
         var brands = _unitOfWork.Brand.Get();
         ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
      }
   }
}
