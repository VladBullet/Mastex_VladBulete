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
            model.Projects = new List<ProjectDto>
            {
                new ProjectDto
                {
                    Id =1,
                    AssingedUsers =new List<UserDto>
                    {
                        new UserDto
                        {
                            Id = 1,
                            Deleted = false,
                            Name = "Ian Miller",
                            Role = "Default"
                        },
                         new UserDto
                        {
                            Id = 2,
                            Deleted = false,
                            Name = "Maria Popescu",
                            Role = "Default"
                        }
                    },
                    Deleted = false,
                    //Status = StatusEnum.Researching,
                    Title = "Project 1",
                    Description ="Some quick example text to build on the card title and make up the bulk of the card's content.",
                    Tasks = new List<TaskDto>
                    {
                    new TaskDto
                    {
                        Id = 1,
                        AssignedUserId = 1,
                        Deleted = false,
                        Description = "Description for task 1",
                        ProjectId = 1,
                        Title = "Task 1",
                        Status = "Researching",
                    },
                     new TaskDto
                    {
                        Id = 2,
                        AssignedUserId = 1,
                        Deleted = false,
                        Description = "Description for task 2",
                        ProjectId = 1,
                        Title = "Task 2",
                        Status = "Researching",
                    },
                      new TaskDto
                    {
                        Id = 3,
                        AssignedUserId = 2,
                        Deleted = false,
                        Description = "Description for task 3",
                        ProjectId = 1,
                        Title = "Task 3",
                        Status = "Created",
                    }
                    }
                },
                new ProjectDto
                {
                    Id =2,
                    AssingedUsers =new List<UserDto>
                    {
                         new UserDto
                        {
                            Id = 2,
                            Deleted = false,
                            Name = "Maria Popescu",
                            Role = "Default"
                        }
                    },
                    Deleted = false,
                    //Status = StatusEnum.InProgress,
                    Title = "Project 2",
                    Description ="Some quick example text to build on the card title and make up the bulk of the card's content.",
                    Tasks = new List<TaskDto>
                    {
                    new TaskDto
                    {
                        Id = 4,
                        AssignedUserId = 2,
                        Deleted = false,
                        Description = "Description for task 4",
                        ProjectId = 2,
                        Title = "Task 4",
                        Status = "InProgress",
                    },
                     new TaskDto
                    {
                        Id = 5,
                        AssignedUserId = 2,
                        Deleted = false,
                        Description = "Description for task 5",
                        ProjectId = 2,
                        Title = "Task 5",
                        Status = "Done",
                    },
                      new TaskDto
                    {
                        Id = 6,
                        AssignedUserId = 2,
                        Deleted = false,
                        Description = "Description for task 6",
                        ProjectId = 2,
                        Title = "Task 6",
                        Status = "Created",
                    }
                    }
                },
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
