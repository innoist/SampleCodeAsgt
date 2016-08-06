using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Interfaces.Implementation;

namespace WebAPI.Controllers
{
    

    public class ProductController : ApiController
    {

        public IProductService ProductService { get; set; }

      
        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            ProductService.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
