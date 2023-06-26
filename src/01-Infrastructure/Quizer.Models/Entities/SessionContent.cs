using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class SessionContent
    {
        public Guid SessionId { get; set; }
        public Guid SubscriberId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public bool Success { get; set; }
    }
}
