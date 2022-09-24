using Realms.Sync.Exceptions;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Domain.RequestModels.CommandRequestModels.User;

namespace WebApplication1.Infrastructure.Service
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand, bool>
    {
        private readonly IProductCustomRepo _productCustomRepo;
        public CreateUserHandler(IProductCustomRepo productCustomRepo)
        {
            _productCustomRepo = productCustomRepo;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userdetails = request.userDetails;
                bool success;
                if (userdetails is { })
                {
                    var userId = Guid.NewGuid();
                    success = await InsertUser(
                        userId,
                        userdetails);
                    if (success)
                    {
                        return await _productCustomRepo.CommitTransactionAsync();
                    }
                }
                return false;
            }
            catch (AppException ex)
            {
                throw;
            }
        }

        private async Task<bool> InsertUser(Guid userId, UserDto userdetails)
        {
            RefUser user = new RefUser();
            userId = userdetails.UserId;
            user.UserName = userdetails.UserName;
            user.Password = userdetails.Password;
            user.Country = userdetails.Country;
            user.EmailId = userdetails.EmailId;
            user.CreatedTS = DateTime.UtcNow;
            return await _productCustomRepo.CreateUserAsync(user);
        }
    }
}