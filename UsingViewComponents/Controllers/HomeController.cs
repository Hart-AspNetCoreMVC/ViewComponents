using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingViewComponents.Controllers
{


    public class HomeController : Controller
    {

        private IProductRepository _repository;

        //ctor with dependency on IProductRepository. When Mvc inits controller, it will consult service provider in setup, which will pass in the IPR object.
        public HomeController(IProductRepository repo)
        {
            _repository = repo;
        }


        public IActionResult Index()
        {
            return View(_repository.Products);
        }


        //following 2 methods use the Post/redirect/Get pattern for handling form data
        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            _repository.AddProduct(newProduct);
            return RedirectToAction("Index");
        }
        
    }
    
}

