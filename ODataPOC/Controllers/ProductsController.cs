using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ProductService.Models;

namespace ODataPOC.Controllers
{
  
    [Authorize]

    public class ProductsController : ODataController   
    {
        private ProductServiceContext db = new ProductServiceContext();

       
        // GET odata/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        } 
    }
}
