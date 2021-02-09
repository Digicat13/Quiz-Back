using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QuizApp.DAL;
using QuizApp.DAL.QueryParameters;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;
using QuizApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ILogger<TestController> _logger;

        public TestController(ITestService testService, ILogger<TestController> logger)
        {
            _logger = logger;
            if (testService == null)
            {
                _logger.LogError("Failed to inject TestService into Test controller");
            }
            else
            {
                _testService = testService;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TestDto>>> GetAll([FromQuery] TestParameters queryParameters)
        {
            try
            {
                var result = await _testService.GetAll(queryParameters);
				var metadata = result.GetMetadata();

				Response.Headers.Add("x-pagination", JsonConvert.SerializeObject(metadata));
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error" + e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestDto>> GetById(Guid id)
        {
            try
            {
                var result = await _testService.GetTestById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("quiz/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TestUserResponse>> GetUserTestById(Guid id)
        {
            try
            {
                var result = await _testService.GetUserTestById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TestDto>> Post(CreateTestRequest test)
        {
            try
            {
                var result = await _testService.Add(test);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _testService.Delete(id);
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateTestRequest testRequest)
        {
            try
            {
                var test = await _testService.GetTestById(id);
                if (test == null)
                {
                    return NotFound();
                }
                var result = await _testService.Update(testRequest);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error " + e.Message);
            }
        }
    }
}
