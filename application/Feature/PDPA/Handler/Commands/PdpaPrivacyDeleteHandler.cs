using application.Feature.PDPA.Commands;
using domain.Common.DTO;
using domain.Common.Exceptions;
using domain.Constants;
using domain.IRepositories.PDPA;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Feature.PDPA.Handler.Commands;

internal class PdpaPrivacyDeleteHandler(IPdpaPrivacyRepository repository) : IRequestHandler<PdpaPrivacyDelete, ResultResponse<List<bool>>>
{
    IPdpaPrivacyRepository _repository = repository ;
    public async Task<ResultResponse<List<bool>>>Handle(PdpaPrivacyDelete request, CancellationToken cancellationToken)
    {
        List<bool> Result = [];
        var message = string.Empty;
        var item = await _repository.GetFirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (item is null)
        {
            Result.Add(false);
            message = ResponseMessageConstant.GetStatusCode204;
            Log.Information(message);
            throw new NoContentException(message);
        }
        item.Status = 0;
        item.DeletionTime = DateTime.UtcNow;
        item.IsDeleted = 1;
        var response = await _repository.UpdateAsync(item, cancellationToken);
        if (response is null)
        {
            Result.Add(false);
            message = ResponseMessageConstant.DeleteStatusCode204;
            return new(Result, serviceName: nameof(PdpaPrivacyDelete), message: message);
        }
        Result.Add(true);
        message = ResponseMessageConstant.DeleteStatusCode200;
        return new(Result, serviceName: nameof(PdpaPrivacyDelete), message: message);
    }

}

