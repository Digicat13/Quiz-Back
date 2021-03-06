﻿using System;

namespace QuizApp.DAL.Entities
{
	public class TestingResultAnswer : BaseEntity<Guid>
	{
		public TestingResult TestingResult { get; set; }
		public Guid TestingResultId { get; set; }
		public TestQuestion TestQuestion { get; set; }
		public Guid TestQuestionId { get; set; }
		public TestAnswer TestAnswer { get; set; }
		public Guid TestAnswerId { get; set; }
	}
}
