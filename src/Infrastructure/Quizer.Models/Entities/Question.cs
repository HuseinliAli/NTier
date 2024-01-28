using Quizer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class Question:BaseEntity<Guid>
    {
        public string Text { get; set; }
        public Guid QuestionSetId { get; set; }
    }
    public class QuestionSet : BaseEntity<Guid>
    {
        public string Subject { get; set; }
    }
    public class Answer : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
    public class Session : BaseEntity<Guid>
    {
        public string Code { get; set; }
        public Guid QuestionSetId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class SessionContent
    {
        public Guid SessionId { get; set; }
        public Guid SubscriberId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public bool Success { get; set; }
    }
    public class Subscriber:BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
