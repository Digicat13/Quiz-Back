using System;

namespace QuizApp.DTO
{
	public class TestingResultAnswerDto
	{
		public Guid Id { get; set; }
		public Guid TestingResultId { get; set; }
		public Guid TestQuestionId { get; set; }
		public Guid TestAnswerId { get; set; }
		public TestAnswerDto TestAnswer { get; set; }
		public TestQuestionDto TestQuestion { get; set; }
	}
}
