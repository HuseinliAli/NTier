namespace Quizer.Models.DTOs.Questions.Create
{
    public class QuestionCreateResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public byte Point { get; set; }
    }
}
