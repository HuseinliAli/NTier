using Quizer.Models.DTOs.Questions;
using Quizer.Models.DTOs.Questions;
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
        QuestionCreateResponseDto Create(QuestionCreateDto dto);
        QuestionGetByIdResponseDto GetById(Guid id);
    }
}
