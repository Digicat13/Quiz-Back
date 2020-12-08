using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.DAL.Entities
{
	public class TestingUrl : BaseEntity<Guid>
	{
		public Test Test { get; set; }
		public Guid TestId { get; set; }
		public string IntervieweeName { get; set; }
		public DateTime? AllowedStartDate { get; set; }
		public DateTime? AllowedEndDate { get; set; }
		public int NumberOfRuns { get; set; }
		public IEnumerable<TestingResult> TestingResults { get; set; } 
			= new List<TestingResult>();
	}
}
