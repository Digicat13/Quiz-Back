namespace QuizApp.DTO.Requests
{
    public class CreateTestAnswerRequest
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
