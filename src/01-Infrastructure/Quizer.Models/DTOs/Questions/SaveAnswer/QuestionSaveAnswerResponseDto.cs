using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.SaveAnswer
{
    public class QuestionSaveAnswerResponseDto
    {
        public Guid Id { get;set; }
        public bool IsCorrect { get; set; }
        public string Text { get; set; }
        public static QuestionSaveAnswerResponseDto Create(Answer model)
        {
            return new QuestionSaveAnswerResponseDto { Text = model.Text,Id=model.Id, IsCorrect=model.IsCorrect };
        }
    }
}
