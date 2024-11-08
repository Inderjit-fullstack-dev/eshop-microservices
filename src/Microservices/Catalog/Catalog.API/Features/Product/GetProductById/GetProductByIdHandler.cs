using Catalog.API.Models;
using Marten;

namespace Catalog.API.Features.ProductFeature.GetProductById
{
    public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger) 
        : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IDocumentSession _session = session;
        private readonly ILogger<GetProductByIdHandler> _logger = logger;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetByIdProductHandler called with {request}");
            return await _session.LoadAsync<Product>(request.Id, cancellationToken);
        }
    }
}
