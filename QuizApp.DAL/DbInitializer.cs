using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using System;

namespace QuizApp.DAL
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });
      
            modelBuilder.Entity<Test>().HasData(
                new Test
                {
                    Id = new Guid("c109ffba-9fd9-4657-a6d6-7228786a2531"),
                    Name = ".Net Quiz",
                    Description = "This test is designed to cover main concepts such as " +
                    "basic syntax, data types, collections, operators, " +
                    "exception handling and OOP in C# .NET.",
                    TestTimeLimit = new TimeSpan(0, 30, 0)
                },
                new Test
                {
                    Id = new Guid("ceb4acf9-a249-4cc8-ac6f-04c91d0b90e9"),
                    Name = "Geek Culture/Movies/TV shows/Cartoons",
                    Description = "Test your geek knowledge with this epic quiz",
                    QuestionTimeLimit = new TimeSpan(0, 0, 30)
                }
                );
            modelBuilder.Entity<TestQuestion>().HasData(
                new TestQuestion
                {
                    Id = new Guid("640ec210-4607-4851-99b9-111e6f31ae73"),
                    TestId = new Guid("c109ffba-9fd9-4657-a6d6-7228786a2531"),
                    QuestionText = "When var and dynamic are evaluated?",
                    HintText = "Select one correct answer"
                },
                new TestQuestion
                {
                    Id = new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272"),
                    TestId = new Guid("ceb4acf9-a249-4cc8-ac6f-04c91d0b90e9"),
                    QuestionText = "What is Han Solo's ship name?",
                    HintText = "Select one correct answer"
                },
                new TestQuestion
                {
                    Id = new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77"),
                    TestId = new Guid("ceb4acf9-a249-4cc8-ac6f-04c91d0b90e9"),
                    QuestionText = "The Answer to the Ultimate Question of Life, the Universe, and Everything",
                    HintText = "Select one correct answer"
                }
                );
            modelBuilder.Entity<TestAnswer>().HasData(
                new TestAnswer
                {
                    Id = new Guid("133443f7-2f50-4eab-8551-65468157e9e1"),
                    TestQuestionId = new Guid("640ec210-4607-4851-99b9-111e6f31ae73"),
                    AnswerText = "Both of them are evaluated at runtime.",
                    IsCorrect = false
                },
                new TestAnswer
                {
                    Id = new Guid("d576779d-0034-45b9-86e4-d2c2db64dd26"),
                    TestQuestionId = new Guid("640ec210-4607-4851-99b9-111e6f31ae73"),
                    AnswerText = "\"var\" is evaluated at compilation \"dynamic\" is evaluated in runtime",
                    IsCorrect = true
                },
                new TestAnswer
                {
                    Id = new Guid("56e11d3c-f1bb-4a02-808c-8f08780a5ca2"),
                    TestQuestionId = new Guid("640ec210-4607-4851-99b9-111e6f31ae73"),
                    AnswerText = "\"var\" is evaluated at runtime. \"dynamic\" is evaluated at compile time",
                    IsCorrect = false
                },
                new TestAnswer
                {
                    Id = new Guid("8e7f787c-fa0d-4b40-9928-87fe69d44dce"),
                    TestQuestionId = new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272"),
                    AnswerText = "Weekly Falcon",
                    IsCorrect = false
                },
                new TestAnswer
                {
                    Id = new Guid("4b5f9a77-90b2-4180-885f-94c35155870e"),
                    TestQuestionId = new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272"),
                    AnswerText = "Century Falcon",
                    IsCorrect = false
                },
                new TestAnswer
                {
                    Id = new Guid("2008610d-70eb-45cc-88ff-303ccbfc4068"),
                    TestQuestionId = new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272"),
                    AnswerText = "Millennium Falcon",
                    IsCorrect = true
                },
                new TestAnswer
                {
                    Id = new Guid("923c8ad7-5b0c-43be-b87d-f46d0832cd85"),
                    TestQuestionId = new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77"),
                    AnswerText = "There is no answer",
                    IsCorrect = false
                },
                new TestAnswer
                {
                    Id = new Guid("fa3c6ecb-9fb6-467b-8bfa-d3b54c64eca3"),
                    TestQuestionId = new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77"),
                    AnswerText = "42",
                    IsCorrect = true
                },
                new TestAnswer
                {
                    Id = new Guid("520f5a49-283f-4821-b887-bf26555872b7"),
                    TestQuestionId = new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77"),
                    AnswerText = "Love",
                    IsCorrect = false
                },
                new TestAnswer
                {
                    Id = new Guid("36130e54-3b25-4662-936e-0bb2893343d7"),
                    TestQuestionId = new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77"),
                    AnswerText = "Life",
                    IsCorrect = false
                }
                );
            modelBuilder.Entity<TestingUrl>().HasData(
                new TestingUrl
                {
                    Id = new Guid("11266ec6-6e51-4ba6-adcd-cce73d3b5b1c"),
                    TestId = new Guid("c109ffba-9fd9-4657-a6d6-7228786a2531"),
                    IntervieweeName = "John Dou",
                    AllowedStartDate = new DateTime(2021, 1, 1),
                    AllowedEndDate = new DateTime(2021, 2, 1),
                    NumberOfRuns = 5
                }
                );
            modelBuilder.Entity<TestingResult>().HasData(
                new TestingResult
                {
                    Id = new Guid("e602029d-1350-4f2e-9bbf-850e39603e1a"),
                    TestingUrlId = new Guid("11266ec6-6e51-4ba6-adcd-cce73d3b5b1c"),
                    IntervieweeName = "Michael Scott",
                    TestingStartDateTime = new DateTime(2020, 12, 5, 7, 30, 0),
                    TestingEndDateTime = new DateTime(2020, 12, 5, 7, 55, 0),
                    QuestionTried = 1,
                    CorrectAnswers = 1,
                    Duration = new DateTime(2020, 12, 5, 7, 55, 0) - new DateTime(2020, 12, 5, 7, 30, 0),
                    Score = 100
                }
                );
            modelBuilder.Entity<TestingResultAnswer>().HasData(
                new TestingResultAnswer
                {
                    Id = new Guid("a33b38c6-bd0f-4780-bbce-1b367b99e105"),
                    TestingResultId = new Guid("e602029d-1350-4f2e-9bbf-850e39603e1a"),
                    TestQuestionId = new Guid("640ec210-4607-4851-99b9-111e6f31ae73"),
                    TestAnswerId = new Guid("d576779d-0034-45b9-86e4-d2c2db64dd26")
                }
                );
        }
    }
}
