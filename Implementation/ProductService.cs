using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Implementation;
using Models.Domain;

namespace Implementation
{
    public class ProductService : IProductService
    {


        public IEnumerable<Product> GetAll()
        {
            return new List<Product>();
        }

        public Product GetById(int id)
        {
            return new Product();
        }

        public bool Save(Product product)
        {
            return true;
        }

        public bool Update(Product product)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
