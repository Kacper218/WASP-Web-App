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
    public class AuthController : Controller
    {
        private readonly DBContext _context;

        public AuthController(DBContext context)
        {
            _context = context;
        }

        // GET: Auth
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Auth.Include(a => a.Users);
            return View(await dBContext.ToListAsync());
        }

        // GET: Auth/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auth = await _context.Auth
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (auth == null)
            {
                return NotFound();
            }

            return View(auth);
        }

        // GET: Auth/Create
        public IActionResult Create()
        {
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name");
            return View();
        }

        // POST: Auth/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_ID,Login,Password,")] Auth auth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name", auth.User_ID);
            return View(auth);
        }

        // GET: Auth/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auth = await _context.Auth.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name", auth.User_ID);
            return View(auth);
        }

        // POST: Auth/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_ID,Login,Password")] Auth auth)
        {
            if (id != auth.User_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthExists(auth.User_ID))
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
            ViewData["User_ID"] = new SelectList(_context.Users, "User_ID", "Name", auth.User_ID);
            return View(auth);
        }

        // GET: Auth/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auth = await _context.Auth
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (auth == null)
            {
                return NotFound();
            }

            return View(auth);
        }

        // POST: Auth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auth = await _context.Auth.FindAsync(id);
            if (auth != null)
            {
                _context.Auth.Remove(auth);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthExists(int id)
        {
            return _context.Auth.Any(e => e.User_ID == id);
        }
    }
}
