using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.SaveAnswer
{
    public class QuestionSaveAnswerDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer ToEntity()
            => new()
            {
                Id=this.Id,
                QuestionId=this.Id,
                Text=this.Text,
                IsCorrect=this.IsCorrect,
            };
    }
}
