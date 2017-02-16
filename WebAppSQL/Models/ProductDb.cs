using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace WebAppSQL.Models
{
    
    public class ProductDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {            
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}