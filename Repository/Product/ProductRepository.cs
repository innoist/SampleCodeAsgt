using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using Model= Models.Domain;

namespace Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Model.Product> GetAll()
        {
            return new List<Model.Product>();
        }

        public Model.Product GetById(int id)
        {
            return new Model.Product();
        }

        public bool Save(Model.Product product)
        {
            return true;
        }

        public bool Update(Model.Product product)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

    }
}
