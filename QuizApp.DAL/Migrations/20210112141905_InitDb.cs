using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.DAL.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    NumberOfRuns = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "07b0f155-d4d4-411c-87de-fc61dd599197", "admin@gmail.com", true, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEJVK9YSVz3NSVbYutxVcccvwywG7mgjvTqLeG8MFSOM/TbZ/2EUjGsgzeSTSnV2iNQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "Description", "Name", "QuestionTimeLimit", "TestTimeLimit" },
                values: new object[] { new Guid("ceb4acf9-a249-4cc8-ac6f-04c91d0b90e9"), "Test your geek knowledge with this epic quiz", "Geek Culture/Movies/TV shows/Cartoons", new TimeSpan(0, 0, 0, 30, 0), null });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "Description", "Name", "QuestionTimeLimit", "TestTimeLimit" },
                values: new object[] { new Guid("c109ffba-9fd9-4657-a6d6-7228786a2531"), "This test is designed to cover main concepts such as basic syntax, data types, collections, operators, exception handling and OOP in C# .NET.", ".Net Quiz", null, new TimeSpan(0, 0, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "TestQuestion",
                columns: new[] { "Id", "HintText", "QuestionText", "TestId" },
                values: new object[,]
                {
                    { new Guid("640ec210-4607-4851-99b9-111e6f31ae73"), "Select one correct answer", "When var and dynamic are evaluated?", new Guid("c109ffba-9fd9-4657-a6d6-7228786a2531") },
                    { new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272"), "Select one correct answer", "What is Han Solo's ship name?", new Guid("ceb4acf9-a249-4cc8-ac6f-04c91d0b90e9") },
                    { new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77"), "Select one correct answer", "The Answer to the Ultimate Question of Life, the Universe, and Everything", new Guid("ceb4acf9-a249-4cc8-ac6f-04c91d0b90e9") }
                });

            migrationBuilder.InsertData(
                table: "TestingUrl",
                columns: new[] { "Id", "AllowedEndDate", "AllowedStartDate", "IntervieweeName", "NumberOfRuns", "TestId" },
                values: new object[] { new Guid("11266ec6-6e51-4ba6-adcd-cce73d3b5b1c"), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Dou", 5, new Guid("c109ffba-9fd9-4657-a6d6-7228786a2531") });

            migrationBuilder.InsertData(
                table: "TestAnswer",
                columns: new[] { "Id", "AnswerText", "IsCorrect", "TestQuestionId" },
                values: new object[,]
                {
                    { new Guid("133443f7-2f50-4eab-8551-65468157e9e1"), "Both of them are evaluated at runtime.", false, new Guid("640ec210-4607-4851-99b9-111e6f31ae73") },
                    { new Guid("d576779d-0034-45b9-86e4-d2c2db64dd26"), "\"var\" is evaluated at compilation \"dynamic\" is evaluated in runtime", true, new Guid("640ec210-4607-4851-99b9-111e6f31ae73") },
                    { new Guid("56e11d3c-f1bb-4a02-808c-8f08780a5ca2"), "\"var\" is evaluated at runtime. \"dynamic\" is evaluated at compile time", false, new Guid("640ec210-4607-4851-99b9-111e6f31ae73") },
                    { new Guid("8e7f787c-fa0d-4b40-9928-87fe69d44dce"), "Weekly Falcon", false, new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272") },
                    { new Guid("4b5f9a77-90b2-4180-885f-94c35155870e"), "Century Falcon", false, new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272") },
                    { new Guid("2008610d-70eb-45cc-88ff-303ccbfc4068"), "Millennium Falcon", true, new Guid("09a0b09f-4cf0-4be1-afee-cd3a7d263272") },
                    { new Guid("923c8ad7-5b0c-43be-b87d-f46d0832cd85"), "There is no answer", false, new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77") },
                    { new Guid("fa3c6ecb-9fb6-467b-8bfa-d3b54c64eca3"), "42", true, new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77") },
                    { new Guid("520f5a49-283f-4821-b887-bf26555872b7"), "Love", false, new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77") },
                    { new Guid("36130e54-3b25-4662-936e-0bb2893343d7"), "Life", false, new Guid("c6d7f91e-6c20-404f-b969-7c7de0d71c77") }
                });

            migrationBuilder.InsertData(
                table: "TestingResult",
                columns: new[] { "Id", "CorrectAnswers", "Duration", "IntervieweeName", "QuestionTried", "Score", "TestingEndDateTime", "TestingStartDateTime", "TestingUrlId" },
                values: new object[] { new Guid("e602029d-1350-4f2e-9bbf-850e39603e1a"), 1, new TimeSpan(0, 0, 25, 0, 0), "Michael Scott", 1, 100.0, new DateTime(2020, 12, 5, 7, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 7, 30, 0, 0, DateTimeKind.Unspecified), new Guid("11266ec6-6e51-4ba6-adcd-cce73d3b5b1c") });

            migrationBuilder.InsertData(
                table: "TestingResultAnswer",
                columns: new[] { "Id", "TestAnswerId", "TestQuestionId", "TestingResultId" },
                values: new object[] { new Guid("a33b38c6-bd0f-4780-bbce-1b367b99e105"), new Guid("d576779d-0034-45b9-86e4-d2c2db64dd26"), new Guid("640ec210-4607-4851-99b9-111e6f31ae73"), new Guid("e602029d-1350-4f2e-9bbf-850e39603e1a") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TestingResultAnswer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
