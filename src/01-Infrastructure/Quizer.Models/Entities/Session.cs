using Quizer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class Session :BaseEntity<Guid>
    {
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid QuestionSetId { get; set; }
    }
}
