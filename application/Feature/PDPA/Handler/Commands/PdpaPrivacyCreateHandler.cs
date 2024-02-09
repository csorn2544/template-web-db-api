using application.Common.Interface;
using application.Feature.PDPA.Commands;
using AutoMapper;
using domain.Common.DTO;
using domain.Constants;
using domain.Entities.PDPA;
using domain.IRepositories.PDPA;
using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Handler.Commands
{
    
    public sealed class PdpaPrivacyCreateHandler(IMapper mapper,
                        IPdpaPrivacyRepository repository,
                        IRequestHeaders requestHeaders) :
                        IRequestHandler<PdpaPrivacyCreate, ResultResponse<List<bool>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPdpaPrivacyRepository _repository = repository;
        private readonly IRequestHeaders _requestHeaders = requestHeaders;

        public async Task<ResultResponse<List<bool>>> Handle(PdpaPrivacyCreate request, CancellationToken cancellationToken)
        {
            List<bool> Result = [];
            string Message = string.Empty;
            var item = _mapper.Map<PdpaPrivacy>(request);
            item.CreationTime = DateTime.Now;
            item.Status = 1;
            item.IsDeleted = 0;
            Log.Information(_requestHeaders.Get().Oid);
            var response = await _repository.CreateAsync(item, cancellationToken);
            if (response is null)
            {
                Result.Add(false);
                Message = ResponseMessageConstant.CreateStatusCode204;
                return new(Result, nameof(PdpaPrivacyCreate), message: Message);
            }
            Result.Add(true);
            Message = ResponseMessageConstant.CreateStatusCode201;
            return new(Result, nameof(PdpaPrivacyCreate), message: Message);
        }
    }
}
