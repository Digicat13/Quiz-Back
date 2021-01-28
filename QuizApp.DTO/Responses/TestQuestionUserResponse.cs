using System;
using System.Collections.Generic;

namespace QuizApp.DTO.Responses
{
	public class TestQuestionUserResponse
	{
		public Guid Id { get; set; }
		public Guid TestId { get; set; }
		public string QuestionText { get; set; }
		public string HintText { get; set; }
		public int CorrectAnswersCount { get; set; }
		public List<TestAnswerUserResponse> Answers { get; set; }
	}
}
