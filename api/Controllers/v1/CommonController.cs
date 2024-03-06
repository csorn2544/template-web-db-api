using application.Feature.Common.Dto;
using application.Feature.Common.Queries;
using domain.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.v1
{
    [Route("api/v1/common/")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CommonController : ApiControllerBase
    {
        /// <summary>
        ///  Get Filter Search
        /// </summary>
        /// <param name="Get">PnpMGeneralGet</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Return</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Filter
        ///     {
        ///        "typeGroup": "pdpa-consent",
        ///        "typeGroup": "pdpa-privacy",
        ///     }
        ///
        /// </remarks>
        [HttpPost("filter-search")]
        public async Task<ActionResult<ResultResponse<List<PnpMGeneralDto>>>> Get([FromBody] PnpMGeneralGet Get, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(Get, cancellationToken));
        }

    }
}
