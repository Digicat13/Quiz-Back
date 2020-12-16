using System;
using System.Collections.Generic;

namespace QuizApp.DTO.Requests
{
	public class CreateTestRequest
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public TimeSpan? TestTimeLimit { get; set; }
		public TimeSpan? QuestionTimeLimit { get; set; }
		public List<CreateTestQuestionRequest> Questions { get; set; }
	}
}
