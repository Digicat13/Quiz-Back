using System;
using System.Collections.Generic;

namespace QuizApp.DTO.Requests
{
    public class UpdateTestRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? TestTimeLimit { get; set; }
        public TimeSpan? QuestionTimeLimit { get; set; }
        public List<UpdateTestQuestionRequest> Questions { get; set; }
    }
}
