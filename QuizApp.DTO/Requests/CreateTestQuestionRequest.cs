using System.Collections.Generic;

namespace QuizApp.DTO.Requests
{
    public class CreateTestQuestionRequest
    {
        public string QuestionText { get; set; }
        public string HintText { get; set; }
        public List<CreateTestAnswerRequest> Answers { get; set; }
    }
}
