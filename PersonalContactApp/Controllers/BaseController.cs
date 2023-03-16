using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PersonalContactApp.Controllers;

[EnableCors("OpenCORSPolicy")]
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private ISender _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
}
