using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ViewCustomers.Controllers;
using ViewCustomers.DAL;


namespace ViewCustomers.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private ViewCustomers.DAL.IUserRepository repository;
        [TestMethod]
        public void Index()
        { 
            // Arrange
            var controller = new UsersController(repository);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Details()
        //{
        //    // Arrange
        //    UsersController controller = new UsersController(repository);

        //    // Act
        //    ViewResult result = controller.Details() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Create()
        //{
        //    // Arrange
        //    UsersController controller = new UsersController(repository);

        //    // Act
        //    ViewResult result = controller.Create() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
        //public void Edit()
        //{
        //    // Arrange
        //    UsersController controller = new UsersController(repository);

        //    // Act
        //    ViewResult result = controller.Edit() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
        //public void Delete()
        //{
        //    // Arrange
        //    UsersController controller = new UsersController(repository);

        //    // Act
        //    ViewResult result = controller.Delete() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
