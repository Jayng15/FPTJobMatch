﻿using FptJobMatch.Models;
using FptJobMatch.Models.ViewModels;
using FptJobMatch.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FptJobMatch.Areas.User.Controllers
{
    [Area("User")]
    public class JobController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		public JobController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
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
			ViewBag.Image = user.ImageUrl;
			return user;
		}
		public IActionResult Index()
        {
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account", new { area = "Identity" });
			}
			if (User.Identity.IsAuthenticated)
			{
				string UserId = TakeIdUser();
				TakeUser(UserId);
			}
			JobAppVM jobAppVM = new JobAppVM()
			{
				Application = new Application(),
				MyListJob = _unitOfWork.JobsRepository.GetAll().ToList(),
				MyListApplication = _unitOfWork.ApplicationsRepository.GetAll().ToList()
			};
			foreach(var job in jobAppVM.MyListJob)
			{
				job.User = _unitOfWork.UsersRepository.Get(u => u.Id == job.UserId);
			}
			return View(jobAppVM);

		}
		
        public IActionResult Jobdetail(int? id)
        {
			ApplicationUser user = TakeUser(TakeIdUser());
			if (id == null || id == 0)
			{
				return NotFound();
			}
			JobAppVM JobAppVM = new JobAppVM()
			{
				Job = _unitOfWork.JobsRepository.Get(j => j.Id == id),
				Application = new Application(),
				MyListApplication = _unitOfWork.ApplicationsRepository.GetAll().ToList()
			};
			JobAppVM.Job.User = _unitOfWork.UsersRepository.Get(u => u.Id == JobAppVM.Job.UserId);
			return View(JobAppVM);
        }
    }
}
