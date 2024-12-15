using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        // Action avec filtrage par date
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            var eventsQuery = _context.Events.AsQueryable();

            if (startDate.HasValue)
            {
                eventsQuery = eventsQuery.Where(e => e.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                eventsQuery = eventsQuery.Where(e => e.Date <= endDate.Value);
            }

            var events = await eventsQuery.ToListAsync();
            return View(events);
        }

        // Détail de l'événement
        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        // Créer un événement
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventItem);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "L'événement a été créé avec succès !"; // Message de succès
                return RedirectToAction(nameof(Index));
            }

            return View(eventItem);
        }

        // Modifier un événement
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(eventItem);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "L'événement a été modifié avec succès !"; // Message de succès
                return RedirectToAction(nameof(Index));
            }

            return View(eventItem);
        }

        // Supprimer un événement
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem != null)
            {
                _context.Events.Remove(eventItem);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "L'événement a été supprimé avec succès !"; // Message de succès
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
