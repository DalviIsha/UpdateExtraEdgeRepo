using Domain.Dto;
using WebApplication1.Domain.Abstractions;
using WebApplication1.Domain.Common;
using System.Collections.Generic;
using WebApplication1.API.Controllers;

namespace WebApplication1.Domain.RequestModels.Query
{
    public record GetAuthenticationTokenQuery(string userName, string password)
        : IQuery<string>;
}