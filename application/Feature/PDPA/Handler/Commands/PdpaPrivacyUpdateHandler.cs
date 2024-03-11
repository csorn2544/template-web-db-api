using application.Feature.PDPA.Commands;
using domain.Common.DTO;
using domain.Constants;
using domain.IRepositories;
using domain.IRepositories.PDPA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Handler.Commands;

public sealed class PdpaPrivacyUpdateHandler(IPdpaPrivacyRepository repository) : IRequestHandler<PdpaPrivacyUpdate, ResultResponse<List<bool>>>
{
    private readonly IPdpaPrivacyRepository _repository = repository;

    public async Task<ResultResponse<List<bool>>> Handle(PdpaPrivacyUpdate request, CancellationToken cancellationToken)
    {
        List<bool> Result = new List<bool>();
        var message = string.Empty;
        var item = await _repository.GetFirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (item == null)
        {
            // Data not found, return appropriate response
            Result.Add(false);
            message = ResponseMessageConstant.GetStatusCode204;
            return new ResultResponse<List<bool>>(Result, nameof(PdpaPrivacyUpdate), message: message);
        }

        // Data found, proceed with the update
        item.PpCode = request.PpCode ?? item.PpCode;
        item.Version = request.Version ?? item.Version;
        item.TitleTh = request.TitleTh ?? item.TitleTh;
        item.TitleEn = request.TitleEn ?? item.TitleEn;
        item.TitleZh = request.TitleZh ?? item.TitleZh;
        item.DescriptionTh = request.DescriptionTh ?? item.DescriptionTh;
        item.DescriptionEn = request.DescriptionEn ?? item.DescriptionEn;
        item.DescriptionZh = request.DescriptionZh ?? item.DescriptionZh;
        item.Status = request.Status;
        item.LastModificationTime = DateTime.UtcNow;

        var response = await _repository.UpdateAsync(item, cancellationToken);

        if (response == null)
        {
            Result.Add(false);
            message = ResponseMessageConstant.UpdateStatusCode204;
            return new ResultResponse<List<bool>>(Result, nameof(PdpaPrivacyUpdate), message: message);
        }

        Result.Add(true);
        message = ResponseMessageConstant.UpdateStatusCode200;
        return new ResultResponse<List<bool>>(Result, nameof(PdpaPrivacyUpdate), message: message);
    }
}


