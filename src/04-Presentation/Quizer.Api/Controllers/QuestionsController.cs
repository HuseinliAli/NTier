using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;

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
        public IActionResult GetById(int id)
        {
            var response = _questionService.GetById(id);
            return Ok(response);
        }
    }

}
