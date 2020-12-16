using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<List<TestDto>>> GetAll()
        {
            try
            {
                var result = await _testService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
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
    }
}
