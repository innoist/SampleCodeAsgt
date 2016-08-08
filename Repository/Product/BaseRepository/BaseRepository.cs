using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Configuration;

using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq.Expressions;
using System.Security.Claims;
using Interfaces.Repository;
using Repository.Product.BaseRepository;

namespace Repository.Product.BaseRepository
{


    public abstract class BaseRepository<TDomainClass> : IBaseRepository<TDomainClass, long>
       where TDomainClass : class
    {
        private readonly IUnityContainer container;
        protected abstract IDbSet<TDomainClass> DbSet { get; }



        public BaseRepository(IUnityContainer container) : base()
        {
            this.container = container;
            string connectionString = ConfigurationManager.ConnectionStrings["AsgtContext"].ConnectionString;
            
           db = new ProductDbContext(connectionString);
        }
        #region Public
        /// <summary>
        /// base Db Context
        /// </summary>
        
        public ProductDbContext db;

        /// <summary>
        /// Create object instance
        /// </summary>
        public virtual TDomainClass Create()
        {
            TDomainClass result = container.Resolve<TDomainClass>();
            return result;
        }
        /// <summary>
        /// Find entry by key
        /// </summary>
        public virtual IQueryable<TDomainClass> Find(TDomainClass instance)
        {
            return DbSet.Find(instance) as IQueryable<TDomainClass>;
        }
        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public virtual TDomainClass Find(long id)
        {
            return DbSet.Find(id);
        }
        /// <summary>
        /// Get All Entites 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TDomainClass> GetAll()
        {
            return DbSet;
        }
        /// <summary>
        /// Save Changes in the entities
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                {
                    var entityName = validationResult.Entry.Entity.GetType().Name;
                    errorMessages.AddRange(validationResult.ValidationErrors.Select(error => entityName + "." + error.PropertyName + ": " + error.ErrorMessage));
                }
                // Throw Exception
                throw new Exception(string.Join(",", errorMessages.ToArray()));
            }
        }


        /// <summary>
        /// Delete an entry
        /// </summary>
        public virtual void Delete(TDomainClass instance)
        {
            DbSet.Remove(instance);
        }
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Add(TDomainClass instance)
        {
            DbSet.Add(instance);
        }
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Update(TDomainClass instance)
        {
            DbSet.AddOrUpdate(instance);
        }

        
        
        #endregion
    }
}
