using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WASP_Web_App;

namespace WASP_Web_App.Views
{
    public class ZespolController : Controller
    {
        private readonly DBContext _context;

        public ZespolController(DBContext context)
        {
            _context = context;
        }

        // GET: Zespol
        public async Task<IActionResult> Index()
        {
            Console.WriteLine("zespolControler");
            return View(await _context.ProgramowanieZespolowe.ToListAsync());
        }

        // GET: Zespol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zespol = await _context.ProgramowanieZespolowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zespol == null)
            {
                return NotFound();
            }

            return View(zespol);
        }

        // GET: Zespol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zespol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Pensja")] Zespol zespol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zespol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zespol);
        }

        // GET: Zespol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zespol = await _context.ProgramowanieZespolowe.FindAsync(id);
            if (zespol == null)
            {
                return NotFound();
            }
            return View(zespol);
        }

        // POST: Zespol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Pensja")] Zespol zespol)
        {
            if (id != zespol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zespol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZespolExists(zespol.Id))
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
            return View(zespol);
        }

        // GET: Zespol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zespol = await _context.ProgramowanieZespolowe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zespol == null)
            {
                return NotFound();
            }

            return View(zespol);
        }

        // POST: Zespol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zespol = await _context.ProgramowanieZespolowe.FindAsync(id);
            if (zespol != null)
            {
                _context.ProgramowanieZespolowe.Remove(zespol);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZespolExists(int id)
        {
            return _context.ProgramowanieZespolowe.Any(e => e.Id == id);
        }
    }
}
