using Microsoft.AspNetCore.Builder;

namespace RegServerT2.Services
{
	public class HttpRoutes
	{
		private HttpService httpService { get; init; }
		private WebApplication app { get; init; }
		public HttpRoutes(HttpService httpService)
		{
			this.httpService = httpService;
			//this.app = app;

			//app.MapGet("/stubs/handler_api.php/", httpService.GetAction);
		}

		public void AddRoutes(WebApplication app)
		{
			app.MapGet("/stubs/handler_api.php/", httpService.GetAction);
		}


	}
}
