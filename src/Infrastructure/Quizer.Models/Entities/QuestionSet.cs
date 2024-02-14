using Quizer.Models.Common;

namespace Quizer.Models.Entities
{
    public class QuestionSet : BaseEntity<Guid>
    {
        public string Subject { get; set; }
    }
}
