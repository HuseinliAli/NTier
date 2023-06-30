using Quizer.Core.Extensions;
using Quizer.Core.Repositories.Special;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.GetById;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.DTOs.Questions.SaveAnswer;
using Quizer.Models.DTOs.QuestionSets.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository=answerRepository;

        }
        public QuestionCreateResponseDto Create(QuestionCreateDto request)
        {
            var entity = request.ToEntity();

            entity = _questionRepository.Add(entity);
            _questionRepository.Save();

            var response = QuestionCreateResponseDto.Create(entity);
            return response;
        }
        public QuestionGetByIdResponseDto GetById(Guid id)
        {
            var entity = _questionRepository.GetFirst(e => e.Id == id);
            return QuestionGetByIdResponseDto.Create(entity);
        }

        public void Remove(Guid id)
        {
            var entity = _questionRepository.GetFirst(e => e.Id == id);
            _questionRepository.Remove(entity);
            _questionRepository.Save();
        }

        public void RemoveAnswer(Guid id)
        {

            var entity =_answerRepository.GetFirst(e => e.Id == id);
            _answerRepository.Remove(entity);
        }

        public void Save(QuestionSaveDto request)
        {
            var question = _questionRepository.GetFirst(m => m.Id == request.Id);
            _questionRepository.Edit(question, entry =>
            {
                entry.SetValue(m => m.Text, request.Text)
                .SetValue(m => m.QuestionSetId, request.QuestionSetId)
                .SetValue(m => m.Point, request.Point);
            });

            var correctAnswer = _answerRepository.GetFirst(m => m.Id==request.CorrectAnswerId);
            _answerRepository.Edit(correctAnswer, entry =>
            {
                entry.SetValue(m => m.IsCorrect, true);
            });

            var otherAnswers = _answerRepository.GetAll(m => m.QusetionId == request.Id && m.Id != request.CorrectAnswerId).ToArray();

            foreach (var item in otherAnswers)
            {
                _answerRepository.Edit(item, entry =>
                {
                    entry.SetValue(a => a.IsCorrect, false);
                });
            }
        }

        public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request)
        {
            var answer = _answerRepository.GetFirst(a => a.Id == request.Id);
            var otherAnswers = _answerRepository.GetAll(m=>m.QusetionId == answer.QusetionId && m.Id != request.Id).ToArray();

            if(answer == null)
            {
                answer = request.ToEntity();
                _answerRepository.Add(answer);
            }
            else
            {
                _answerRepository.Edit(answer, entry =>
                {
                    entry.SetValue(m => m.IsCorrect, request.IsCorrect);
                    entry.SetValue(m => m.Text, request.Text);
                    entry.SetValue(m => m.QusetionId, request.SetId);
                });
            }
            if (request.IsCorrect)
            {
                foreach (var item in otherAnswers)
                {
                    _answerRepository.Edit(item, entry =>
                    {
                        entry.SetValue(a => a.IsCorrect, false);
                    });
                }
            }
            _answerRepository.Save();
            return QuestionSaveAnswerResponseDto.Create(answer);
        }
    }
}
