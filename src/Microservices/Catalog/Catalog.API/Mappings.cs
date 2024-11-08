
using AutoMapper;
using Catalog.API.Features.ProductFeature.UpdateProduct;
using Catalog.API.Models;

namespace Catalog.API
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
