using application.Feature.Common.Dto;
using application.Feature.Common.Queries;
using AutoMapper;
using domain.Common.DTO;
using domain.IRepositories;
using MediatR;
namespace application.Feature.Common.Handler
{
    public sealed class PnpMGeneralGetHandler(IMapper mapper, IPnpMGeneralRepository repository) : IRequestHandler<PnpMGeneralGet, ResultResponse<List<PnpMGeneralDto>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPnpMGeneralRepository _repository = repository;
        public async Task<ResultResponse<List<PnpMGeneralDto>>> Handle(PnpMGeneralGet request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetAsync(e => e.DeletedFlag == 1 && e.Typegroup == request.TypeGroup, cancellationToken);
            var ds = _mapper.Map<List<PnpMGeneralDto>>(item.OrderBy(o => o.Typevalue));
            return new(ds, serviceName: nameof(PnpMGeneralGet));
        }
    }
}
