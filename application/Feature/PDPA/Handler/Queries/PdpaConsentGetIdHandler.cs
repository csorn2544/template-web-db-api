using application.Feature.PDPA.DTO;
using application.Feature.PDPA.Queries;
using AutoMapper;
using domain.Common.DTO;
using domain.Constants;
using domain.Entities.PDPA;
using domain.IRepositories;
using domain.IRepositories.PDPA;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Handler.Queries;

internal class PdpaConsentGetIdHandler : IRequestHandler<PdpaConsentGetId, ResultResponse<List<PdpaConsentDto>>>
{
    private readonly IMapper _mapper;
    private readonly IPdpaConsentRepository _repository;

    public  PdpaConsentGetIdHandler(IMapper mapper, IPdpaConsentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ResultResponse<List<PdpaConsentDto>>> Handle(PdpaConsentGetId request, CancellationToken cancellationToken)
    {
        List<PdpaConsentDto> ds = new List<PdpaConsentDto>();
        var item = await _repository.GetAsync(request.Id, cancellationToken);
        if (item == null)
        {
            var message = string.Concat(nameof(PdpaConsentGetId), ErrorMessageConstant.NotFoundContent);
            Log.Information(message);
            throw new Exception(message);
        }
        var response = _mapper.Map<PdpaConsentDto>(item);
        ds.Add(response);
        return new ResultResponse<List<PdpaConsentDto>>(ds, serviceName: nameof(PdpaConsentGetId));
    }

}

