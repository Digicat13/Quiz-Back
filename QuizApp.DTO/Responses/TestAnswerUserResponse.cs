using System;

namespace QuizApp.DTO.Responses
{
	public class TestAnswerUserResponse
	{
		public Guid Id { get; set; }
		public Guid TestQuestionId { get; set; }
		public string AnswerText { get; set; }
	}
}
