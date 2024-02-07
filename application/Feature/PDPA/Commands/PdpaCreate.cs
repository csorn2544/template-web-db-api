using domain.Common.DTO;
using MediatR;

namespace application.Feature.PDPA.Commands
{
    public sealed class PdpaConsentCreate : IRequest<ResultResponse<List<bool>>>
    {
        public string ConCode { get; set; } = null;
        public ulong Status { get; set; }
        public string Version { get; set; } = null;
        public string TitleTh { get; set; } = null;
        public string TitleEn { get; set; } = null;
        public string TitleZh { get; set; } = null;
        public string DescriptionTh { get; set; } = null;
        public string DescriptionEn { get; set; } = null;
        public string DescriptionZh { get; set; } = null;
        public long? CreatorUserId { get; set; }
    }
}
