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
        private readonly ILogger<BookController> _logger;
        private readonly Bjijvrrjr8fpicdo4p4kContext _context;


        public BookController(ILogger<BookController> logger, Bjijvrrjr8fpicdo4p4kContext context)
        {
            _context = context; // Obtener la referencia al contexto de datos
            _logger = logger;
        }

        [HttpGet("CrudBooks")]
        public IActionResult CrudBooks()
        {
            return View();
        }

        [HttpGet("ShowBooks")]
        public async Task<IActionResult> ShowBooks()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }


        [HttpGet("SearchBook")]
        public IActionResult SearchBook()
        {
            return View();
        }

        [HttpGet("BooksBorrowed")]
        public IActionResult BooksBorrowed()
        {
            return View();
        }

        [HttpGet("Administrator")]
        public async Task<IActionResult> Administrator()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        // metodo eliminar en ShowBooks
        [HttpPost("ShowBooks")]
        public async Task<IActionResult> ShowBooks(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("ShowBooks");
        }

        //metodo para eliminar en administrator
        [HttpPost("Administrador")]
        public async Task<IActionResult> Administrador(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("Administrador");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}