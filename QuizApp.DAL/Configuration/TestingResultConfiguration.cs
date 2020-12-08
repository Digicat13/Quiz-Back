using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Configuration
{
	class TestingResultConfiguration : IEntityTypeConfiguration<TestingResult>
	{
		public void Configure(EntityTypeBuilder<TestingResult> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.TestingUrlId)
				.IsRequired();
			builder.Property(e => e.IntervieweeName)
				.HasMaxLength(50)
				.IsRequired();
			builder.Property(e => e.TestingStartDateTime)
				.IsRequired();
			builder.Property(e => e.TestingEndDateTime)
				.IsRequired();
			builder.Property(e => e.QuestionTried)
				.IsRequired();
			builder.Property(e => e.CorrectAnswers)
				.IsRequired();
			builder.Property(e => e.Duration)
				.IsRequired();
			builder.Property(e => e.Score)
				.IsRequired();
			builder.HasOne(tr => tr.TestingUrl)
					.WithMany(tu => tu.TestingResults)
					.HasForeignKey(tr => tr.TestingUrlId)
					.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
