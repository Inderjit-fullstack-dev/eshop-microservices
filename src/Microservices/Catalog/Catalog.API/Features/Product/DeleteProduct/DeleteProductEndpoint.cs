
using Catalog.API.Exceptions;

namespace Catalog.API.Features.ProductFeature.DeleteProduct
{
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) => 
            {
                try
                {
                    var result = await sender.Send(new DeleteProductCommand(id));
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
