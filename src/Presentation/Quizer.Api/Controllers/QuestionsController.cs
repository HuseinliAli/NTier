using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Extensions;
using Quizer.Core.Repositories;
using Quizer.Core.Services;
using Quizer.Models.DTOs.Questions.Create;
using Quizer.Models.Entities;

namespace Quizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController:ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly Repository<Question> _repo;
        public QuestionsController(IQuestionService questionService,Repository<Question> repo)
        {
            _questionService=questionService;
            _repo=repo;
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

        [HttpPatch("{id:guid}")]
        public IActionResult Edit(Guid id,string text)
        {
            var response = _repo.GetFirst(x=>x.Id==id);
            //_repo.Edit(response); HttpPost Attribute
            _repo.Edit(response, entry =>
            {
                entry.SetValue(x=>x.Text,text);
            });
            return NoContent();
        }
    }
}
