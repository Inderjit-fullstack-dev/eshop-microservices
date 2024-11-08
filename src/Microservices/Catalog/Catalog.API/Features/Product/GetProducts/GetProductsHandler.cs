using Catalog.API.Models;
using Marten;

namespace Catalog.API.Features.ProductFeature.GetProducts
{
    public class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger) 
        : IRequestHandler<GetProductsQuery, IReadOnlyList<Product>>
    {
        private readonly IDocumentSession _session = session;
        private readonly ILogger<GetProductsHandler> _logger = logger;

        public async Task<IReadOnlyList<Product>> Handle(GetProductsQuery request, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetProductsHandler called with {request}");
            return await _session.Query<Product>().ToListAsync(cancellationToken);
        }
    }
}
