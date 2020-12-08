using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.DAL.Entities
{
	public class User : BaseEntity<Guid>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
