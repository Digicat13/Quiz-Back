using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DTO.Requests
{
	public class CreateTestingResultRequest
	{
		public Guid TestingId { get; set; }
		public string IntervieweeName { get; set; }
		public DateTime? TestingStartDateTime { get; set; }
		public int QuestionTried { get; set; }
		public TimeSpan? Duration { get; set; }
		public List<CreateTestingResultAnswerRequest> SelectedAnswers { get; set; }
	}
}
