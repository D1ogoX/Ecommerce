namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }
    }
}
