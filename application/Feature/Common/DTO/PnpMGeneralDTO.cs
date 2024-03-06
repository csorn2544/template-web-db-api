using domain.Entities.Pnp;
using application.Common.Mappings;

namespace application.Feature.Common.Dto
{
    public class PnpMGeneralDto : IMapFrom<PnpMGeneral>
    {
        public string TypeName { get; set; } = null;
        public string TypeValue { get; set; } = null;
        public string TypeEvent { get; set; } = null;
    }
}
