using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Configuration
{
	class TestQuestionConfiguration : IEntityTypeConfiguration<TestQuestion>
	{
		public void Configure(EntityTypeBuilder<TestQuestion> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.TestId)
				.IsRequired();
			builder.Property(e => e.QuestionText)
				.IsRequired();
			builder.HasOne(t => t.Test)
				.WithMany(q => q.TestQuestions)
				.HasForeignKey(q => q.TestId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
