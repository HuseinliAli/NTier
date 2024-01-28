using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.Save
{
    public class QuestionSaveDto
    {
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public byte Point { get; set; }
        public Guid QuestionSetId { get; set; }
        public Guid CorrectAnswerId { get; set; }
    }

}
