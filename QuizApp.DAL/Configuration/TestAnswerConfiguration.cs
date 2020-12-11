using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Configuration
{
	public class TestAnswerConfiguration : IEntityTypeConfiguration<TestAnswer>
	{
		public void Configure(EntityTypeBuilder<TestAnswer> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.TestQuestionId)
				.IsRequired();
			builder.Property(e => e.AnswerText)
	 			.IsRequired();
			builder.Property(e => e.IsCorrect)
				.IsRequired();
			builder.HasOne(ta => ta.TestQuestion)
				.WithMany(tq => tq.TestAnswers)
				.HasForeignKey(ta => ta.TestQuestionId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
