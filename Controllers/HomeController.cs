using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lista_zadataka.Models;

namespace Lista_zadataka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext context;

       
        
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var todos = context.ToDos.ToList();
            return View(todos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/ControllerName/ActionMethod", Name = "NamedRoute")]
        public IActionResult AddToDo(string myToDo)
        {
            ToDo todo = new ToDo() { Name = myToDo };
            context.ToDos.Add(todo);
            context.SaveChanges();
            var todos = context.ToDos.ToList();
            return View("Index", todos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
