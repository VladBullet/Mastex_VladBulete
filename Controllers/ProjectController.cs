﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mastex_BuleteVlad.BLL.DTO;
using Mastex_BuleteVlad.BLL.Services;
using Mastex_BuleteVlad.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mastex_BuleteVlad.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        public ProjectController(IProjectService projService, IUserService userService)
        {
            _projectService = projService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var serviceResult = _projectService.GetProjectById(id);
            var model = new ProjectDetailsViewModel(new ProjectViewModel(serviceResult));
            var users = _userService.GetUsersByProjectId(serviceResult.Id);
            var assignedUsers = new List<UserViewModel>();
            foreach (var item in users)
            {
                assignedUsers.Add(new UserViewModel(item));
            }
            model.AssignedUsers = assignedUsers;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string title, string description)
        {
            try
            {
                // TODO: Add insert logic here
                //return RedirectToAction(nameof(Index));
                return null;
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string title, string description, string status, string color)
        {
            try
            {
                // TODO: Add update logic here

                //return RedirectToAction(nameof(Index));
                return null;
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                //return RedirectToAction(nameof(Index));
                return null;
            }
            catch
            {
                return View();
            }
        }
    }
}