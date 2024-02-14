using Quizer.Models.Common;

namespace Quizer.Models.Entities
{
    public class Subscriber:BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
