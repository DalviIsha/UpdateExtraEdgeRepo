using Domain.Dto;
using Domain.Entities;
using WebApplication1.Domain.Abstractions;

namespace WebApplication1.Domain.RequestModels.CommandRequestModels.Product
{
    public record SaveProductCommand(ProductDetailsDto ProductDetails) : ICommand<bool>;
    public record UpdateProductCommand(Guid productId, ProductDetailsDto ProductDetails) : ICommand<bool>;
}
