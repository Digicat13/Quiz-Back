using System;

namespace QuizApp.DTO.Requests
{
    public class UpdateTestAnswerRequest
    {
        public Guid Id { get; set; }
        public Guid TestQuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
