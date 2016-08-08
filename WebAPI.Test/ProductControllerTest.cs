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
        /// <summary>
        /// Testing Get method of controller which is used to find a product
        /// </summary>

        [TestClass]
        public class Get
        {

            /// <summary>
            /// Test the exception when Id less than zero is passed
            /// </summary>
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

            /// <summary>
            /// Test if no product is found
            /// </summary>
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
           
            
            /// <summary>
            /// Test if valid id is passed and a product is returned
            /// </summary>
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
