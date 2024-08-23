using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryProject.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Bjijvrrjr8fpicdo4p4kContext _context;


        public PersonController(ILogger<PersonController> logger, Bjijvrrjr8fpicdo4p4kContext context)
        {
            _context = context; // Obtener la referencia al contexto de datos
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

         [HttpGet("Users")]
        public async Task<IActionResult> Users()
        {
            var persons = await _context.Persons.ToListAsync();
            return View(persons);
        }


        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}