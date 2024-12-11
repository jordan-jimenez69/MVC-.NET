using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MVC.Models;
using MVC.Data;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                // Ajouter l'enseignant à la base de données
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Email == email && t.Password == password);
            if (teacher != null)
            {
                // Créer les revendications pour l'utilisateur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, teacher.Name),
                    new Claim(ClaimTypes.Email, teacher.Email),
                    new Claim("Role", "Teacher")
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                // Connexion utilisateur
                await HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Index", "Student"); // Redirige vers la liste des étudiants
            }

            ViewBag.Error = "Email ou mot de passe incorrect.";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }
    }
}
