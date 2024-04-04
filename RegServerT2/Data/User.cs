using LinqToDB;
using LinqToDB.Mapping;

namespace RegServerT2.Data
{
	[Table(Name = "user")]
	public class User
	{
		[PrimaryKey, Identity]
		[Column(Name = "id", DataType = DataType.Int32)]
		public int Id { get; set; }

		[Column(Name = "name", DataType = DataType.VarChar)]
		public string Name { get; set; }

		[Column(Name = "login", DataType = DataType.VarChar)]
		public string Login { get; set; }

		[Column(Name = "password", DataType = DataType.VarChar)]
		public string Password { get; set; }

		[Column(Name = "apikey", DataType = DataType.VarChar)]
		public string ApiKey { get; set; }

		[Column(Name = "type", DataType = DataType.VarChar)]
		public string Type { get; set; } = "user";

		[Column(Name = "active", DataType = DataType.Boolean)]
		public bool Active { get; set; } = false;

		[Column(Name = "threshold", DataType = DataType.Int16)]
		public short Threshold { get; set; } = 30;

		[Column(Name = "webhook", DataType = DataType.Boolean)]
		public bool Webhook { get; set; } = false;

		[Column(Name = "balance", DataType = DataType.Money)]
		public decimal Balance { get; set; } = 0;

		[Column(Name = "image", DataType = DataType.VarChar)]
		public string Image { get; set; } = "";

		[Column(Name = "email", DataType = DataType.VarChar)]
		public string Email { get; set; } = "";

		[Column(Name = "phone", DataType = DataType.VarChar)]
		public string Phone { get; set; } = "";

		[Column(Name = "createdt", DataType = DataType.Timestamp)]
		public DateTime CreatedDate { get; set; } = DateTime.Now;

		[Column(Name = "online", DataType = DataType.Timestamp)]
		public DateTime? Online { get; set; }
	}
}
