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
        
        //public ProductDbContext(string connectionString) : base(connectionString)
        //{

        //}



        public DbSet<Models.Domain.Product> Products { get; set; }

    }
}
