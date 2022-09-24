using MediatR;

namespace WebApplication1.Domain.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}