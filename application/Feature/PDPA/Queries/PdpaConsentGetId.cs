using application.Feature.PDPA.DTO;
using domain.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Queries;

public sealed record  PdpaConsentGetId(int Id): IRequest<ResultResponse<List<PdpaConsentDto>>>
{
}

