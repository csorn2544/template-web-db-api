using domain.Entities.Pnp;
using domain.IRepositories;
using infra.Persistence;
using infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repositories
{

    internal sealed class PnpMGeneralRepository(_dbContext context) : QueryRepository<PnpMGeneral,_dbContext>(context), IPnpMGeneralRepository
    {
    }
}
