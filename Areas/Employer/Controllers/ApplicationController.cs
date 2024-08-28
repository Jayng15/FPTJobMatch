using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace FptJobMatch.Areas.Employer.Controllers
{
	[Area("Employer")]
	[Authorize(Roles = "Employer")]
	public class ApplicationController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IUnitOfWork _unitOfWork;
		public ApplicationController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		public string TakeIdUser()
		{
			var claimIdentity = (ClaimsIdentity)User.Identity;
			string userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			return userId;
		}
		public ApplicationUser TakeUser(string userId)
		{
			ApplicationUser? user = _unitOfWork.UsersRepository.Get(u => u.Id == userId);

			ViewBag.UserId = userId;
			ViewBag.Email = user.Email;
			ViewBag.Name = user.Name;
			return user;
		}
		public IActionResult ViewApplication(int? id)
		{
			ViewBag.JobId = id;
			List<Application> listApplication = _unitOfWork.ApplicationsRepository.GetAll().Where(a => a.JobId == id).ToList();
			List<ApplicationUser> listUser = new List<ApplicationUser>();
			foreach(var apply in listApplication)
			{
				if (apply.Status == "Processing")
				{
					listUser.Add(_unitOfWork.UsersRepository.Get(u => u.Id == apply.UserId));
				}
			}
			return View(listUser);
		}
		public IActionResult Rejected(int? id, string? data)
		{
			Application apply = _unitOfWork.ApplicationsRepository.Get(a => a.JobId == id && a.UserId == data);
			apply.Status = "Rejected";
			_unitOfWork.ApplicationsRepository.Update(apply);
			_unitOfWork.Save();

            return RedirectToAction("ViewApplication");
        }
        public IActionResult Approved(int? id, string? data)
        {
            Application apply = _unitOfWork.ApplicationsRepository.Get(a => a.JobId == id && a.UserId == data);
            apply.Status = "Approved";
            _unitOfWork.ApplicationsRepository.Update(apply);
            _unitOfWork.Save();

            return RedirectToAction("ViewApplication",id);
        }
    }
}
