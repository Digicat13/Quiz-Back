using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.DTO
{
	public class TestDto
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public TimeSpan? TestTimeLimit { get; set; }
		public TimeSpan? QuestionTimeLimit { get; set; }
		public List<TestQuestionDto> Questions { get; set; }
	}
}
