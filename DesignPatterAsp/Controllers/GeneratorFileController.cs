using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Tools.Generator;

namespace DesignPatternAsp.Controllers
{
   public class GeneratorFileController : Controller
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly GeneratorConcreteBuilder _generatorConcreteBuilder;

      public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
      {
         _unitOfWork = unitOfWork;
         _generatorConcreteBuilder = generatorConcreteBuilder;
      }

      public IActionResult Index()
      {
         return View();
      }

      public IActionResult CreateFile(int optionFile)
      {
         try
         {
            var beers = _unitOfWork.Beers.Get();
            var content = beers.Select(x => x.Name).ToList();
            var path = $"file{DateTime.Now.Ticks}{new Random().Next(1000)}.txt";
            var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

            if (optionFile == 1)
            {
               generatorDirector.CreateSimpleJsonGenerator(content, path);
            }
            else
            {
               generatorDirector.CreateSimplePipeGenerator(content, path);
            }

            var generator = _generatorConcreteBuilder.GetGenerator();
            generator.Save();
            return Json("File generated!");
         }
         catch (Exception ex)
         {
            return BadRequest();
         }
      }
   }
}
