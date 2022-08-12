using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; //ActionResult as viewresult
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyConverter.Controllers;

namespace MoneyConverterTest
{
    [TestClass]
    public class HomeControllerTest
    {
        //Unit test methods
        [TestMethod]
        public void IndexReturnsResult()
        {
            //Arrange
            HomeController controller = new HomeController(null);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsNotNull(result);
        }
        
  [TestMethod]
public void PrivacyLoadsPrivacyView()
{
    // Arrange
    HomeController controller = new HomeController(null);
    // Act
    var result = (ViewResult)controller.Privacy();
    // Assert
    Assert.IsNotNull(result);
        }
    }
}