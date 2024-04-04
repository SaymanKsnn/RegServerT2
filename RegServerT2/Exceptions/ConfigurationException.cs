namespace RegServerT2.Exceptions
{
	public class ConfigurationException : Exception
	{
		public ConfigurationException(string message) : base(message)
		{
		}
		public class PostgreSQLConfigurationException : Exception
		{
			public PostgreSQLConfigurationException(string message) : base(message)
			{
			}
		}
	}
}
