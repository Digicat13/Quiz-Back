using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Configuration;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL
{
	public class QuizAppContext : DbContext
	{
		public DbSet<Test> Test { get; set; }
		public DbSet<TestAnswer> TestAnswer { get; set; }
		public DbSet<TestQuestion> TestQuestion { get; set; }
		public DbSet<TestingUrl> TestingUrl { get; set; }
		public DbSet<TestingResult> TestingResult { get; set; }
		public DbSet<TestingResultAnswer> TestingResultAnswer { get; set; }
		public DbSet<User> User { get; set; }

		public QuizAppContext(DbContextOptions<QuizAppContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new TestConfiguration());
			modelBuilder.ApplyConfiguration(new TestAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new TestingResultConfiguration());
			modelBuilder.ApplyConfiguration(new TestingResultAnswerConfiguration());
			modelBuilder.ApplyConfiguration(new TestingUrlConfiguration());
			modelBuilder.ApplyConfiguration(new TestQuestionConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
		}
	}
}
