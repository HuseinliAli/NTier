using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.GetById;
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
        public QuestionGetByIdResponseDto GetById(int id);
    }
}
