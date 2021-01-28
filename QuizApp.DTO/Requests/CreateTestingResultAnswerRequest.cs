using System;

namespace QuizApp.DTO.Requests
{
	public class CreateTestingResultAnswerRequest
	{
		public Guid TestQuestionId { get; set; }
		public Guid TestAnswerId { get; set; }
	}
}
