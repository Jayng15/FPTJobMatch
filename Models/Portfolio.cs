using System.ComponentModel.DataAnnotations.Schema;

namespace FptJobMatch.Models
{
	public class Portfolio
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		[ForeignKey("UserId")]
		public ApplicationUser? User { get; set; }
		public string Title { get; set; }
		public string? ImageUrl { get; set; }
	}
}
