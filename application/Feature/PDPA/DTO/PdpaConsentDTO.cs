using application.Common.Mappings;
using domain.Entities.PDPA;

namespace application.Feature.PDPA.DTO
{
    public class PdpaConsentDto : IMapFrom<PdpaConsent>
    {
        public int Id { get; set; }
        public string ConCode { get; set; } = null;
        public ulong? Status { get; set; }
        public string Version { get; set; } = null;
        public string TitleTh { get; set; } = null;
        public string TitleEn { get; set; } = null;
        public string TitleZh { get; set; } = null;
        public string DescriptionTh { get; set; } = null;
        public string DescriptionEn { get; set; } = null;
        public string DescriptionZh { get; set; } = null;
        public long? CreatorUserId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public ulong IsDeleted { get; set; }
    }
}
