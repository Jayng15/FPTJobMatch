using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FptJobMatch.Models.ViewModels
{
	public class JobVM
	{
		public Job Job { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> Categories { get; set; }
	}
}
