using domain.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Commands;

public sealed record PdpaConsentDelete(int Id) : IRequest<ResultResponse<List<bool>>>
{
}
