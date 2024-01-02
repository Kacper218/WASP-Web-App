using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WASP_Web_App.Entities;

namespace WASP_Web_App.Controllers
{
    public class RentController : Controller
    {
        private readonly DBContext _context;

        public RentController(DBContext context)
        {
            _context = context;
        }

        // GET: Rent
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Rent.Include(r => r.Keys).Include(r => r.Users);
            return View(await dBContext.ToListAsync());
        }

        // GET: Rent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .Include(r => r.Keys)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.Rent_ID == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rent/Create
        public IActionResult Create()
        {
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room");
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name");
            return View();
        }

        // POST: Rent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rent_ID,User_ID,Key_ID,From,To")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                rent.From = rent.From.ToUniversalTime();
                rent.To = rent.To.ToUniversalTime();
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room", rent.Key_ID);
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name", rent.User_ID);
            return View(rent);
        }

        // GET: Rent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room", rent.Key_ID);
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name", rent.User_ID);
            return View(rent);
        }

        // POST: Rent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rent_ID,User_ID,Key_ID,From,To")] Rent rent)
        {
            rent.From = rent.From.ToUniversalTime();
            rent.To = rent.To.ToUniversalTime();
            if (id != rent.Rent_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.Rent_ID))
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
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room", rent.Key_ID);
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name", rent.User_ID);
            return View(rent);
        }

        // GET: Rent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .Include(r => r.Keys)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.Rent_ID == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent != null)
            {
                _context.Rent.Remove(rent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
            return _context.Rent.Any(e => e.Rent_ID == id);
        }
    }
}
