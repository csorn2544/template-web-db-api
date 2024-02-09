using application.Feature.PDPA.Commands;
using application.Feature.PDPA.DTO;
using application.Feature.PDPA.Queries;
using domain.Common.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace api.Controllers.v1;

[Route("api/v1/")]
[ApiExplorerSettings(GroupName = "v1")]
public class PdpaPrivacyController : ApiControllerBase
{
    /// <summary>
    ///  Get PDPA Privacy
    /// </summary>
    /// <param name="Get">PdpaPrivacyGet</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Return</returns>
    [HttpPost("pdpa-privacy-get")]
    public async Task<ActionResult<ResultResponse<List<PdpaPrivacyDTO>>>> Get([FromBody] PdpaPrivacyGet Get, CancellationToken cancellationToken = default)
    {
        return Ok(await _mediator.Send(Get, cancellationToken));
    }

   /* 
    /// <summary>
    ///  Create PdpaPrivacy
    /// </summary>
    /// <param name="Create">PdpaPrivacyCreate</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Return</returns>
    [HttpPost("pdpa-privacy-create")]
    public async Task<ActionResult<ResultResponse<List<PdpaPrivacyDTO>>>> Create([FromBody] PdpaPrivacyCreate Create, CancellationToken cancellationToken = default)
    {
        return Ok(await _mediator.Send(Create, cancellationToken));
    }*/
}

