using Quizer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class QuestionSet : BaseEntity<Guid>
    {
        public string Subject { get; set; }
    }
}
