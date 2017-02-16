using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppSQL.Models;
using Dapper;
namespace WebAppSQL.Controllers
{
    public class DapperController : Controller
    {
        // GET: Ado
        public async Task<ActionResult> Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                //var products = conn.Query<Product>("select id, name, price from Products where id=@ProductId", new { ProductId = 1 });
                var products = conn.Query<Product>("select id, name, price from Products");

                //var product = new Product { Name = "Coffee", Price = 2 };
                //conn.Execute("insert into products values(@name, @price)", product);
                return View(products);
            }
        }
    }
}