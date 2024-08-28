namespace FptJobMatch.Models.ViewModels
{
	public class ResumeVM
	{
		public List<Award>? ListAward { get; set; }
		public List<Education>? ListEducation { get; set; }
		public List<Portfolio>? ListPortfolio { get; set; }
		public List<WorkExperience>? ListWorkExp { get; set; }
		public ApplicationUser? User { get; set; }
	}
}
