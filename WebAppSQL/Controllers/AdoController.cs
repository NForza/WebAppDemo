using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppSQL.Models;

namespace WebAppSQL.Controllers
{
    public class AdoController : Controller
    {
        // GET: Ado
        public async Task<ActionResult> Index()
        {
            List<Product> products = new List<Product>();
            var connectionString = ConfigurationManager.ConnectionStrings["ProductDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                using( var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select id, name, price from Products";
                    //cmd.CommandText = "select id, name, price from Products where id=@ProductId";
                    //cmd.Parameters.AddWithValue("ProductId", 1);

                    await conn.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDouble(2)
                        });
                    }
                }
            }
            return View(products);
        }
    }
}