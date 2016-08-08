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

        /// <summary>
        /// Returns all the products in the system
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        /// <summary>
        /// Return the product against the specifed ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetById(int id)
        {
            return _productRepository.Find(id);
        }

        /// <summary>
        /// Saves the product in the database
        /// Calls BesRepository method which sees whether to add or update
        /// </summary>
        /// <param name="product"></param>
        public void Save(Product product)
        {
            _productRepository.Update(product);
            _productRepository.SaveChanges();
            
        }
        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="product"></param>
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
