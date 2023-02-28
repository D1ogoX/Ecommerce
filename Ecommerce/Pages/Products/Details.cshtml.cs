using Ecommerce.Interfaces.Repositories;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public DetailsModel(IProductRepository productRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public ProductModel Product { get; set; }

        //Just demosntrative
        public List<ProductModel> SimilarProducts { get; set; }

        public void OnGet(int id)
        {
            Product = _productRepository.GetByIdAsync(id).Result;

            Random rnd = new Random();
            SimilarProducts = _productRepository.GetAllAsync().Result.OrderBy(x => rnd.Next()).Take(3).ToList();
        }

        public void OnPost()
        {
            int quantity = Convert.ToInt32(Request.Form["quantity"]);
            int productId = Convert.ToInt32(Request.Form["productId"]);

            _cartRepository.AddCart(new Models.CartRequestModel()
            {
                userId = HttpContext.Session.GetInt32("Ecommerce_userId") ?? default(int),
                date = DateTime.UtcNow,
                products = new List<CartProductRequestModel>() { new CartProductRequestModel() { productId = productId, quantity = quantity } }
            });

            OnGet(productId);
        }
    }
}
