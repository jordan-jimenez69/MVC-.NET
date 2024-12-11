using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

      

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Account");
            }
            return View(teacher);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
