using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Configuration
{
	public class TestingUrlConfiguration : IEntityTypeConfiguration<TestingUrl>
	{
		public void Configure(EntityTypeBuilder<TestingUrl> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.TestId)
				.IsRequired();
			builder.Property(e => e.IntervieweeName)
				.HasMaxLength(100);
			builder.HasOne(tu => tu.Test)
				.WithMany(t => t.TestingUrls)
				.HasForeignKey(t => t.TestId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
