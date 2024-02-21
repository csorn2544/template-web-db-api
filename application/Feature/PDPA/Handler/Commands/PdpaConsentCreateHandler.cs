using AutoMapper;
using domain.Common.DTO;
using domain.Constants;
using domain.Entities.PDPA;
using domain.IRepositories.PDPA;
using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Commands
{
    public sealed class PdpaConsentCreateHandler(IMapper mapper,
                        IPdpaConsentRepository repository) : IRequestHandler<PdpaConsentCreate, ResultResponse<List<bool>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPdpaConsentRepository _repository = repository;
        public async Task<ResultResponse<List<bool>>> Handle(PdpaConsentCreate request, CancellationToken cancellationToken)
        {
            List<bool> result = [];
            var message = string.Empty;
            var item = _mapper.Map<PdpaConsent>(request);
            item.CreationTime = DateTime.UtcNow;
            item.Status = 1;
            item.CreatorUserId = request.CreatorUserId;
            var response = await _repository.CreateAsync(item, cancellationToken);
            if (response is null)
            {
                result.Add(false);
                message = ResponseMessageConstant.CreateStatusCode204;
                return new ResultResponse<List<bool>>(result, nameof(PdpaConsentCreate), message: message);
            }
            else
            {
                result.Add(true);
                message = ResponseMessageConstant.CreateStatusCode201;
                return new ResultResponse<List<bool>>(result, nameof(PdpaConsentCreate), message: message);
            }
        }
    }
}
