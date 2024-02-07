using domain.Entities.PDPA;
using domain.IRepositories.PDPA;
using infra.Persistence;
using infra.Repositories.Base;

namespace infra.Repositories
{
    internal sealed class PdpaConsentRepository(_dbContext context) : BaseRepository<PdpaConsent, _dbContext>(context), IPdpaConsentRepository
    {
    }

}
