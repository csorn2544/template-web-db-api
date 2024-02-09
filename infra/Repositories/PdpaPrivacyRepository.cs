using domain.Entities.PDPA;
using domain.IRepositories.PDPA;
using infra.Persistence;
using infra.Repositories.Base;

namespace infra.Repositories
{
    internal class PdpaPrivacyRepository(_dbContext context): BaseRepository<PdpaPrivacy,_dbContext>(context), IPdpaPrivacyRepository
    {
    }
}
