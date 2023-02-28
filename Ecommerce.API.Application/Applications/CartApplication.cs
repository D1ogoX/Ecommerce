using AutoMapper;
using Ecommerce.API.Application.DataContract.Request.Cart;
using Ecommerce.API.Application.DataContract.Response.Cart;
using Ecommerce.API.Application.Interfaces;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Applications
{
    public class CartApplication : ICartApplication
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartApplication(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        public async Task<Response> AddCartAsync(CartRequest cart)
        {
            try
            {
                var cartModel = _mapper.Map<CartModel>(cart);

                return await _cartService.AddCartAsync(cartModel);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response<List<CartResponse>>> GetUserCartAsync(int userId)
        {
            Response<List<CartModel>> cart = await _cartService.GetUserCartAsync(userId);

            if (cart.Report.Any())
                return Response.Unprocessable<List<CartResponse>>(cart.Report);

            var response = _mapper.Map<List<CartResponse>>(cart.Data);

            return Response.OK(response);
        }
    }
}
