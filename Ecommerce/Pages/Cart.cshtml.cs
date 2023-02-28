using Ecommerce.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartRepository _cartRepository;

        public CartModel(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Ecommerce.Models.CartModel cart { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Ecommerce_token")))
                cart = _cartRepository.GetCartByUserIdAsync(HttpContext.Session.GetInt32("Ecommerce_userId") ?? default(int)).Result;
        }
    }
}
