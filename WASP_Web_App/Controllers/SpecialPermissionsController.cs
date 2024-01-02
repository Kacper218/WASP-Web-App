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
    public class SpecialPermissionsController : Controller
    {
        private readonly DBContext _context;

        public SpecialPermissionsController(DBContext context)
        {
            _context = context;
        }

        // GET: SpecialPermissions
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.SpecialPermissions.Include(s => s.Auth).Include(s => s.Keys);
            return View(await dBContext.ToListAsync());
        }

        // GET: SpecialPermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPermissions = await _context.SpecialPermissions
                .Include(s => s.Auth)
                .Include(s => s.Keys)
                .FirstOrDefaultAsync(m => m.SpecialPermission_ID == id);
            if (specialPermissions == null)
            {
                return NotFound();
            }

            return View(specialPermissions);
        }

        // GET: SpecialPermissions/Create
        public IActionResult Create()
        {
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login");
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room");
            return View();
        }

        // POST: SpecialPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialPermission_ID,User_ID,Key_ID,From,To")] SpecialPermissions specialPermissions)
        {
            if (ModelState.IsValid)
            {
                specialPermissions.From = specialPermissions.From.ToUniversalTime();
                specialPermissions.To = specialPermissions.To.ToUniversalTime();
                _context.Add(specialPermissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login", specialPermissions.User_ID);
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room", specialPermissions.Key_ID);
            return View(specialPermissions);
        }

        // GET: SpecialPermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPermissions = await _context.SpecialPermissions.FindAsync(id);
            if (specialPermissions == null)
            {
                return NotFound();
            }
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login", specialPermissions.User_ID);
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room", specialPermissions.Key_ID);
            return View(specialPermissions);
        }

        // POST: SpecialPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialPermission_ID,User_ID,Key_ID,From,To")] SpecialPermissions specialPermissions)
        {
            if (id != specialPermissions.SpecialPermission_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    specialPermissions.From = specialPermissions.From.ToUniversalTime();
                    specialPermissions.To = specialPermissions.To.ToUniversalTime();
                    _context.Update(specialPermissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialPermissionsExists(specialPermissions.SpecialPermission_ID))
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
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login", specialPermissions.User_ID);
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Room", specialPermissions.Key_ID);
            return View(specialPermissions);
        }

        // GET: SpecialPermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialPermissions = await _context.SpecialPermissions
                .Include(s => s.Auth)
                .Include(s => s.Keys)
                .FirstOrDefaultAsync(m => m.SpecialPermission_ID == id);
            if (specialPermissions == null)
            {
                return NotFound();
            }

            return View(specialPermissions);
        }

        // POST: SpecialPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialPermissions = await _context.SpecialPermissions.FindAsync(id);
            if (specialPermissions != null)
            {
                _context.SpecialPermissions.Remove(specialPermissions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialPermissionsExists(int id)
        {
            return _context.SpecialPermissions.Any(e => e.SpecialPermission_ID == id);
        }
    }
}
