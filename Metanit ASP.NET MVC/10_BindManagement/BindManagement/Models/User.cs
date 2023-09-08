using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BindManagement.Models
{
	public class User
	{
		public int Id { get; set; }
		[BindRequired]
		public string Name { get; set; } = "";
		public int Age { get; set; }
		[BindNever]
		public bool HasRight { get; set; }		
	}
}
