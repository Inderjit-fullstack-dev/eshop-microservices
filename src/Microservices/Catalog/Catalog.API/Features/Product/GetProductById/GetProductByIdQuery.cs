using Catalog.API.Models;

namespace Catalog.API.Features.ProductFeature.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Product>
    {
    }
}
