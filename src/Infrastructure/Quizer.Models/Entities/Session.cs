using Quizer.Models.Common;

namespace Quizer.Models.Entities
{
    public class Session : BaseEntity<Guid>
    {
        public string Code { get; set; }
        public Guid QuestionSetId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
