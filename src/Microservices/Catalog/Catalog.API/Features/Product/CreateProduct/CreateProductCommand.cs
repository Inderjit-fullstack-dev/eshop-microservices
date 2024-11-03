using Catalog.API.Models;
namespace Catalog.API.Features.ProductFeature.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Categories, string Description, 
        string Image, decimal Price) 
        : IRequest<Product>
    {
    }
}
