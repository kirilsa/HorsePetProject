using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testPetProject2.Data;
using testPetProject2.Models;

namespace testPetProject2.Controllers.old
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FullName,Message,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Privacy));
            }
            return View(customer);
        }

        public async Task<IActionResult> Pricing()
        {
            return _context.Pricings != null ?
                        View(await _context.Pricings.ToListAsync()) :
                        Problem("Entity set 'TaskManagerContext.Pricings'  is null.");
        }

        // GET: Home/PricingDetails/5
        public async Task<IActionResult> PricingDetails(int? id)
        {
            if (id == null || _context.Pricings == null)
            {
                return NotFound();
            }

            var pricing = await _context.Pricings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricing == null)
            {
                return NotFound();
            }

            return View(pricing);
        }
    }
}