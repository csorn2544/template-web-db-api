using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.DTO;
using WebAPI.Feature.PDPA.Commands;
using WebAPI.Feature.PDPA.DTO;
using WebAPI.Feature.PDPA.Queries;

namespace WebAPI.Controllers.v1
{
    [Route("api/v1/")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PdpaController : ApiControllerBase
    {
        /// <summary>
        ///  Get PDPA Consent
        /// </summary>
        /// <param name="Get">PdpaConsentGet</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Return</returns>
        [HttpPost("pdpa-consent-get")]
        public async Task<ActionResult<ResultResponse<List<PdpaConsentDto>>>> Get([FromBody] PdpaConsentGet Get, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(Get, cancellationToken));
        }

        /// <summary>
        ///  Create PdpaConsent
        /// </summary>
        /// <param name="Create">PdpaConsentCreate</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Return</returns>
        [HttpPost("pdpa-consent-create")]
        public async Task<ActionResult<ResultResponse<List<PdpaConsentDto>>>> updateCreate([FromBody] PdpaConsentCreate Create, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(Create, cancellationToken));
        }
    }
}
