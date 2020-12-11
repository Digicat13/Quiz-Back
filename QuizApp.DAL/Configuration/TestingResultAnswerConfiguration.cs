using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Configuration
{
	class TestingResultAnswerConfiguration : IEntityTypeConfiguration<TestingResultAnswer>
	{
		public void Configure(EntityTypeBuilder<TestingResultAnswer> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.TestingResultId)
				.IsRequired();
			builder.Property(e => e.TestQuestionId)
				.IsRequired();
			builder.Property(e => e.TestAnswerId)
				.IsRequired();
			builder.HasOne(tra => tra.TestingResult)
				.WithMany(tr => tr.TestingResultAnswers)
				.HasForeignKey(tra => tra.TestingResultId)
				.OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(tra => tra.TestQuestion)
				.WithMany(tq => tq.TestingResultAnswers)
				.HasForeignKey(tra => tra.TestQuestionId)
				.OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(tra => tra.TestAnswer)
				.WithMany(ta => ta.TestingResultAnswers)
				.HasForeignKey(tra => tra.TestAnswerId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
