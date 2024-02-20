using application.Feature.PDPA.Commands;
using application.Feature.PDPA.DTO;
using application.Feature.PDPA.Queries;
using domain.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.v1
{
    [Route("api/v1/")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PdpaConsentController : ApiControllerBase
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
        /// GetId PDPA Consent
        /// </summary>
        /// <param name="GetId">PdpaConsentGetId</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Return</returns>
        [HttpPost("pdpa-consent-id")]
        public async Task<ActionResult<ResultResponse<List<PdpaConsentDto>>>> GetId([FromBody] PdpaConsentGetId GetId, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(GetId, cancellationToken));
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

        /// <summary>
        ///  Update PdpaConsent
        /// </summary>
        /// <param name="Update">PdpaConsentCreate</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Return</returns>
        [HttpPost("pdpa-consent-Update")]
        public async Task<ActionResult<ResultResponse<List<PdpaConsentDto>>>> Update([FromBody] PdpaConsentUpdate Update, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(Update, cancellationToken));
        }

        /// <summary>
        ///  Delete PdpaConsent
        /// </summary>
        /// <param name="Delete">PdpaConsentDelete</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Return</returns>
        [HttpDelete("pdpa-consent-Delete")]
        public async Task<ActionResult<ResultResponse<List<PdpaConsentDto>>>> Delete([FromBody] PdpaConsentDelete Delete, CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(Delete, cancellationToken));
        }
    }
}
