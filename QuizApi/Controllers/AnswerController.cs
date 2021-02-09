using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly ILogger<AnswerController> _logger;

        public AnswerController(IAnswerService answerService, ILogger<AnswerController> logger)
        {
            _logger = logger;
            if (answerService == null)
            {
                _logger.LogError("Failed to inject AnswerService into Answer controller");
            }
            else
            {
                _answerService = answerService;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _answerService.GetAnswerById(id);
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
                var result = await _answerService.Delete(id);
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
