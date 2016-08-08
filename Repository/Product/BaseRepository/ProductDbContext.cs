using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Product.BaseRepository
{
    public class ProductDbContext : DbContext
    {
        /// <summary>
        /// Sending Connection string as a parameter
        /// </summary>
        /// <param name="connectionString"></param>
        public ProductDbContext(string connectionString) : base(connectionString)
        {

        }


        /// <summary>
        /// Creating Code First Database
        /// </summary>
        public DbSet<Models.Domain.Product> Products { get; set; }

    }
}
