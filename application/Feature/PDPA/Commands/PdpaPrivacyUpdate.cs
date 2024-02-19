using domain.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Commands
{
    public sealed class PdpaPrivacyUpdate : IRequest<ResultResponse<List<bool>>>
    {
        public int Id { get; set; }
        public string PpCode { get; set; } = null;
        public ulong Status { get; set; }
        public string Version { get; set; } = null;
        public string TitleTh { get; set; } = null;
        public string TitleEn { get; set; } = null;
        public string TitleZh { get; set; } = null;
        public string DescriptionTh { get; set; } = null;
        public string DescriptionEn { get; set; } = null;
        public string DescriptionZh { get; set; } = null;
    }
}
