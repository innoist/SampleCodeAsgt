using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ExceptionHandling;
using Interfaces.Implementation;
using Models.Domain;

namespace WebAPI.Controllers
{
   

    [ApiException]

    public class ProductController : ApiController
    {

        public IProductService ProductService { get; set; }
        /// <summary>
        /// Injecting Implementation service in the controller
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }
        
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            
         return  ProductService.GetAll().ToList();
            
        }

        /// <summary>
        /// I have created the UNIT TEST against this functionality. There are some extra logics which 
        /// I have implemented only to write multiple test cases
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Product/5
        public Product Get(int id)
        {
            
            if(id<=0)
                throw new ISTException("Product Id is not valid");//Verified in Unit Test
            var toReturn =  ProductService.GetById(id);
            if (toReturn != null)
                return toReturn;//Verified in Unit Test
            throw new Exception("Product not found");//Verified in Unit Test
        }

        // POST: api/Product
        public IHttpActionResult Post(Product product)
        {
            ProductService.Save(product);
            return Ok(true);
        }


        // PUT: api/Product/5
        public void Put(Product product)
        {
            ProductService.Update(product);

        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            ProductService.Delete(id);
        }
    }
}
