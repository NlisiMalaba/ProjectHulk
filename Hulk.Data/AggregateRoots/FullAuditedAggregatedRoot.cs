using Hulk.Data.Entities;

namespace Hulk.Data.AggregateRoots
{
    public class FullAuditedAggregatedRoot<T> : AuditedAggregatedRoot<T>
    {
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
        public Account? LastModifierUser { get; set; }

        public void PrepareEntityForUpdate (Account account)
        {
            LastModifierUserId = account.Id;
            LastModificationTime = DateTime.UtcNow;
        }

        public void PrepareForCreateAndUpdate(Account account)
        {
            PrepareEntityForCreate(account);
            PrepareEntityForUpdate(account);
        }
    }
}
