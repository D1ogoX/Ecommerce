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
                List<CartProductModel> products = new List<CartProductModel>();

                foreach(var _cart in cart.products)
                {
                    products.Add(new CartProductModel()
                    {
                        productId = _cart.productId,
                        quantity = _cart.quantity
                    });
                }

                return await _cartService.AddCartAsync(new CartModel()
                {
                    userId = cart.userId,
                    date = cart.date,
                    products = products
                });
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response<CartResponse>> GetCartByIdAsync(int cartId)
        {
            Response<CartModel> cart = await _cartService.GetCartByIdAsync(cartId);

            if (cart.Report.Any())
                return Response.Unprocessable<CartResponse>(cart.Report);

            var response = _mapper.Map<CartResponse>(cart.Data);

            return Response.OK(response);
        }

        public async Task<Response<List<CartResponse>>> GetUserCartAsync(int userId)
        {
            Response<List<CartModel>> cart = await _cartService.GetUserCartAsync(userId);

            if (cart.Report.Any())
                return Response.Unprocessable<List<CartResponse>>(cart.Report);

            var response = _mapper.Map<List<CartResponse>>(cart.Data);

            return Response.OK(response);
        }

        public async Task<Response> UpdateCartAsync(UpdateCartRequest cart)
        {
            try
            {
                List<CartProductModel> products = new List<CartProductModel>();

                foreach (var _cart in cart.products)
                {
                    products.Add(new CartProductModel()
                    {
                        productId = _cart.productId,
                        quantity = _cart.quantity
                    });
                }

                return await _cartService.UpdateCartAsync(new CartModel()
                {
                    id = cart.id,
                    userId = cart.userId,
                    date = cart.date,
                    products = products
                });
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }
    }
}
