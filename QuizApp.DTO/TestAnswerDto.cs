using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.DTO
{
	public class TestAnswerDto
	{
		public Guid Id { get; set; }
		public Guid TestQuestionId { get; set; }
		public string AnswerText { get; set; }
		public bool IsCorrect { get; set; }
	}
}
