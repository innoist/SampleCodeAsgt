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
            
         var abc=   ProductService.GetAll().ToList();

            return ProductService.GetAll();
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return ProductService.GetById(id);
        }

        // POST: api/Product
        public void Post(Product product)
        {
            ProductService.Save(product);
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
