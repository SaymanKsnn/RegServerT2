using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RegServerT2.Services;
using System;
using System.Collections.Generic;



namespace RegServerT2
{
	public class Program
	{
		static void Main(string[] args)
		{
			//var cfg = new ServerConfig();
			var app = ConfigureHttpService();

			var cfg = app.Services.GetService<ServerConfig>();
			var api = app.Services.GetService<HttpService>();
			AddRoute(app, cfg.HttpRegisterServiceRoute, api.GetAction);


			app.Urls.Add(cfg.HttpRegisterServiceRootUrl);

			//var api = app.Services.GetService<HttpRoutes>();
			//var api = app.Services.GetService<HttpService>();
			//AddRoute(app, cfg.)
			//api.AddRoutes(app);
			//app.Services.GetRequiredService<HttpService>();
			app.Run();


			//app.MapGet("/", () => "Hello World!");
		}

		static WebApplication ConfigureHttpService()
		{
			var builder = WebApplication.CreateBuilder();
			builder.Services.AddSingleton<ServerConfig>();
			builder.Services.AddSingleton<DatabaseService>();
			builder.Services.AddSingleton<HttpService>();
			//builder.Services.AddSingleton<HttpRoutes>();

			builder.Logging.ClearProviders();
			//builder.Urls
			return builder.Build();
		}

		static public void AddRoute(WebApplication app, string route, Func<HttpContext, Task> action) => app.MapGet(route, action);
	}
}