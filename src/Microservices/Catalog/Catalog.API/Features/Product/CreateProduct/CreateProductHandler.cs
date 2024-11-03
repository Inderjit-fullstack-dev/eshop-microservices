using Catalog.API.Models;
namespace Catalog.API.Features.ProductFeature.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        public async Task<Product> Handle(CreateProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                Categories = request.Categories,
                Price = request.Price
            };

            return product;
        }
    }
}
