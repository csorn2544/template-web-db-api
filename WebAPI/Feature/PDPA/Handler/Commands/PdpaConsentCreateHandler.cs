using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.Headers;
using Serilog;
using WebAPI.Common.DTO;
using WebAPI.Common.Interface;
using WebAPI.Constants;
using WebAPI.Feature.PDPA.Commands;
using WebAPI.Models.IRepositories.PDPA;
using Entities = WebAPI.Models;

namespace WebAPI.Feature.PDPA.Handler.Commands
{
    public sealed class PdpaConsentCreateHandler(IMapper mapper,
                            IPdpaConsentRepository repository,
                            IRequestHeaders requestHeaders)
                            : IRequestHandler<PdpaConsentCreate, ResultResponse<List<bool>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPdpaConsentRepository _repository = repository;
        private readonly IRequestHeaders _requestHeaders = requestHeaders;

        public async Task<ResultResponse<List<bool>>> Handle(PdpaConsentCreate request, CancellationToken cancellationToken)
        {
            List<bool> result = [];
            var message = string.Empty;
            var item = _mapper.Map<Models.PDPA.PdpaConsent>(request);
            item.CreationTime = DateTime.Now;
            Log.Information(_requestHeaders.Get().Oid);
            var response = await _repository.CreateAsync(item, cancellationToken);
            if (response is null)
            {
                result.Add(false);
                message = ResponseMessageConstant.CreateStatusCode204;
                return new(result, nameof(PdpaConsentCreate), message: message);
            }
            result.Add(true);
            message = ResponseMessageConstant.CreateStatusCode201;
            return new(result, nameof(PdpaConsentCreate), message: message);
        }
    }
}
