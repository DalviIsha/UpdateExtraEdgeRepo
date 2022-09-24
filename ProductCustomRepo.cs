using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Infrastructure.Context;

namespace WebApplication1.Infrastructure.Repositories.RepoWrappers.CommandRepo
{
    public class ProductCustomRepo : IProductCustomRepo
    {
        private readonly WriteWebApplication1MSContext _writeDbContext;

        public ProductCustomRepo(
            WriteWebApplication1MSContext writeDbContext) => _writeDbContext = writeDbContext;

        
        public async Task<bool> CommitTransactionAsync()
        {
            return await _writeDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateProductAsync(RefProduct product)
        {
            await _writeDbContext.AddAsync(product);
            return true;
        }

        public async Task<bool> UpdateProductAsync(RefProduct product)
        {
            _writeDbContext.Entry(product).State = EntityState.Modified;
            return true;
        }

        public async Task<bool> CreateSalesAsync(RefSales sale)
        {
            await _writeDbContext.AddAsync(sale);
            return true;
        }

        public async Task<bool> UpdateSaleAsync(RefSales sale)
        {
            _writeDbContext.Entry(sale).State = EntityState.Modified;
            return true;
        }
        public async Task<RefProduct> GetProduct(Guid productId)
        {
            return await _writeDbContext.RefProduct.FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<RefSales> GetSales(Guid salesId)
        {
            return await _writeDbContext.RefSales.FirstOrDefaultAsync(x => x.SalesId == salesId);
        }

        public async Task<bool> UpdateUserAsync(RefUser user)
        {
            _writeDbContext.Entry(user).State = EntityState.Modified;
            return true;
        }

        public async Task<bool> CreateUserAsync(RefUser user)
        {
            await _writeDbContext.AddAsync(user);
            return true;
        }

        public async Task<RefUser> GetUser(Guid userId)
        {
            return await _writeDbContext.RefUser.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}