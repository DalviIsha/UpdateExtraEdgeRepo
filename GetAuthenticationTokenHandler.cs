using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.API.Controllers;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.RequestModels.Query;

namespace TestMS.API.Service
{
    public class GetAuthenticationTokenHandler : IQueryHandler<GetAuthenticationTokenQuery, string>
    {

        private readonly string key;
        public GetAuthenticationTokenHandler(string key)
        {
            this.key = key;
        }
        public async Task<string> Handle(GetAuthenticationTokenQuery request, CancellationToken cancellationToken)
        {
            var userName = request.userName;
            var password = request.password;

            List<RefUser> user = new List<RefUser>();
            if (!user.Any(x => x.UserName == userName && x.Password == password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokens = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(tokens);
        }
    }
}