﻿using System;
using System.Collections.Generic;

namespace QuizApp.DAL.Entities
{
	public class Test : BaseEntity<Guid>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public TimeSpan? TestTimeLimit { get; set; }
		public TimeSpan? QuestionTimeLimit { get; set; }
		public DateTime? CreationDate { get; set; }
		public IEnumerable<TestQuestion> TestQuestions { get; set; } = new List<TestQuestion>();
		public IEnumerable<TestingUrl> TestingUrls { set; get; } = new List<TestingUrl>();
	}
}
