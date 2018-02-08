using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;


namespace UsingViewComponents.Controllers
{
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private ICityRepository _repository;

        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            _repository.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult() {
                ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, _repository.Cities)
                
                };
        }
        }
    }

