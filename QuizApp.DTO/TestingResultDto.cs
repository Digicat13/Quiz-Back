using System;
using System.Collections.Generic;

namespace QuizApp.DTO
{
	public class TestingResultDto
	{
		public Guid Id { get; set; }
		public Guid TestingId { get; set; }
		public string IntervieweeName { get; set; }
		public DateTime? TestingStartDateTime { get; set; }
		public DateTime? TestingEndDateTime { get; set; }
		public int QuestionTried { get; set; }
		public int CorrectAnswers { get; set; }
		public TimeSpan? Duration { get; set; }
		public double Score { get; set; }
		public List<TestingResultAnswerDto> SelectedAnswers { get; set; }
	}
}
