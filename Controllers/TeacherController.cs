using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;


namespace MVC.Controllers;

public class TeacherController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<Teacher> _userManager;

    public TeacherController(UserManager<Teacher> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public ActionResult Index()
    {
        var teachers = _userManager.Users;
        return View(teachers.ToList());
    }
}