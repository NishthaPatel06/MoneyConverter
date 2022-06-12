using Microsoft.AspNetCore.Mvc;
using MoneyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyConverter.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            //use the country model to mock up a list of country objects for display in the view 
            var countries = new List<Country>();

            for (var i = 1; i <= 10; i++)
            {
                countries.Add(new Country { Name = "Country" + i.ToString() });
            }

            //load the view and pass it in the list of countries
            return View(countries);
        }
        public IActionResult CurrentRate(string Country)
        {
            if(Country == null)
            {
                return RedirectToAction("index");
            }

            //take a country name to passed a value in a input area for a view

            ViewData["Country"] = Country;
            return View();
        }
    }
}
