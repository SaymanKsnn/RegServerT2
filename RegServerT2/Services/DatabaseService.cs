using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using RegServerT2.Data;
using static RegServerT2.Exceptions.ConfigurationException;

namespace RegServerT2.Services
{
	public class DatabaseService
	{
		private string ConnectionString { get; init; }

		public DatabaseService(ServerConfig cfg)
		{
			this.ConnectionString = cfg.DatabaseConnectionString;
			Console.WriteLine("Database is in services ...");
		}

		private DataConnection GetConnection()
		{
			return new DataConnection(new DataOptions()
				    .UsePostgreSQL(ConnectionString)) ?? throw new PostgreSQLConfigurationException($"Unknown error while connection to DataBase!");
		}

		public IEnumerable<User> GetUser()
		{
			using (var db = GetConnection())
			{
				return db.GetTable<User>().ToList();
			}
		}
	}
}
