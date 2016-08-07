using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Model= Models.Domain;
using Repository.Product.BaseRepository;
namespace Repository.Product
{
    public class ProductRepository : BaseRepository<Model.Product>,IProductRepository
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductRepository(IUnityContainer container)
            : base(container)
        {

        }
        #endregion
        protected override IDbSet<Model.Product> DbSet
        {
            get { return db.Products; }
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
