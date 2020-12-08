using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Configuration
{
	public class TestConfiguration : IEntityTypeConfiguration<Test>
	{
		public void Configure(EntityTypeBuilder<Test> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.Name)
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(e => e.Description)
				.IsRequired();
		}
	}
}
