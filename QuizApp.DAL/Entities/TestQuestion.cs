using System;
using System.Collections.Generic;

namespace QuizApp.DAL.Entities
{
	public class TestQuestion : BaseEntity<Guid>
	{
		public Test Test { get; set; }
		public Guid TestId { get; set; }
		public string QuestionText { get; set; }
		public string HintText { get; set; }
		public IEnumerable<TestAnswer> TestAnswers { get; set; }
		public IEnumerable<TestingResultAnswer> TestingResultAnswers { get; set; } 
			= new List<TestingResultAnswer>();
	}
}
