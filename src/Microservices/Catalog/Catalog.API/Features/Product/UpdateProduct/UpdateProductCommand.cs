using Catalog.API.Models;

namespace Catalog.API.Features.ProductFeature.UpdateProduct
{

    public record UpdateProductRequest(string Name, string Description, 
        string Image, List<string> Categories, decimal Price);

    public record UpdateProductCommand(Guid Id, UpdateProductRequest product) 
        : IRequest<Product>
    {
    }
}
