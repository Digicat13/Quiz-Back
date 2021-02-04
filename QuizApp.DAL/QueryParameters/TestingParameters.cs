namespace QuizApp.DAL.QueryParameters
{
	public class TestingParameters : QueryStringParameters
	{
		public TestingParameters() 
		{
			OrderBy = "test.name";
		}
	}
}
