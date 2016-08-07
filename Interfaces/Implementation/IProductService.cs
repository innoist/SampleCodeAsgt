using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Domain;

namespace Interfaces.Implementation
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Save(Product product);
        void Update(Product product);

        bool Delete(int id);
    }
}
