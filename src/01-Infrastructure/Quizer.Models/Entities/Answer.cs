using Quizer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class Answer : BaseEntity<Guid>
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QusetionId { get; set; }
    }
}
