using Domain.Dto;
using Domain.Entities;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Domain.RequestModels.CommandRequestModels.Product;

namespace WebApplication1.Infrastructure.Handlers.Command
{
    public class UpdateProductDetailsHandler : ICommandHandler<UpdateProductCommand, bool>
    {
        private readonly IProductCustomRepo _productCustomRepo;

        public UpdateProductDetailsHandler(IProductCustomRepo productCustomRepo)
        {
            productCustomRepo = _productCustomRepo;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var saveProductDetails = request.ProductDetails;
                var productId = request.productId;
                if (saveProductDetails is { })
                {
                    bool success;

                    success = await UpdateProduct(productId, saveProductDetails);

                    success = success && await UpdateSales(productId,saveProductDetails.sales) ;

                    if (success)
                    {
                        return await _productCustomRepo.CommitTransactionAsync();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ("Error In Update Product details");
            }
        }

        private async Task<bool> UpdateProduct(Guid productId, ProductDetailsDto saveProductDetails)
        {
            try
            {
                RefProduct prod = new RefProduct();
                if (saveProductDetails.product is { })
                {
                    var updateProduct = await _productCustomRepo.GetProduct(productId);

                    prod.ProductName = updateProduct.ProductName;
                    prod.BatchNumber = updateProduct.BatchNumber;
                    prod.Brand = updateProduct.Brand;
                    prod.CostPrice = updateProduct.CostPrice;
                    prod.Discount = updateProduct.Discount;
                    prod.MangDate = updateProduct.MangDate;
                    prod.ModifiedTS = DateTime.UtcNow;

                    return await _productCustomRepo.UpdateProductAsync(prod);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task<bool> UpdateSales(Guid productId, SalesDto saveSalesDetails)
        {
            try
            {
                var salesId = saveSalesDetails.SalesId;
                RefSales sales = new RefSales();
                if (saveSalesDetails is { })
                {
                    var updateSales = await _productCustomRepo.GetSales(salesId);

                   sales.SalesId = Guid.NewGuid();
                   sales.DateOfSales = updateSales.DateOfSales;
                   sales.TotalAmount = updateSales.TotalAmount;
                   sales.Quantity = updateSales.Quantity;
                   sales.ProductId = updateSales.ProductId;
                    sales.ModifiedTS = DateTime.UtcNow;
                    return await _productCustomRepo.UpdateSaleAsync(sales);
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