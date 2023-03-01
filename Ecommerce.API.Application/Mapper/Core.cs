using AutoMapper;
using Ecommerce.API.Application.DataContract.Request.Cart;
using Ecommerce.API.Application.DataContract.Request.Product;
using Ecommerce.API.Application.DataContract.Request.User;
using Ecommerce.API.Application.DataContract.Response.Cart;
using Ecommerce.API.Application.DataContract.Response.Product;
using Ecommerce.API.Application.DataContract.Response.User;
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
            UserMap();
            CartMap();
        }

        private void ProductMap()
        {
            CreateMap<RatingRequest, RatingResponse>();
            CreateMap<RatingModel, RatingResponse>();

            CreateMap<ProductRequest, ProductModel>()
                .ForMember(dest => dest.rating, opt => opt.MapFrom(x => x));
            CreateMap<ProductModel, ProductResponse>();
        }

        private void UserMap()
        {
            CreateMap<GeolocationModelRequest, GeolocationModelResponse>();
            CreateMap<GeolocationModel, GeolocationModelResponse>();
            CreateMap<AddressModelRequest, AddressModelResponse>();
            CreateMap<AddressModel, AddressModelResponse>();
            CreateMap<NameModelRequest, NameModelResponse>();
            CreateMap<NameModel, NameModelResponse>();
            CreateMap<UserRequest, UserResponse>();
            CreateMap<UserModel, UserResponse>();
        }

        private void CartMap()
        {
            CreateMap<CartProductRequest, CartProductResponse>();
            CreateMap<CartProductRequest, CartModel>();
            CreateMap<CartProductModel, CartProductResponse>();

            CreateMap<CartRequest, CartResponse>();
            CreateMap<CartRequest, CartModel>();
            CreateMap<CartModel, CartRequest>();
            CreateMap<CartModel, CartResponse>();
        }
    }
}
