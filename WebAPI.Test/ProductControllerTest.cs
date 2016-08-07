using System;
using ExceptionHandling;
using Implementation;
using Interfaces.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Domain;
using Moq;
using SUT = WebAPI.Controllers;
using IUT = Interfaces.Implementation;
namespace WebAPI.Test
{
    [TestClass]
    public class ProductControllTest
    {
        

        [TestClass]
        public class Get
        {

            //public IProductService ProductService { get; set; }

            //public Get(IProductService productService)
            //{
            //    this.ProductService = productService;

            //}
            //All the test methods of Get function will come in this class
            [TestMethod]
            [ExpectedException(typeof(ISTException))]
            public void IdLessThanEqualZero_ReturnISTException()
            {
                //Arrange
                var mock = new Mock<IUT.IProductService>(MockBehavior.Strict);
                IUT.IProductService productService = mock.Object;
                int id = 0;
                mock.Setup(x => x.GetById(id)).Returns(new Product());
                var obj = new SUT.ProductController(productService);

                //Act
                obj.Get(id);

                //Assert
            }

            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void ProductNotFound_ReturnException()
            {
                //Arrange
                var mock = new Mock<IUT.IProductService>(MockBehavior.Strict);
                IUT.IProductService productService = mock.Object;
                int id = 444;
                mock.Setup(x => x.GetById(id)).Returns((Product)null);
                var obj = new SUT.ProductController(productService);

                //Act
                obj.Get(id);

                //Assert
            }

            [TestMethod]
            public void CorrectProductId_ReturnProduct()
            {
                //Arrange
                var mock = new Mock<IUT.IProductService>(MockBehavior.Strict);
                IUT.IProductService productService = mock.Object;
                int id = 1005;
                mock.Setup(x => x.GetById(id)).Returns(new Product {Id=1005});
                var obj = new SUT.ProductController(productService);
                
                //Act
                var result = obj.Get(id);

                //Assert
                mock.Verify();
                Assert.AreEqual(result.Id , id);
            }
        }
    }
}
