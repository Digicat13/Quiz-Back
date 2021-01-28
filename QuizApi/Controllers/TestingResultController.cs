using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.Services.Contracts;

namespace QuizApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestingResultController : ControllerBase
	{
		private readonly ITestingResultService _testingResultService;
		private readonly ILogger<TestingResultController> _logger;

		public TestingResultController(ITestingResultService testingResultService, ILogger<TestingResultController> logger)
		{
			_logger = logger;
			if (testingResultService == null)
			{
				_logger.LogError("Failed to inject TestingService into Answer controller");
			}
			else
			{
				_testingResultService = testingResultService;
			}
		}

		[HttpGet]
		public async Task<ActionResult<List<TestingResultDto>>> GetAll()
		{
			try
			{
				var result = await _testingResultService.GetAll();
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, "Internal server error" + e.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetById(Guid id)
		{
			try
			{
				var result = await _testingResultService.GetTestingResultById(id);
				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		public async Task<ActionResult<TestingResultDto>> Post(CreateTestingResultRequest testingResult)
		{
			try
			{
				var result = await _testingResultService.Add(testingResult);
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, "Internal server error " + e.Message);
			}
		}
	}
}
