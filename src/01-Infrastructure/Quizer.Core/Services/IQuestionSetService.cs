using Quizer.Models.DTOs.QuestionSets.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Core.Services
{
    public interface IQuestionSetService
    {
        public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request);
    }
}
