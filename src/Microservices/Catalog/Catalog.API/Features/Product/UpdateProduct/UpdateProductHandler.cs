using AutoMapper;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Features.ProductFeature.UpdateProduct
{
    public class UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger,
        IMapper mapper) 
        : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IDocumentSession _session = session;
        private readonly ILogger<UpdateProductHandler> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<Product> Handle(UpdateProductCommand request, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UpdateProductHandler called with {request}");

            var product = await _session.LoadAsync<Product>(request.Id, cancellationToken) 
                ?? throw new ProductNotFoundException();

            _mapper.Map(request.product, product);
            _session.Store(product);
            await _session.SaveChangesAsync(cancellationToken);
            return product;
            
        }
    }
}
