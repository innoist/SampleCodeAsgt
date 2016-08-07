using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Implementation;
using Interfaces.Repository;
using Models.Domain;

namespace Implementation
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;

        public ProductService(IProductRepository _productRepository)
        {
            this._productRepository = _productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
          //  return new List<Product>();
        }

        public Product GetById(int id)
        {
            return _productRepository.Find(id);
        }

        public void Save(Product product)
        {
            _productRepository.Add(product);
            _productRepository.SaveChanges();
            
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }

        public bool Delete(int id)
        {
            var toDelete = _productRepository.Find(id);
            if (toDelete != null)
            {
                _productRepository.Delete(toDelete);
                return true;
            }
            return false;

        }
    }
}
