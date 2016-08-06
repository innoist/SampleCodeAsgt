using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Domain;

namespace Interfaces.Repository
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int site);
        Product GetById(int id);
        bool Save(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}
