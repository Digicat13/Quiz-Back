using System;
using System.Collections.Generic;

namespace QuizApp.DAL.Entities
{
	public class TestAnswer : BaseEntity<Guid>
	{
		public TestQuestion TestQuestion { get; set; }
		public Guid TestQuestionId { get; set; }
		public string AnswerText { get; set; }
		public bool IsCorrect { get; set; }
		public IEnumerable<TestingResultAnswer> TestingResultAnswers { get; set; }
			= new List<TestingResultAnswer>();
	}
}
