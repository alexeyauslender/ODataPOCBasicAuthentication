using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ProductService.Models;

namespace ODataPOC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");
            builder.EntitySet<ProductRating>("Ratings");
            var rateProduct = builder.Entity<Product>().Action("RateProduct");
            rateProduct.Parameter<int>("Rating");
            rateProduct.Returns<double>();

            config.Routes.MapODataServiceRoute("odataX", "{clientnamespace}/odata", builder.GetEdmModel());
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}