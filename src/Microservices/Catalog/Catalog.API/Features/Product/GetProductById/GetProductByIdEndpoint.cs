﻿
using Catalog.API.Exceptions;

namespace Catalog.API.Features.ProductFeature.GetProductById
{
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                try
                {
                    var result = await sender.Send(new GetProductByIdQuery(id));
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
