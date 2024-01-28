using Quizer.Models.DTOs.QuestionSets.Create;

namespace Quizer.Core.Services
{
    public interface IQuestionSetService
    {
        public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request);
    }
}
