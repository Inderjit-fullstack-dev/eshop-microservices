
namespace Catalog.API.Features.ProductFeature.GetProducts
{
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender
                sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                return Results.Ok(result);
            });
        }
    }
}
