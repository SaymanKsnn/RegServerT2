using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using RegServerT2.Data;

namespace RegServerT2.Services
{
	public class HttpService
	{
		private DatabaseService dataConnection {  get; init; }
		private IEnumerable<User> user { get; init; }
		public HttpService(DatabaseService dataConnection)
		{
			this.dataConnection = dataConnection;
			user = dataConnection.GetUser();
		}

		public async Task GetAction(HttpContext context)
		{
			if (!context.Request.Query.ContainsKey("api_key"))
			{
				//context.Response.StatusCode = 400; // Bad Request
				await context.Response.WriteAsync("BAD_KEY");
				return;
			}

			var _user = user.FirstOrDefault(u => u.ApiKey == context.Request.Query["api_key"]);

			if (_user != null)
			{
				Console.WriteLine($"{_user.Id.ToString()}: {_user.Name}");
				await context.Response.WriteAsync($"{_user.Id.ToString()}: {_user.Name}");
			}
			else
			{
				Console.WriteLine("BAD_KEY");
				await context.Response.WriteAsync("BAD_KEY");
			}
		}
	}
}
