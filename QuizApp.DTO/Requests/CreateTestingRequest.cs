using System;

namespace QuizApp.DTO.Requests
{
	public class CreateTestingRequest
	{
		public Guid TestId { get; set; }
		public string IntervieweeName { get; set; }
		public DateTime? AllowedStartDate { get; set; }
		public DateTime? AllowedEndDate { get; set; }
		public int? NumberOfRuns { get; set; }
	}
}
