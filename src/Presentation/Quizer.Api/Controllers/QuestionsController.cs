using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;

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
            _questionService.Create(request);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromQuery]Guid id)
        {
            var response = _questionService.GetById(id);
            return Ok(response);
        }
    }
}
