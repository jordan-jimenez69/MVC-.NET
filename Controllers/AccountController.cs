using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

public class AccountController : Controller
{
    private readonly SignInManager<Teacher> _signInManager;
    private readonly UserManager<Teacher> _userManager;

    public AccountController(SignInManager<Teacher> signInManager, UserManager<Teacher> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new AccountModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Créer un nouvel utilisateur
        var user = new Teacher
        {
            FirstName = model.FirstName,
            Name = model.Name,
            UserName = model.FirstName // Utilisez un identifiant unique ici si nécessaire
        };

        // Créer l'utilisateur
        var result = await _userManager.CreateAsync(user, model.PasswordHashed);

        // Si la création a échoué, ajouter les erreurs au modèle et retourner la vue
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        // Ajouter l'utilisateur au rôle "Teacher"
        var roleResult = await _userManager.AddToRoleAsync(user, "Teacher");

        // Si l'ajout du rôle échoue, ajouter les erreurs au modèle et retourner la vue
        if (!roleResult.Succeeded)
        {
            foreach (var error in roleResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        // Connexion automatique après l'inscription
        await _signInManager.SignInAsync(user, isPersistent: false);

        // Rediriger vers la page des événements si tout est réussi
        return RedirectToAction("Index", "Event");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            model.UserName,
            model.PasswordHashed,
            false,
            false
        );

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Event");
        }

        ModelState.AddModelError(string.Empty, "Nom d'utilisateur ou mot de passe incorrect.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}