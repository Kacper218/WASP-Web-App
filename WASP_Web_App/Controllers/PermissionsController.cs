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
    public class PermissionsController : Controller
    {
        private readonly DBContext _context;

        public PermissionsController(DBContext context)
        {
            _context = context;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.Permissions.Include(p => p.Auth).Include(p => p.Groups);
            return View(await dBContext.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permissions
                .Include(p => p.Auth)
                .Include(p => p.Groups)
                .FirstOrDefaultAsync(m => m.Permission_ID == id);
            if (permissions == null)
            {
                return NotFound();
            }

            return View(permissions);
        }

        // GET: Permissions/Create
        public IActionResult Create()
        {
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login");
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Name");
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Permission_ID,User_ID,Group_ID")] Permissions permissions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login", permissions.User_ID);
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Name", permissions.Group_ID);
            return View(permissions);
        }

        // GET: Permissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permissions.FindAsync(id);
            if (permissions == null)
            {
                return NotFound();
            }
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login", permissions.User_ID);
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Name", permissions.Group_ID);
            return View(permissions);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Permission_ID,User_ID,Group_ID")] Permissions permissions)
        {
            if (id != permissions.Permission_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionsExists(permissions.Permission_ID))
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
            ViewData["User_ID"] = new SelectList(_context.Auth, "User_ID", "Login", permissions.User_ID);
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Name", permissions.Group_ID);
            return View(permissions);
        }

        // GET: Permissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permissions
                .Include(p => p.Auth)
                .Include(p => p.Groups)
                .FirstOrDefaultAsync(m => m.Permission_ID == id);
            if (permissions == null)
            {
                return NotFound();
            }

            return View(permissions);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permissions = await _context.Permissions.FindAsync(id);
            if (permissions != null)
            {
                _context.Permissions.Remove(permissions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionsExists(int id)
        {
            return _context.Permissions.Any(e => e.Permission_ID == id);
        }
    }
}
