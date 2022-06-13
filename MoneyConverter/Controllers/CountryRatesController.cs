  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyConverter.Data;
using MoneyConverter.Models;

namespace MoneyConverter.Controllers
{
    public class CountryRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CountryRates
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountryRates.ToListAsync());
        }

        // GET: CountryRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryRate = await _context.CountryRates
                .FirstOrDefaultAsync(m => m.CountryRateId == id);
            if (countryRate == null)
            {
                return NotFound();
            }

            return View(countryRate);
        }

        // GET: CountryRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryRateId,Name,CountryId")] CountryRate countryRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryRate);
        }

        // GET: CountryRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryRate = await _context.CountryRates.FindAsync(id);
            if (countryRate == null)
            {
                return NotFound();
            }
            return View(countryRate);
        }

        // POST: CountryRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryRateId,Name,CountryId")] CountryRate countryRate)
        {
            if (id != countryRate.CountryRateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryRateExists(countryRate.CountryRateId))
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
            return View(countryRate);
        }

        // GET: CountryRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryRate = await _context.CountryRates
                .FirstOrDefaultAsync(m => m.CountryRateId == id);
            if (countryRate == null)
            {
                return NotFound();
            }

            return View(countryRate);
        }

        // POST: CountryRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryRate = await _context.CountryRates.FindAsync(id);
            _context.CountryRates.Remove(countryRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryRateExists(int id)
        {
            return _context.CountryRates.Any(e => e.CountryRateId == id);
        }
    }
}
