using System;
using System.Collections.Generic;

namespace QuizApp.DTO.Requests
{
    public class UpdateTestQuestionRequest
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public string QuestionText { get; set; }
        public string HintText { get; set; }
        public List<UpdateTestAnswerRequest> Answers { get; set; }
    }
}
