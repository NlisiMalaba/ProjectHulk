using Hulk.Data.AggregateRoots;

namespace Hulk.Data.Entities
{
    public class Account : FullAuditedAggregatedRoot<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
