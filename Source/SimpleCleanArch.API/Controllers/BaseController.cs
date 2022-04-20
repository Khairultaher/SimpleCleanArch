using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCleanArch.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public BaseController()
        {

        }
    }
}
