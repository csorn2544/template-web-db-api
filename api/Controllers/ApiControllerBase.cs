using api.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    //[ServiceFilter(typeof(ExtractHeaderOnResourceFilterAttribute))]
    //[ServiceFilter(typeof(LogRequestOnActionFilterAtrribute))]
    //[ServiceFilter(typeof(LogResponseOnResultFilterAttribute))]
    [ServiceFilter(typeof(ApiFilterExceptionAttribute))]
    [Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender Mediator;
        protected ISender _mediator => Mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
