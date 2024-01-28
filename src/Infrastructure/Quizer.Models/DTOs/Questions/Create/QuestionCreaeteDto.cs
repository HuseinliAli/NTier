using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.Create
{
    public class QuestionCreateDto
    {
        public Guid QuestionSetId { get; set; }
        public string Text { get; set; }
        public byte Point { get; set; }

        public Question ToEntity()
            =>new Question() { Id=Guid.NewGuid(),Text=this.Text, Point=this.Point ,QuestionSetId=this.QuestionSetId};
    }
}
