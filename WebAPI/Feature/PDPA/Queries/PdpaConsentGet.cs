using MediatR;
using WebAPI.Common.DTO;
using WebAPI.Feature.PDPA.DTO;

namespace WebAPI.Feature.PDPA.Queries
{
    public sealed class PdpaConsentGet : BaseFilterSearch, IRequest<ResultResponse<List<PdpaConsentDto>>>
    {
    }
}
