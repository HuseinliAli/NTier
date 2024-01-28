using Quizer.Models.Entities;

namespace Quizer.Models.DTOs.Questions.Create
{
    public class QuestionCreateResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public byte Point { get; set; }

        public static QuestionCreateResponseDto Create(Question model)
            => new() { Id=model.Id, Text=model.Text, Point=model.Point };
    }
}
