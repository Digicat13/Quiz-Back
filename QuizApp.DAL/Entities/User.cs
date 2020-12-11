using System;

namespace QuizApp.DAL.Entities
{
	public class User : BaseEntity<Guid>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
