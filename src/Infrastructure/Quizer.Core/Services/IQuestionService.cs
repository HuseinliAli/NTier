using Quizer.Models.DTOs.Questions;
using Quizer.Models.DTOs.Questions;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.GetById;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.DTOs.Questions.SaveAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Services
{
    public interface IQuestionService 
    {
        public QuestionCreateResponseDto Create(QuestionCreateDto request);
        public QuestionGetByIdResponseDto GetById(Guid id);
        public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request);
        public void RemoveAnswer(Guid id);
        public void Remove(Guid id);
        public void Save(QuestionSaveDto request);
    }
}
