using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.RequestModels.Query;

namespace WebApplication1.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AutheticationController : BaseController
    {
        
        [HttpPost]
        [Route ("authentication")]
        public async Task<IActionResult> AuthenticationToken([FromBody] RefUser userDetails)
        {
           var token =  Ok(await Sender.Send(new GetAuthenticationTokenQuery(userDetails.UserName, userDetails.Password)));
           if(token is null)
           {
            return NotFound();
           }
            return Ok(token);
        }
    }
}