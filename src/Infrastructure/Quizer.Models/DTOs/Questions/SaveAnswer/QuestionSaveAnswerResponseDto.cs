using Quizer.Models.Entities;
using System.Runtime.CompilerServices;

namespace Quizer.Models.DTOs.Questions.SaveAnswer
{
    public class QuestionSaveAnswerResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public static QuestionSaveAnswerResponseDto SaveAnswer(Answer model)
            => new() { Id=model.Id, IsCorrect=model.IsCorrect, Text=model.Text };
    }
}
