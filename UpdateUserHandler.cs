using Habanero.Base.DataMappers;
using Realms.Sync.Exceptions;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.Interfaces.Repositories.RepoWrappers.CustomRepo;
using WebApplication1.Domain.RequestModels.CommandRequestModels.User;

namespace WebApplication1.Infrastructure.Service
{
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, bool>
    {
        private readonly IProductCustomRepo _productCustomRepo;
        public UpdateUserHandler(IProductCustomRepo productCustomRepo)
        {
            _productCustomRepo = productCustomRepo;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userdetails = request.userDetails;
                var userId = request.UserId;
                bool success;
                if (userdetails is { })
                {
                    success = await UpdateUser(
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

        private async Task<bool> UpdateUser(Guid userId, UserDto userdetails)
        {
            var user = _productCustomRepo.GetUser(userId);
            var updateuser = DataMapper.Map(userdetails,
                                            user,
                                            MapperConfig.DefaultConfig);
            return await _productCustomRepo.UpdateUserAsync(updateuser);
        }
    }
}