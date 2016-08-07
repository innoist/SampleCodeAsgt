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
        IEnumerable<Product> GetAll();
        Product Find(long id);
       void Add(Product product);
        void SaveChanges();

        void Update(Product product);
        void Delete(Product product);
    }
}
