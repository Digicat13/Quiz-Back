using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
	public class TestingController : ControllerBase
	{
		private readonly ITestingService _testingService;
		private readonly ILogger<TestingController> _logger;

		public TestingController(ITestingService testingService, ILogger<TestingController> logger)
		{
			_logger = logger;
			if (testingService == null)
			{
				_logger.LogError("Failed to inject TestingService into Answer controller");
			}
			else
			{
				_testingService = testingService;
			}
		}

		[HttpGet]
		public async Task<ActionResult<List<TestingDto>>> GetAll()
		{
			try
			{
				var result = await _testingService.GetAll();
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
				var result = await _testingService.GetTestingById(id);
				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost]
		public async Task<ActionResult<TestingDto>> Post(CreateTestingRequest testing)
		{
			try
			{
				var result = await _testingService.Add(testing);
				return Ok(result);
			}
			catch (Exception e)
			{
				return StatusCode(500, "Internal server error " + e.Message);
			}
		}
	}
}