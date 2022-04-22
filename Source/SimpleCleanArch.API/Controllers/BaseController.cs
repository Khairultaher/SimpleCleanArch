using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCleanArch.API.ViewModels;

namespace SimpleCleanArch.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ResponseModel response = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        public BaseController()
        {
            response = new ResponseModel();
        }
    }
}
