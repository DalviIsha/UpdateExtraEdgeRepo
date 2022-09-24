using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private ISender _sender;

        // private IPublisher _publisher;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();

        // protected IPublisher Publisher => _publisher ??= HttpContext.RequestServices.GetService<IPublisher>();
    }
}