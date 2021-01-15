using System;

namespace QuizApp.DTO
{
	public class TestingDto
	{
		public Guid Id { get; set; }
		public Guid TestId { get; set; }
		public string IntervieweeName { get; set; }
		public DateTime? AllowedStartDate { get; set; }
		public DateTime? AllowedEndDate { get; set; }
		public int? NumberOfRuns { get; set; }
	}
}
