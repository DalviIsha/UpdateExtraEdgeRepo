using Domain.Dto;
using Domain.Entities;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.Abstractions;

namespace WebApplication1.Domain.RequestModels.CommandRequestModels.User
{
    public record CreateUserCommand(UserDto userDetails) : ICommand<bool>;
    public record UpdateUserCommand(Guid UserId, UserDto userDetails) : ICommand<bool>;
}
