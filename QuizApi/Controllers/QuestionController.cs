using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IQuestionService questionService, ILogger<QuestionController> logger)
        {
            _logger = logger;
            if (questionService == null)
            {
                _logger.LogError("Failed to inject QuestionService into Question controller");
            }
            else
            {
                _questionService = questionService;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _questionService.GetQuestionById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _questionService.Delete(id);
                if (result == true)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error " + e.Message);
            }
        }
    }
}
