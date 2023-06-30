using Quizer.Core.Repositories.Special;
using Quizer.Core.Services;
using Quizer.Models.DTOs.QuestionSets.Create;
using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Application.Services
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;
        public QuestionSetService(IQuestionSetRepository questionSetRepository) 
        { 
            _questionSetRepository = questionSetRepository;
        }
        public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request)
        {
            var entity = request.ToEntity();

            entity = _questionSetRepository.Add(entity);
            _questionSetRepository.Save();

            var response = QuestionSetCreateResponseDto.Create(entity);
            return response;
        }
    }
}
