using EventsViewer.Data;
using EventsViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsViewer.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allEvents = await _context.Events.ToListAsync();
            return View(allEvents);
        }

        public IActionResult Create(int? id)
        {
            return View();
        }
        public IActionResult CreateForm( Event model)
        {
            if (model.Id == 0)
            {
                _context.Events.Add(model);
            }
            else
            {
                _context.Events.Update(model);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {  
            if (id != null)
            {
                var eventInDb = await _context.Events.SingleOrDefaultAsync(x => x.Id == id);
                return View(eventInDb);
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id) 
        {
            var eventInDb = await _context.Events.SingleOrDefaultAsync(x => x.Id == id);
            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
