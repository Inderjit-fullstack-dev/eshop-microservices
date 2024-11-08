using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Features.ProductFeature.GetProducts
{
    public record GetProductsQuery : IRequest<IReadOnlyList<Product>>
    {
    }
}
