using System.ComponentModel.DataAnnotations.Schema;

namespace FptJobMatch.Models
{
	public class Award
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		[ForeignKey("UserId")]
		public ApplicationUser? User { get; set; }
		public string Title { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string Description { get; set; }
	}
}
