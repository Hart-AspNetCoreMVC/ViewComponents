using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{   //Plain out c# object; a component built without using the ViewComponent base class(MVC api)
    public class PocoViewComponent
    {   
//    creates a dependency on ICityRepository interface -- anyone of the repos implementing this interface can be used, and it designated in the setup file
        //dependency injection provides the class with the services it requires
        private ICityRepository _repository;

        public PocoViewComponent(ICityRepository repo)
        {
            _repository = repo;
        }
        //Invoke method describes the component that will be inserted into the parent view(in this case,_Layout) using @await Component.InvokeAsync("Poco")
        public string Invoke()
        {
            return $"{_repository.Cities.Count()} cities, "
                   + $"{_repository.Cities.Sum(c => c.Population)} people";
        }

    }
}
