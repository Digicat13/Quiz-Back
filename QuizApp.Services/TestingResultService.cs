using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;

namespace QuizApp.Services.Contracts
{
	public class TestingResultService : ITestingResultService
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<TestingResultService> _logger;
		private readonly IAnswerService _answerService;
		private readonly IQuestionService _questionService;

		public TestingResultService(IRepositoryWrapper repository, IMapper mapper, ILogger<TestingResultService> logger, IAnswerService answerService, IQuestionService questionService)
		{
			_logger = logger;
			if (repository == null)
			{
				_logger.LogError("Failed to inject RepositoryWrapper into TestingResult service");
			}
			else
			{
				_repository = repository;
			}
			_mapper = mapper;
			_answerService = answerService;
			_questionService = questionService;
		}

		public async Task<List<TestingResultDto>> GetAll()
		{
			var testingResults = await _repository.TestingResult.GetAllTestingResults();
			var result = _mapper.Map<List<TestingResultDto>>(testingResults);
			return result;
		}

		public async Task<TestingResultUserResponse> GetTestingResultById(Guid id)
		{
			var testingResult = await _repository.TestingResult.GetTestingResultById(id);
			var result = _mapper.Map<TestingResultUserResponse>(testingResult);
			return result;
		}

		public async Task<TestingResultUserResponse> Add(CreateTestingResultRequest resultRequest)
		{
			var testingResult = _mapper.Map<TestingResult>(resultRequest);
			testingResult.QuestionTried = CalculateQuestionsTried(testingResult);
			testingResult.Score = await CalculateTestingScore(testingResult);
			testingResult.TestingEndDateTime = DateTime.Now;
			testingResult.CorrectAnswers = await GetCorrectAnswersCount(testingResult);

			var testing = await _repository.TestingUrl.GetByIdAsync(testingResult.TestingUrlId);
			if (testing.NumberOfRuns != 0)
			{
				testingResult.TestingUrl = testing;
				var rowsCount = await _repository.TestingResult.Add(testingResult);
				if (rowsCount == 0)
				{
					throw new ArgumentException();
				}
				return _mapper.Map<TestingResultUserResponse>(testingResult);
			}
			else
			{
				throw new InvalidOperationException("Number of left testing attempts is 0");
			}
		}

		public async Task<double> CalculateTestingScore(TestingResult testingResult)
		{
			var resultAnswers = testingResult.TestingResultAnswers;
			var answers = new List<TestAnswerDto>();
			foreach (var resultAnswer in resultAnswers)
			{
				var answerDto = await _answerService.GetAnswerById(resultAnswer.TestAnswerId);
				answers.Add(answerDto);
			}

			double totalScore = 0;

			var groupedAnswers = (Lookup<Guid, bool>)answers.ToLookup(a => a.TestQuestionId, a => a.IsCorrect);
			var questionsCount = groupedAnswers.Count;
			foreach (var questionAnswers in groupedAnswers)
			{
				double questionScore = 0;
				var question = await _questionService.GetQuestionById(questionAnswers.Key);
				var correctAnswersCount = question.Answers.FindAll(a => a.IsCorrect == true).Count;
				double correctAnswerKoef = (1.0 / questionsCount) / correctAnswersCount;
				foreach (var isCorrectAnswer in questionAnswers)
				{
					if (isCorrectAnswer == true)
					{
						questionScore += correctAnswerKoef;
					}
					else if (questionScore - correctAnswerKoef > 0)
					{
						questionScore -= correctAnswerKoef;
					}
					else
					{
						questionScore = 0;
					}
				}
				totalScore += questionScore;
			}
			return totalScore;
		}

		public async Task<int> GetCorrectAnswersCount(TestingResult testingResult)
		{
			var resultAnswers = testingResult.TestingResultAnswers;
			var answers = new List<TestAnswerDto>();
			foreach (var resultAnswer in resultAnswers)
			{
				var answerDto = await _answerService.GetAnswerById(resultAnswer.TestAnswerId);
				answers.Add(answerDto);
			}

			int correctAnsweredQuestions = 0;
			var groupedAnswers = (Lookup<Guid, bool>)answers.ToLookup(a => a.TestQuestionId, a => a.IsCorrect);
			foreach (var questionAnswers in groupedAnswers)
			{
				int answersCount = 0;
				int correctAnswersCount = 0;
				foreach (var isCorrectAnswer in questionAnswers)
				{
					answersCount++;
					if (isCorrectAnswer == true)
					{
						correctAnswersCount++;
					}
				}
				if (correctAnswersCount / answersCount == 1)
				{
					correctAnsweredQuestions++;
				}
			}
			return correctAnsweredQuestions;
		}

		public int CalculateQuestionsTried(TestingResult testingResult)
		{
			var answers = testingResult.TestingResultAnswers;
			var questions = new HashSet<Guid>();
			foreach (var answer in answers)
			{
				questions.Add(answer.TestQuestionId);
			}
			return questions.Count;
		}
	}
}
