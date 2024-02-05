using WebAPI.Models.Interfaces;

namespace WebAPI.Models
{
    [Serializable]
    public abstract class Auditable : IAudited
    {
        public long? CreatorUserId { get; set; }
        public DateTime? CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public ulong IsDeleted { get; set; }
    }
}
