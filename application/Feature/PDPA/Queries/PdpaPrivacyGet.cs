using MediatR;
using application.Feature.PDPA.DTO;
using domain.Common.DTO;

namespace application.Feature.PDPA.Queries
{
    public sealed class PdpaPrivacyGet : BaseFilterSearch, IRequest<ResultResponse<List<PdpaPrivacyDTO>>>
    {
    }
}
