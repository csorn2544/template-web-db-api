namespace domain.Entities.Interfaces
{
    public interface IAudited
    {
        long? CreatorUserId { get; set; }
        DateTime? CreationTime { get; set; }
        long? LastModifierUserId { get; set; }
        DateTime? LastModificationTime { get; set; }
        long? DeleterUserId { get; set; }
        DateTime? DeletionTime { get; set; }
        ulong IsDeleted { get; set; }
    }
}
