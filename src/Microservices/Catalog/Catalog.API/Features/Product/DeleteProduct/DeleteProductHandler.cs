using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Features.ProductFeature.DeleteProduct
{

    public record DeleteProductCommand(Guid Id) : IRequest<Product>;

    public class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger) 
        : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IDocumentSession _session = session;
        private readonly ILogger<DeleteProductHandler> _logger = logger;

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"DeleteProductHandler called with {request}");
            var product = await _session.LoadAsync<Product>(request.Id, cancellationToken) 
                    ?? throw new ProductNotFoundException();


            _session.Delete<Product>(product.Id);
            await _session.SaveChangesAsync(cancellationToken);
            return product;
        }
    }

}
