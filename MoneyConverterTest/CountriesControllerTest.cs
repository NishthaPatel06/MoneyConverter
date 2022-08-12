using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyConverter.Controllers;
using MoneyConverter.Data;
using MoneyConverter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyConverterTest
{
    [TestClass]
    public class CountriesControllerTest
    {
        // use in-memory databases
        private ApplicationDbContext _context;
        private CountriesController _controller;
        private List<Country> _countries = new List<Country>();
        private ICollection selectedCountries;
        private object Cou;


        // Arrange
        [TestInitialize]
        public void TestInitialize()
        {
            // in-memory db context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            _context = new ApplicationDbContext(options);

            // mock some data
            // country
            var country = new Country { CountryId = 1, Name = "Canada" };
            _context.Countries.Add(country);
            _context.SaveChanges();
            // countryrates
            var CountryRate = new CountryRate { CountryRateId = 1, Name = "60.52" };
            _context.CountryRates.Add(CountryRate);
            _context.SaveChanges();

            // list of Country Names
            var country1 = new Country { CountryId = 1, Name = "United States", CountryRate = CountryRate, Country = country };
            var country2 = new Country { CountryId = 2, Name = "India", CountryRate = CountryRate, Country = country };
            var country3 = new Country { CountryId = 3, Name = "United Kingdom", CountryRate = CountryRate, Country = country };

             //add countries to db
            _context.Countries.Add(country1);
            _context.Countries.Add(country2);
            _context.Countries.Add(country3);
            _context.SaveChanges();

            //add names to lists
            _countries.Add(country1);
            _countries.Add(country2);
            _countries.Add(country3);

            // instantiate the controller object with mock db context
            _controller = new CountriesController(_context);
        }

       
        [TestMethod]
        public void IndexReturnsView()
        {
            // Act
            var result = _controller.Index();
            // Assert
            Assert.IsNotNull(result);
        }

       
        [TestMethod]
        public void IndexReturnsCountryData()
        {
             // Act
            var result = _controller.Index();
            var viewResult = (ViewResult)result.Result;
       
            var model = (List<Country>)viewResult.Model;

            var selectedCountries = _countries.Select(c => c.Name).ToList();
            // Assert
            CollectionAssert.AreEqual(selectedCountries, model);
        }

        [TestMethod]
        public void DetailsReturnsNotFoundIfIdIsNotValid()
        {
            var testId = 100;
            var actionResult = _controller.Details(testId);
            var notFoundResult = (NotFoundResult)actionResult.Result;
            // make sure app returns 404 when searching for an invalid id
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        
        [TestMethod]
        public void PostCreateCountry()
        {
     
            var newCountry = new Country
            {
                CountryId = 4,
                Name = "",
                Country = new Country() { CountryId = 2, Name = "France" },
                CountryRate = new CountryRate() { CountryRateId = 2, Name = "90.21" }
            };

            //create method 
            var result = _controller.Create(newCountry, null);

            // test the context to check whether I can find a country with ID 4
            var prod = _context.Countries.Find(4);
           
            Assert.IsNotNull(Cou);
        }
    }
}
