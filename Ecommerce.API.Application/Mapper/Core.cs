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
            CreateMap<ProductRequest, ProductModel>();
            CreateMap<ProductModel, ProductResponse>();
        }
    }
}
