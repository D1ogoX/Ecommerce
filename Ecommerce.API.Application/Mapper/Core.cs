using AutoMapper;
using Ecommerce.API.Application.DataContract.Request.Product;
using Ecommerce.API.Application.DataContract.Response.Product;
using Ecommerce.API.Domain.Models;

namespace Ecommerce.API.Application.Mapper
{
    /// <summary>
    /// Map response to model and request to model
    /// </summary>
    public class Core : Profile
    {
        public Core()
        {
            ProductMap();
        }

        private void ProductMap()
        {
            CreateMap<RatingRequest, RatingResponse>();
            CreateMap<RatingModel, RatingResponse>();

            CreateMap<ProductRequest, ProductModel>()
                .ForMember(dest => dest.rating, opt => opt.MapFrom(x => x));
            CreateMap<ProductModel, ProductResponse>();
        }
    }
}
