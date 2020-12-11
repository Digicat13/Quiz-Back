using System;
using System.Collections.Generic;

namespace QuizApp.DAL.Entities
{
	public class TestingResult : BaseEntity<Guid>
	{
		public TestingUrl TestingUrl { get; set; }
		public Guid TestingUrlId { get; set; }
		public string IntervieweeName { get; set; }
		public DateTime TestingStartDateTime { get; set; }
		public DateTime TestingEndDateTime { get; set; }
		public int QuestionTried { get; set; }
		public int CorrectAnswers { get; set; }
		public TimeSpan Duration { get; set; }
		public double Score { get; set; }
		public IEnumerable<TestingResultAnswer> TestingResultAnswers { get; set; }
			= new List<TestingResultAnswer>();
	}
}
