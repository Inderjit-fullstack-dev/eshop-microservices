
using Catalog.API.Exceptions;

namespace Catalog.API.Features.ProductFeature.UpdateProduct
{
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/{id}", async (Guid id, UpdateProductRequest product, ISender sender) => 
            {
                try
                {
                    var result = await sender.Send(new UpdateProductCommand(id, product));
                    return Results.Ok(result);
                }
                catch (ProductNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }
    }
}
