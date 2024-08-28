using FptJobMatch.Models;
using FptJobMatch.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FptJobMatch.Areas.Employer.Controllers
{
	[Area("Employer")]
	[Authorize(Roles = "Employer")]
	public class CategoriesController : Controller
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IUnitOfWork _unitOfWork;
		public CategoriesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
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
		public IActionResult Index()
		{
			ApplicationUser user = TakeUser(TakeIdUser());
			List<Categories> myList = _unitOfWork.CategoriesRepository.GetAll().Where(c => c.Proposer == user.Name).ToList();
			return View(myList);
		}
		public IActionResult RequestNewCategory()
		{
			ApplicationUser user = TakeUser(TakeIdUser());
			return View();
		}
		[HttpPost]
		public IActionResult RequestNewCategory(Categories categories)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.CategoriesRepository.Add(categories);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult EditRequest(int? id)
		{
			ApplicationUser user = TakeUser(TakeIdUser());
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Categories? category = _unitOfWork.CategoriesRepository.Get(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult EditRequest(Categories category)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.CategoriesRepository.Update(category);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult DeleteRequest(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Categories category = _unitOfWork.CategoriesRepository.Get(c => c.Id == id);
			_unitOfWork.CategoriesRepository.Delete(category);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
}
