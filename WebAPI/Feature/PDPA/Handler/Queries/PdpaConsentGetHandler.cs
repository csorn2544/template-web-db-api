using AutoMapper;
using MediatR;
using WebAPI.Common.DTO;
using WebAPI.Common.Helper;
using WebAPI.Feature.PDPA.DTO;
using WebAPI.Feature.PDPA.Queries;
using WebAPI.Models.Enum;
using WebAPI.Models.IRepositories.PDPA;
using Models = WebAPI.Models;

namespace WebAPI.Feature.PDPA.Handler.Queries
{
    public sealed class PdpaConsentGetHandler(IMapper mapper, IPdpaConsentRepository repository) : IRequestHandler<PdpaConsentGet, ResultResponse<List<PdpaConsentDto>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPdpaConsentRepository _repository = repository;

        public async Task<ResultResponse<List<PdpaConsentDto>>> Handle(PdpaConsentGet request, CancellationToken cancellationToken)
        {
            var filter = ExpressionBuilder.True<Models.PDPA.PdpaConsent>();
            filter.And(e => e.IsDeleted == 0);
            var keyWordSearch = string.Empty;
            if (!string.IsNullOrEmpty(request.FilterValue) || request.FilterType == 0)
            {
                keyWordSearch = request.FilterValue.Trim().ToLower();
                filter = request.FilterType switch
                {
                    (int)FilterSearchPdpaConsent.TC_Code => filter.And(e => e.ConCode.Contains(keyWordSearch)),
                    (int)FilterSearchPdpaConsent.TitleEN => filter.And(e => e.TitleEn.Contains(keyWordSearch)),
                    (int)FilterSearchPdpaConsent.DescriptionEN => filter.And(e => e.DescriptionEn.Contains(keyWordSearch)),
                    (int)FilterSearchPdpaConsent.Version => filter.And(e => e.Version.Contains(keyWordSearch)),
                    (int)FilterSearchPdpaConsent.CreationDate => filter.And(e => e.CreationTime.Value.Date == ConvertHelper.StrToDate(keyWordSearch)),
                    (int)FilterSearchPdpaConsent.LastModificationTime => filter.And(e => e.LastModificationTime.Value.Date == ConvertHelper.StrToDate(keyWordSearch)),
                    (int)FilterSearchPdpaConsent.Status => filter.And(e => (Convert.ToBoolean(e.Status.Value) ? "active" : "inactive") == keyWordSearch),
                    _ => filter,
                };
            }
            var item = await _repository.GetAsync(filter, request.PageNumber, request.PageSize, cancellationToken);
            var ds = _mapper.Map<List<PdpaConsentDto>>(item);
            int TotalItems = _repository.GetAsync(filter).Count();
            return new(ds, request.PageNumber, request.PageSize, totalItems: TotalItems, serviceName: nameof(PdpaConsentGetHandler));
        }
    }
}
