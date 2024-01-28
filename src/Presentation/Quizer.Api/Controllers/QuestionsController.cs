using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Extensions;
using Quizer.Core.Repositories;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.DTOs.Questions.Save;
using Quizer.Models.DTOs.Questions.SaveAnswer;
using Quizer.Models.Entities;

namespace Quizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController:ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService=questionService;

        }

        [HttpPost]
        public IActionResult Create([FromBody]QuestionCreateDto request)
        {
            var response = _questionService.Create(request);
            return Ok(response);
        }

        [HttpPost("save")]
        public IActionResult Save([FromBody] QuestionSaveDto request)
        {
            _questionService.Save(request);
            return NoContent();
        }

        [HttpPost("save-answer")]
        public IActionResult SaveAnswer([FromBody] QuestionSaveAnswerDto request)
        {
            var response= _questionService.SaveAnswer(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Remove([FromQuery] Guid id)
        {
             _questionService.Remove(id);
            return NoContent();
        }

        [HttpDelete("remove-answer/{id:guid}")]
        public IActionResult RemoveAnswer([FromQuery] Guid id)
        {
            _questionService.RemoveAnswer(id);
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromQuery]Guid id)
        {
            var response = _questionService.GetById(id);
            return Ok(response);
        }

        [HttpPatch("{id:guid}")]
        public IActionResult Edit(Guid id,string text)
        {
            return Ok();
            //var response = _repo.GetFirst(x=>x.Id==id);
            ////_repo.Edit(response); HttpPost Attribute
            //_repo.Edit(response, entry =>
            //{
            //    entry.SetValue(x=>x.Text,text);
            //});
            //return NoContent();
        }
    }
}
