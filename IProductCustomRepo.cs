using Domain.Entities;
using WebApplication1.API.Controllers;

namespace WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo
{
    public interface IProductCustomRepo
    {
        Task<bool> UpdateUserAsync(RefUser user);
        Task<bool> CreateUserAsync(RefUser user);
        Task<RefUser> GetUser(Guid userId);
        Task<bool> UpdateSaleAsync(RefSales sales);
        Task<bool> UpdateProductAsync(RefProduct product);
        Task<bool> CommitTransactionAsync();
        Task<bool> CreateProductAsync(RefProduct product);
        Task<bool> CreateSalesAsync(RefSales sales);
        Task<RefProduct> GetProduct(Guid productId);
        Task<RefSales> GetSales(Guid salesId);

    }
}