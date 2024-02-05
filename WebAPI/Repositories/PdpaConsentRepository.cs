using WebAPI.Models.IRepositories.PDPA;
using WebAPI.Models.PDPA;
using WebAPI.Persistence;
using WebAPI.Repositories.Base;

namespace WebAPI.Repositories
{
    internal sealed class PdpaConsentRepository(_dbContext context) : BaseRepository<PdpaConsent, _dbContext>(context), IPdpaConsentRepository
    {
    }

}
