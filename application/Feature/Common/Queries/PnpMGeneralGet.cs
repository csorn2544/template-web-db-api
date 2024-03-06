using application.Feature.Common.Dto;
using domain.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.Common.Queries
{
    public sealed class PnpMGeneralGet : IRequest<ResultResponse<List<PnpMGeneralDto>>>
    {
        public string TypeGroup { get; set; }
    }
}
