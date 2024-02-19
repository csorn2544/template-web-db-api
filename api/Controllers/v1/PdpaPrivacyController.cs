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

    ///<summary>
    ///Get Id PDPA Privacy
    /// </summary>
    /// <param name="GetId">PdpaPrivacyGetID</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Return</returns>
    [HttpPost("pdpa-privacy-id")]
    public async Task<ActionResult<ResultResponse<List<PdpaPrivacyDTO>>>> Get([FromBody] PdpaPrivacyGetId GetId,CancellationToken cancellationToken= default)
    {
        return Ok(await _mediator.Send(GetId, cancellationToken));
    }

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
    }

    /// <summary>
    /// Update PdpaPrivacy
    /// </summary>
    /// <param name="Update">PdpaPrivacyUpdate</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Return</returns>

    [HttpPut("pdpa-privacy-update")]
    public async Task<ActionResult<ResultResponse<List<PdpaPrivacyDTO>>>> Update([FromBody] PdpaPrivacyUpdate Update,CancellationToken cancellationToken = default)
    {
        return Ok(await _mediator.Send(Update, cancellationToken));
    }

    /// <summary>
    /// Delete PdpaPrivacy
    /// </summary>
    /// <param name="Delete">PdpaPrivacyDelete</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <remarks>Return</remarks>
    [HttpDelete("pdpa-privacy-delete")]
    public async Task<ActionResult<ResultResponse<List<PdpaPrivacyDTO>>>> Delete([FromBody] PdpaPrivacyDelete Delete,CancellationToken cancellationToken = default)
    {
        return Ok(await _mediator.Send(Delete, cancellationToken));
    }

}

