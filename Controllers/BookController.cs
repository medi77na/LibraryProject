using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Bjijvrrjr8fpicdo4p4kContext _context;


        public BookController(ILogger<PersonController> logger, Bjijvrrjr8fpicdo4p4kContext context)
        {
            _context = context; // Obtener la referencia al contexto de datos
            _logger = logger;
        }

        [HttpGet("CrudBooks")]
        public IActionResult CrudBooks()
        {
            return View();
        }

        [HttpGet("SearchBooks")]
        public IActionResult SearchBooks()
        {
            return View();
        }

        [HttpGet("ShowBooks")]
        public async Task<IActionResult> ShowBooks()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }


        [HttpGet("AllBooksReserved")]
        public IActionResult AllBooksReserved()
        {
            return View();
        }

        [HttpGet("HistoryBooksReserved")]
        public IActionResult HistoryBooksReserved()
        {
            return View();
        }

        [HttpGet("Administrator")]
        public async Task<IActionResult> Administrator()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}