using Ecommerce.Interfaces.Repositories;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DetailsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductModel Product { get; set; }

        public void OnGet(int id)
        {
            Product = _productRepository.GetByIdAsync(id).Result;
        }
    }
}
