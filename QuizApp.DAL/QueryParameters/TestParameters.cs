using QuizApp.DAL.Entities;
using System.Linq;

namespace QuizApp.DAL.QueryParameters
{
	public class TestParameters : QueryStringParameters
	{
		public TestParameters()
		{
			OrderBy = "name";
		}
	}
}
