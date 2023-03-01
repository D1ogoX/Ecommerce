using Ecommerce.Interfaces.Repositories;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartRepository _cartRepository;

        public enum Status
        {
            Nothing,
            Error,
            Success
        }

        public CartModel(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Ecommerce.Models.CartModel cart { get; set; }
        public Status updateStatus { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Ecommerce_token")))
                cart = _cartRepository.GetCartByUserIdAsync(HttpContext.Session.GetInt32("Ecommerce_userId") ?? default(int)).Result;
        }

        public void OnPost()
        {
            int quantity = Convert.ToInt32(Request.Form["quantity"]);
            int idProduct = Convert.ToInt32(Request.Form["idProduct"]);
            int idCart = Convert.ToInt32(Request.Form["idCart"]);

            var _cart = _cartRepository.GetCartByIdAsync(idCart).Result;

            var _productList = _cart.products;

            int indexOfProduct = _cart.products.FindIndex(x => x.productId == idProduct);

            var _product = _cart.products.Where(x => x.productId == idProduct).First();

            _productList.RemoveAt(indexOfProduct);

            _product.quantity = quantity;

            _productList.Add(_product);

            _cart.products = _productList;

            List<CartProductRequestModel> _finalProductList = new List<CartProductRequestModel>();

            foreach(var _prod in _cart.products)
            {
                _finalProductList.Add(new CartProductRequestModel()
                {
                    productId = _prod.productId,
                    quantity = _prod.quantity
                });
            }

            if (_cartRepository.UpdateCart(new Models.CartUpdateRequestModel()
            {
                id = idCart,
                userId = HttpContext.Session.GetInt32("Ecommerce_userId") ?? default(int),
                date = DateTime.UtcNow,
                products = _finalProductList
            }).Result)
                updateStatus = Status.Success;

            else
                updateStatus = Status.Error;

            OnGet();
        }
    }
}
