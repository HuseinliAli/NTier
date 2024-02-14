using Quizer.Models.Common;

namespace Quizer.Models.Entities
{
    public class Answer : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
}
