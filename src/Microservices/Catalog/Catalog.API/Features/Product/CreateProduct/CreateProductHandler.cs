using Catalog.API.Models;
using Marten;
namespace Catalog.API.Features.ProductFeature.CreateProduct
{
    public class CreateProductHandler(IDocumentSession session) : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IDocumentSession _session = session;

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

            _session.Store(product);
            await _session.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
