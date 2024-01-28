using Quizer.Core.Extensions;
using Quizer.Core.Repositories.Special;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.GetById;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.DTOs.Questions.SaveAnswer;
using Quizer.Models.Entities;

namespace Quizer.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public QuestionService(IQuestionRepository questionRepository,IAnswerRepository answerRepository)
        {
            _questionRepository=questionRepository;
            _answerRepository=answerRepository;
        }
        public QuestionCreateResponseDto Create(QuestionCreateDto request)
        {
            var entity = request.ToEntity();

            _questionRepository.Add(entity);
            _questionRepository.SaveChanges();

            var response = QuestionCreateResponseDto.Create(entity);
            return response;
        }

        public QuestionGetByIdResponseDto GetById(Guid id)
        {
            var entity = _questionRepository.GetFirst(x => x.Id==id);

            return QuestionGetByIdResponseDto.GetById(entity);
        }

        public void Remove(Guid id)
        {
            var entity = _questionRepository.GetFirst(x => x.Id==id);

            _questionRepository.Remove(entity);
            _questionRepository.SaveChanges();
        }

        public void RemoveAnswer(Guid id)
        {
            var entity = _answerRepository.GetFirst(x=>x.Id==id);
            _answerRepository.Remove(entity);
        }

        public void Save(QuestionSaveDto request)
        {
            var entity = _questionRepository.GetFirst(x => x.Id==request.QuestionId);

            _questionRepository.Edit(entity, entry =>
            {
                entry.SetValue(x => x.Text, request.Text)
                .SetValue(x => x.Point, request.Point)
                .SetValue(x => x.QuestionSetId, request.QuestionSetId);
            });

            var correctAnswer = _answerRepository.GetFirst(x => x.Id == request.CorrectAnswerId);

            _answerRepository.Edit(correctAnswer, entry => entry.SetValue(x => x.IsCorrect,true));

            var otherAnswers = _answerRepository.GetAll(x => x.QuestionId==request.QuestionId && x.Id !=request.CorrectAnswerId).ToList();
            foreach (var item in otherAnswers)
            {
                _answerRepository.Edit(item, entry =>
                {
                    entry.SetValue(m => m.IsCorrect, false);
                });
            }
        }

        public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request)
        {
            var answer = _answerRepository.GetFirst(x => x.Id==request.Id);

            if (answer==null)
            {
                answer=request.ToEntity();
                _answerRepository.Add(answer);
            }
            else
            {
                _answerRepository.Edit(answer, entry =>
                {
                    entry.SetValue(x => x.IsCorrect, request.IsCorrect);
                    entry.SetValue(x => x.QuestionId, request.QuestionId);
                    entry.SetValue(x => x.Text, request.Text);
                }); 
            }

            if (request.IsCorrect)
            {
                var otherAnswers = _answerRepository.GetAll(x => x.QuestionId==answer.QuestionId && x.Id != request.Id).ToList();

                foreach (var item in otherAnswers)
                {
                    _answerRepository.Edit(item, entry =>
                    {
                        entry.SetValue(m => m.IsCorrect, false);
                    });
                }
            }

            _answerRepository.SaveChanges();

            return QuestionSaveAnswerResponseDto.SaveAnswer(answer);
        }
    }
}
