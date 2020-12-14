using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.DTO
{
	public class TestQuestionDto
	{
		public Guid Id { get; set; }
		public Guid TestId { get; set; }
		public string QuestionText { get; set; }
		public string HintText { get; set; }
		public List<TestAnswerDto> Answers { get; set; }
	}
}
