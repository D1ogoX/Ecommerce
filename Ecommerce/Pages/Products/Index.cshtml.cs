using Ecommerce.Interfaces.Repositories;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public IndexModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

            Categories = _categoryRepository.GetAllAsync().Result;
        }

        public List<ProductModel> Products { get; set; } 
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }

        public void OnGet()
        {
            Products = _productRepository.GetAllAsync().Result;
        }

        public void OnPostCategory()
        {
            Products = _productRepository.GetAllByCategoryAsync(Request.Form["category"]).Result;

            SelectedCategory = Request.Form["category"];
        }

        public void OnPostAddCart()
        {

        }
    }
}
