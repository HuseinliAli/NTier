using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizer.Core.Services;
using Quizer.Models.DTOs.QuestionSets.Create;

namespace Quizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSetsController : ControllerBase
    {
        private readonly IQuestionSetService _questionSetService;

        public QuestionSetsController(IQuestionSetService questionSetService)
        {
            _questionSetService=questionSetService;
        }
        [HttpPost]
        public IActionResult Create(QuestionSetCreateDto request)
        {
            var response = _questionSetService.Create(request);
            return Ok(response);
        }
    }
}
