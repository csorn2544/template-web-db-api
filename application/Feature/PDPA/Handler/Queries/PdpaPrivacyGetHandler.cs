using application.Feature.PDPA.DTO;
using application.Feature.PDPA.Queries;
using AutoMapper;
using domain.Common.DTO;
using domain.Common.Helper;
using domain.Entities.PDPA;
using domain.Enum;
using domain.IRepositories.PDPA;
using MediatR;

public sealed class PdpaPrivacyPolicyGetHandler(IMapper mapper, IPdpaPrivacyRepository repository) : IRequestHandler<PdpaPrivacyGet, ResultResponse<List<PdpaPrivacyDTO>>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPdpaPrivacyRepository _repository = repository;

    public async Task<ResultResponse<List<PdpaPrivacyDTO>>> Handle(PdpaPrivacyGet request, CancellationToken cancellationToken)
    {
        var filter = ExpressionBuilder.True<PdpaPrivacy>();
        filter.And(e => e.IsDeleted == 0);
        var keyWordSearch = string.Empty;
        if (!string.IsNullOrEmpty(request.FilterValue) || request.FilterType == 0)
        {
            keyWordSearch = request.FilterValue.Trim().ToLower();
            filter = request.FilterType switch
            {
                (int)FilterSearchPdpaPrivacyPolicy.PP_Code => filter.And(e => e.PpCode.Contains(keyWordSearch)),
                (int)FilterSearchPdpaPrivacyPolicy.TitleEN => filter.And(e => e.TitleEn.Contains(keyWordSearch)),
                (int)FilterSearchPdpaPrivacyPolicy.DescriptionEN => filter.And(e => e.DescriptionEn.Contains(keyWordSearch)),
                (int)FilterSearchPdpaPrivacyPolicy.Version => filter.And(e => e.Version.Contains(keyWordSearch)),
                (int)FilterSearchPdpaPrivacyPolicy.CreationDate => filter.And(e => e.CreationTime.Value.Date == ConvertHelper.StrToDate(keyWordSearch)),
                (int)FilterSearchPdpaPrivacyPolicy.LastModificationTime => filter.And(e => e.LastModificationTime.Value.Date == ConvertHelper.StrToDate(keyWordSearch)),
                (int)FilterSearchPdpaPrivacyPolicy.Status => filter.And(e => (Convert.ToBoolean(e.Status) ? "active" : "inactive") == keyWordSearch),
                _ => filter,
            };
        }

        var item = await _repository.GetAsync(filter, request.PageNumber, request.PageSize, cancellationToken);
        var ds = _mapper.Map<List<PdpaPrivacyDTO>>(item);
        int TotalItems = _repository.GetAsync(filter).Count();
        return new(ds, request.PageNumber, request.PageSize, TotalItems, nameof(PdpaPrivacyGet));
    }
}