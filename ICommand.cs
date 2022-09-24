using MediatR;
namespace WebApplication1.Domain.Abstractions
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}