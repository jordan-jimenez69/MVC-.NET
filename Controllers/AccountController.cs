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

        var user = new Teacher
        {
            FirstName = model.FirstName,
            Name = model.Name,
            UserName = model.FirstName
        };

        // Créer l'utilisateur avec le mot de passe
        var result = await _userManager.CreateAsync(user, model.PasswordHashed);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        var roleName = model.Role.ToString();
        var roleResult = await _userManager.AddToRoleAsync(user, roleName);

        if (!roleResult.Succeeded)
        {
            foreach (var error in roleResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        await _signInManager.SignInAsync(user, isPersistent: false);

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