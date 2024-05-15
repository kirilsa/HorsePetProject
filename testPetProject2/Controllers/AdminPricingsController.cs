using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testPetProject2.Data;
using testPetProject2.Models;

namespace testPetProject2.Controllers.old
{
    [Authorize]
    public class AdminPricingsController : Controller
    {
        private readonly DataContext _context;

        public AdminPricingsController(DataContext context)
        {
            _context = context;
        }

        // GET: AdminPricings
        public async Task<IActionResult> AdminPricing()
        {
            return _context.Pricings != null ?
                        View(await _context.Pricings.ToListAsync()) :
                        Problem("Entity set 'TaskManagerContext.Pricings'  is null.");
        }

        // GET: AdminPricings/CustomerDetails/5
        public async Task<IActionResult> CustomerDetails(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var pricing = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (pricing == null)
            {
                return NotFound();
            }

            return View(pricing);
        }

        // GET: AdminPricings/Create
        public IActionResult CreatePrice()
        {
            return View();
        }

        // POST: AdminPricings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOfService,LengthOfSession,Price,ListOfIncluded")] Pricing pricing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pricing);
        }

        // GET: AdminPricings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pricings == null)
            {
                return NotFound();
            }

            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing == null)
            {
                return NotFound();
            }
            return View(pricing);
        }

        // POST: AdminPricings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfService,LengthOfSession,Price,ListOfIncluded")] Pricing pricing)
        {
            if (id != pricing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricingExists(pricing.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pricing);
        }

        // GET: AdminPricings/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: AdminPricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pricings == null)
            {
                return Problem("Entity set 'TaskManagerContext.Pricings'  is null.");
            }
            var pricing = await _context.Pricings.FindAsync(id);
            if (pricing != null)
            {
                _context.Pricings.Remove(pricing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AdminRequests()
        {
            return _context.Customers != null ?
                        View(await _context.Customers.ToListAsync()) :
                        Problem("Entity set 'TaskManagerContext.Customers'  is null.");
        }

        private bool PricingExists(int id)
        {
            return (_context.Pricings?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
