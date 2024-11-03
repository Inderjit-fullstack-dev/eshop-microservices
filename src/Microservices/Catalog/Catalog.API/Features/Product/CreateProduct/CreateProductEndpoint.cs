using Catalog.API.Models;

namespace Catalog.API.Features.ProductFeature.CreateProduct
{
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (Product product, ISender
                sender) => 
            {
                return await sender.Send(new CreateProductCommand(product.Name, 
                    product.Categories, product.Description, 
                    product.Image, product.Price));
            });
        }
    }
}
