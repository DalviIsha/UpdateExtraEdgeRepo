using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.RequestModels.CommandRequestModels.User;

namespace WebApplication1.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route ("user")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDetails)
        {
            return Ok(await Sender.Send(new CreateUserCommand(userDetails)));
        }

        [HttpPut]
        [Route ("user")]
        public async Task<IActionResult> UpdateUser([FromQuery]Guid userId ,[FromBody] UserDto userDetails)
        {
            return Ok(await Sender.Send(new UpdateUserCommand( userId,userDetails)));
        }
        
        
    }
}