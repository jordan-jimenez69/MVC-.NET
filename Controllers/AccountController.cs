using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Data;
using System.Linq;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Rechercher l'utilisateur dans la base de données
            var user = _context.Teachers.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Si l'utilisateur existe, rediriger vers une page personnalisée
                return RedirectToAction("Index", "Student");
            }

            // Si les informations sont incorrectes, afficher une erreur
            ViewBag.Error = "Email ou mot de passe incorrect.";
            return View();
        }
    }
}
