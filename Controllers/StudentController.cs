using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Student> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StudentController(AppDbContext context, UserManager<Student> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student, string password)
        {
            if (ModelState.IsValid)
            {
                // Création de l'utilisateur étudiant
                var result = await _userManager.CreateAsync(student, password);

                if (result.Succeeded)
                {
                    // Assurez-vous que le rôle Student existe dans la base de données
                    if (!await _roleManager.RoleExistsAsync("Student"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Student"));
                    }

                    // Attribution du rôle Student
                    await _userManager.AddToRoleAsync(student, "Student");

                    _context.Students.Add(student);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                // Gestion des erreurs
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
