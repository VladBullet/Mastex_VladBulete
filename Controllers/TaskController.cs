using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mastex_BuleteVlad.BLL.Services;
using Mastex_BuleteVlad.ViewModels;
using Mastex_VladBulete.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mastex_BuleteVlad.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly ISharedService _sharedService;
        public TaskController(ITaskService taskService, IProjectService projService, ISharedService sharedService)
        {
            _taskService = taskService;
            _projectService = projService;
            _sharedService = sharedService;
        }

        // GET: Task
        public ActionResult Index()
        {
            var model = new TaskHomeViewModel();
            var result = _taskService.GetAllTasks();
            var allProj = _projectService.GetAllProjects();

            foreach (var item in allProj)
            {
                model.ProjectFilters.Add(new ProjectViewModel(item));
            }
            foreach (var item in result)
            {
                model.Tasks.Add(new TaskViewModel(item));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult List(int projectId)
        {
            var model = new List<TaskViewModel>();

            var result = new List<TaskDto>();
            if (projectId == 0)
            {
                result = _taskService.GetAllTasks();
            }
            else
            {
                result = _sharedService.GetTasksByProjectId(projectId);
            }
            foreach (var item in result)
            {
                model.Add(new TaskViewModel(item));
            }
            return PartialView("_TaskList", model);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}