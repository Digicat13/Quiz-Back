using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.DAL.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestTimeLimit = table.Column<TimeSpan>(type: "time", nullable: true),
                    QuestionTimeLimit = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestingUrl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntervieweeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AllowedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfRuns = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestingUrl_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HintText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestion_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestingResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestingUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntervieweeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestingStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestingEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionTried = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestingResult_TestingUrl_TestingUrlId",
                        column: x => x.TestingUrlId,
                        principalTable: "TestingUrl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAnswer_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "TestQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestingResultAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestingResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingResultAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestingResultAnswer_TestAnswer_TestAnswerId",
                        column: x => x.TestAnswerId,
                        principalTable: "TestAnswer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestingResultAnswer_TestingResult_TestingResultId",
                        column: x => x.TestingResultId,
                        principalTable: "TestingResult",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestingResultAnswer_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "TestQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswer_TestQuestionId",
                table: "TestAnswer",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResult_TestingUrlId",
                table: "TestingResult",
                column: "TestingUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResultAnswer_TestAnswerId",
                table: "TestingResultAnswer",
                column: "TestAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResultAnswer_TestingResultId",
                table: "TestingResultAnswer",
                column: "TestingResultId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingResultAnswer_TestQuestionId",
                table: "TestingResultAnswer",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestingUrl_TestId",
                table: "TestingUrl",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_TestId",
                table: "TestQuestion",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestingResultAnswer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TestAnswer");

            migrationBuilder.DropTable(
                name: "TestingResult");

            migrationBuilder.DropTable(
                name: "TestQuestion");

            migrationBuilder.DropTable(
                name: "TestingUrl");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
