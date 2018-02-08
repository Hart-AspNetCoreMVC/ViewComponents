using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;

//viewcomponent derived form the ViewComponent base class which provides conveinient access to context data
//the base class provides conveinice properties such as HttpContext, Request, User, RouteData, ViewBag, ModelState, ViewCOntext, ViewData
//information about the view component is found in the ViewComponentContext object which includes, Arguments, HtmlEncoder, ViewComponentDescriptor, ViewContext, ViewData
namespace UsingViewComponents.Components
{
    public class CitySummary: ViewComponent
    {
        private ICityRepository _repository;

        public CitySummary(ICityRepository repository)
        {
            _repository = repository;
        }
        //===============Invoke method examples===========
        //returns a simple string
        // ==============================       
        //public string Invoke()
        //        {
        //            return $"{_repository.Cities.Count()} cities, "
        //                   + $"{_repository.Cities.Sum(c => c.Population)} people";
        //        }


        //============================================================
        //Invoke method that returns a IViewComponentResult created by the View() method and passing in an object based off a ViewModel
        //Razor will look for View file  called Default.cshtml in Views/Controller(or shared)/Components/filename
        //===========================================================
        
//        public IViewComponentResult Invoke()
//        {
//            return View(new CityViewModel
//            {
//                Cities = _repository.Cities.Count(),
//                Population = _repository.Cities.Sum(p => p.Population)
//            });
//        }
        //==============================================
        //Invoke method returns the Content() which safely encodes text and displays it verbatim(does not run it) so that users cannot embed JS scripts in a file
        //===============================================
//        public IViewComponentResult Invoke()
//        {
//            return Content("This is a <h3><i>string</i></h3>");
//        }

        //================================================
        //Invoke method using infomation obtained in the contexct data objext
        //this one grabs a route param(id) out of the RouteData object and uses it in a linq query to filter out data
        //by entering  home/index/USA or France or UK -- you can see the results change. The route param alone is used to activate such changes
        //=================================================
//        public IViewComponentResult Invoke()
//        {
//            string target = RouteData.Values["id"] as string;
//            var cities =
//                _repository.Cities.Where(city => target == null || string.Compare(city.Country, target, true) == 0);
//            return View(new CityViewModel{ Cities= cities.Count(), Population = cities.Sum(c=>c.Population)});
//        }


        public IViewComponentResult Invoke(bool showlist)
        {
            if (showlist)
            {
                return View("CityList", _repository.Cities);
            }
            else
            {
                return View(new CityViewModel{
                    Cities = _repository.Cities.Count(), Population  = _repository.Cities.Sum(c => c.Population)
                        });
            }
        }
        }
        
    }

