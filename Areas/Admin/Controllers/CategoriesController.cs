﻿using FptJobMatch.Data;
using FptJobMatch.Models;
using FptJobMatch.Repository;
using FptJobMatch.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FptJobMatch.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class CategoriesController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CategoriesController(IUnitOfWork unitOfWork)
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
			return user;
		}
		public IActionResult Index()
		{
			List<Categories> myList = _unitOfWork.CategoriesRepository.GetAll().ToList();
			return View(myList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Categories categories)
		{
			ApplicationUser user = TakeUser(TakeIdUser());
			if(ModelState.IsValid)
			{
				_unitOfWork.CategoriesRepository.Add(categories);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(int? id)
		{
			ApplicationUser user = TakeUser(TakeIdUser());
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Categories? category = _unitOfWork.CategoriesRepository.Get(c => c.Id == id);
			if(category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult Edit(Categories category)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.CategoriesRepository.Update(category);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete(int? id)
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
		public IActionResult Delete(Categories category)
		{
			_unitOfWork.CategoriesRepository.Delete(category);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
	
}
