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
        /// This will be a testable Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Product/5
        public Product Get(int id)
        {
            if(id<=0)
                throw new ISTException("Product Id is not valid");
            var toReturn =  ProductService.GetById(id);
            if (toReturn != null)
                return toReturn;
            throw new Exception("Product not found");
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
