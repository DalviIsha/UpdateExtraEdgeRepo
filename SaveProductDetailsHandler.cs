using Domain.Dto;
using Domain.Entities;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Domain.RequestModels.CommandRequestModels.Product;

namespace WebApplication1.Infrastructure.Handlers.Command
{
    public class SaveProductDetailsHandler : ICommandHandler<SaveProductCommand, bool>
    {
        private readonly IProductCustomRepo _productCustomRepo;

        public SaveProductDetailsHandler(IProductCustomRepo productCustomRepo)
        {
            productCustomRepo = _productCustomRepo;
        }

        public async Task<bool> Handle(SaveProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productId = Guid.NewGuid();
                var saveProductDetails = request.ProductDetails;
                if (saveProductDetails is { })
                {
                    bool success;

                    success = await InsertProduct(productId, saveProductDetails);

                    success = success && await InsertSales(productId,saveProductDetails.sales) ;

                    if (success)
                    {
                        return await _productCustomRepo.CommitTransactionAsync();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ("Error In Save Product details");
            }
        }

        private async Task<bool> InsertProduct(Guid productId, ProductDetailsDto saveProductDetails)
        {
            try
            {
                RefProduct prod = new RefProduct();
                if (saveProductDetails.product is { })
                {

                    prod.ProductId = productId;
                    prod.ProductName = saveProductDetails.product.ProductName;
                    prod.BatchNumber = saveProductDetails.product.BatchNumber;
                    prod.Brand = saveProductDetails.product.Brand;
                    prod.CostPrice = saveProductDetails.product.Price;
                    prod.Discount = saveProductDetails.product.Discount;
                    prod.MangDate = saveProductDetails.product.MangDate;
                    prod.CreatedTS = DateTime.UtcNow;

                    return await _productCustomRepo.CreateProductAsync(prod);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task<bool> InsertSales(Guid productId, SalesDto saveSalesDetails)
        {
            try
            {
                RefSales sales = new RefSales();
                if (saveSalesDetails is { })
                {

                   sales.SalesId = Guid.NewGuid();
                   sales.DateOfSales = saveSalesDetails.DateOfSales;
                   sales.TotalAmount = saveSalesDetails.TotalAmount;
                   sales.Quantity = saveSalesDetails.Quantity;
                   sales.ProductId = productId;
                    return await _productCustomRepo.CreateSalesAsync(sales);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}