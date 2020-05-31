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
            //model.Projects = _projectService.GetAllProjects(); 

            // mock of the projects for testing
            // instead of the line below
            model.Projects = new List<ProjectViewModel>
            {
                new ProjectViewModel
                {
                    Id = 1,
                    //Status = StatusEnum.Researching,
                    Title = "Project 1",
                    Description ="Some quick example text to build on the card title and make up the bulk of the card's content.",
                    Status = StatusEnum.Researching
                },
                new ProjectViewModel
                {
                    Id = 2,
                    //Status = StatusEnum.Researching,
                    Title = "Project 2",
                    Description ="Some quick example text to build on the card title and make up the bulk of the card's content.",
                    Status = StatusEnum.InProgress
                },
                new ProjectViewModel
                {
                    Id = 3,
                    //Status = StatusEnum.Researching,
                    Title = "Project 3",
                    Description ="Some quick example text to build on the card title and make up the bulk of the card's content.",
                    Status = StatusEnum.Done
                }


            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
