using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.QuestionSets.Create
{
    public class QuestionSetCreateResponseDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
    }
}
