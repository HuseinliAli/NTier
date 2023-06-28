using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.DTOs.Questions.SaveAnswer;

namespace Quizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public IActionResult Create(QuestionCreateDto request)
        {
            var response = _questionService.Create(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _questionService.GetById(id);
            return Ok(response);
        }

        [HttpPost("save")]
        public IActionResult Save(QuestionSaveDto request)
        {
            _questionService.Save(request);

            return NoContent();
        }


        [HttpPost("save-answer")]
        public IActionResult SaveAnswer(QuestionSaveAnswerDto request)
        {
            var response = _questionService.SaveAnswer(request);

            return Ok(response);
        }

        [HttpDelete("delete-answer/{id}")]
        public IActionResult DeleteAnswer(Guid id)
        {
            _questionService.RemoveAnswer(id);

            return NoContent();
        }

        [HttpDelete("remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _questionService.Remove(id);

            return NoContent();
        }
    }
}
