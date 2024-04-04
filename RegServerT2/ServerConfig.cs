using RegServerT2.Exceptions;

namespace RegServerT2
{
	public class ServerConfig
	{
		protected readonly string IniFile = "r2reg.cfg";
		public string HttpRegisterServiceAddress { get; init; }
		public string HttpRegisterServicePort { get; init; }
		public string HttpRegisterServiceRootUrl { get; init; }
		public string HttpRegisterServiceRoute { get; init; }
		public string DatabaseAddress { get; init; }
		public string DatabasePort { get; init; }
		public string DatabaseDBName { get; init; }
		public string DatabaseUser { get; init; }
		public string DatabasePassword { get; init; }
		public string DatabaseConnectionString { get; init; }

		public ServerConfig()
		{
			var builder = new ConfigurationBuilder().AddIniFile(IniFile).Build();

			var readValue = (string key) =>
			{
				var value = builder[key] ??
						throw new ConfigurationException($"Missing '{key}' key or value. Please check 'file.ini' file");
				return (string)value;
			};

			HttpRegisterServiceAddress = readValue("server_address");
			HttpRegisterServicePort = readValue("server_port");
			HttpRegisterServiceRootUrl = $"http://{HttpRegisterServiceAddress}:{HttpRegisterServicePort}/";
			HttpRegisterServiceRoute = "/stubs/handler_api.php/";

			DatabaseAddress = readValue("sql_server");
			DatabasePort = readValue("sql_port");
			DatabaseDBName = readValue("sql_db");
			DatabaseUser = readValue("sql_user");
			DatabasePassword = readValue("sql_password");
			DatabaseConnectionString = $"Host={DatabaseAddress};" +
						$"Database={DatabaseDBName};" +
						$"Username={DatabaseUser};" +
						$"Password={DatabasePassword}";
		}
	}
}
