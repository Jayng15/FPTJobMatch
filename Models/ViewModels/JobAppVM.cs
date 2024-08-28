namespace FptJobMatch.Models.ViewModels
{
	public class JobAppVM
	{
		public List<Job>? MyListJob { get; set; }
		public List<Application>? MyListApplication { get; set; } 
		public Application? Application { get; set; }
		public Job? Job { get; set; }
	}
}
