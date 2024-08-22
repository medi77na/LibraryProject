using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CrudBooks()
        {
            return View();
        }

<<<<<<< HEAD
        [HttpGet("SearchBooks")]
        public IActionResult SearchBooks()
=======
         [HttpGet("ShowBooks")]
        public IActionResult ShowBooks()
>>>>>>> e0ac24a4498f7bd1863fd31b96e080af37c01cea
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}