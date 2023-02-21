using Ecommerce.API.Domain.Interfaces.Repositories;

namespace Ecommerce.API.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        public IProductRepository productRepository => _productRepository;
    }
}
