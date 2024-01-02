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
    public class KeysController : Controller
    {
        private readonly DBContext _context;

        public KeysController(DBContext context)
        {
            _context = context;
        }

        // GET: Keys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Keys.ToListAsync());
        }

        // GET: Keys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keys = await _context.Keys
                .FirstOrDefaultAsync(m => m.Key_ID == id);
            if (keys == null)
            {
                return NotFound();
            }

            return View(keys);
        }

        // GET: Keys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Keys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Key_ID,Room")] Keys keys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keys);
        }

        // GET: Keys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keys = await _context.Keys.FindAsync(id);
            if (keys == null)
            {
                return NotFound();
            }
            return View(keys);
        }

        // POST: Keys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Key_ID,Room")] Keys keys)
        {
            if (id != keys.Key_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeysExists(keys.Key_ID))
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
            return View(keys);
        }

        // GET: Keys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keys = await _context.Keys
                .FirstOrDefaultAsync(m => m.Key_ID == id);
            if (keys == null)
            {
                return NotFound();
            }

            return View(keys);
        }

        // POST: Keys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keys = await _context.Keys.FindAsync(id);
            if (keys != null)
            {
                _context.Keys.Remove(keys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeysExists(int id)
        {
            return _context.Keys.Any(e => e.Key_ID == id);
        }
    }
}
