using Hulk.Data.Entities;

namespace Hulk.Data.AggregateRoots
{
    public class AuditedAggregatedRoot<T> : BasicAggregatedRoot<T>
    {
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public int? CreatorId { get; set; }
        public Account? Creator { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int? DeleterId { get; set; }
        public Account? Deleter { get; set; }

        public void PrepareEntityForDelete(Account account)
        {
            IsDeleted = true;
            DeleterId = account.Id;
            DeletionTime = DateTime.UtcNow;
        }

        public void PrepareEntityForCreate(Account account)
        {
            CreatorId = account.Id;
            CreationTime = DateTime.UtcNow;
        }



    }
}
