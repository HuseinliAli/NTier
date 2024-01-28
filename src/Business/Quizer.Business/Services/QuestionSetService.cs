using Quizer.Core.Repositories.Special;
using Quizer.Core.Services;
using Quizer.Models.DTOs.QuestionSets.Create;
using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Business.Services
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;

        public QuestionSetService(IQuestionSetRepository questionSetRepository)
        {
            _questionSetRepository=questionSetRepository;
        }

        public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request)
        {
            var entity = new QuestionSet() { Subject= request.Subject };

            entity = _questionSetRepository.Add(entity);
            _questionSetRepository.SaveChanges();

            var response = new QuestionSetCreateResponseDto()
            {
                Id=entity.Id,
                Subject=entity.Subject
            };

            return response;
        }
    }
}
