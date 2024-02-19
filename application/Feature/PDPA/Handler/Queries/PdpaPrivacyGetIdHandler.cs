using application.Feature.PDPA.DTO;
using application.Feature.PDPA.Queries;
using AutoMapper;
using domain.Common.DTO;
using domain.Constants;
using domain.IRepositories.PDPA;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Handler.Queries;

internal class PdpaPrivacyGetIdHandler : IRequestHandler<PdpaPrivacyGetId, ResultResponse<List<PdpaPrivacyDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IPdpaPrivacyRepository _repository;

    public PdpaPrivacyGetIdHandler(IMapper mapper, IPdpaPrivacyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ResultResponse<List<PdpaPrivacyDTO>>> Handle(PdpaPrivacyGetId request, CancellationToken cancellationToken)
    {
        List<PdpaPrivacyDTO> ds = new List<PdpaPrivacyDTO>(); 
        var item = await _repository.GetAsync(request.Id, cancellationToken);
        if (item == null)
        {
            var message = string.Concat(nameof(PdpaPrivacyGetId), ErrorMessageConstant.NotFoundContent);
            Log.Information(message);
            throw new Exception(message);
        }
        var response = _mapper.Map<PdpaPrivacyDTO>(item);
        ds.Add(response);
        return new ResultResponse<List<PdpaPrivacyDTO>>(ds, serviceName: nameof(PdpaPrivacyGetId));
    }
}
