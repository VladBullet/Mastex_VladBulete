using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mastex_BuleteVlad.Models;
using Mastex_BuleteVlad.ViewModels;
using Mastex_BuleteVlad.BLL.Services;
using Mastex_VladBulete.BLL.DTO;
using Mastex_BuleteVlad.BLL.DTO;

namespace Mastex_BuleteVlad.Controllers
{
    public class HomeController : Controller
    {
        private IProjectService _projectService;

        public HomeController(IProjectService projService)
        {
            _projectService = projService;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            // this line will be used when there is data in the database
            var projects = _projectService.GetAllProjects();
            var modelProjectList = new List<ProjectViewModel>();
            foreach (var item in projects)
            {
                modelProjectList.Add(new ProjectViewModel(item));
            }
            model.Projects = modelProjectList;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
