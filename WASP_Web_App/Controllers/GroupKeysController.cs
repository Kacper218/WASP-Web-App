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
    public class GroupKeysController : Controller
    {
        private readonly DBContext _context;

        public GroupKeysController(DBContext context)
        {
            _context = context;
        }

        // GET: GroupKeys
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.GroupKeys.Include(g => g.Groups).Include(g => g.Keys);
            return View(await dBContext.ToListAsync());
        }

        // GET: GroupKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupKeys = await _context.GroupKeys
                .Include(g => g.Groups)
                .Include(g => g.Keys)
                .FirstOrDefaultAsync(m => m.GroupKey_ID == id);
            if (groupKeys == null)
            {
                return NotFound();
            }

            return View(groupKeys);
        }

        // GET: GroupKeys/Create
        public IActionResult Create()
        {
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Group_ID");
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Key_ID");
            return View();
        }

        // POST: GroupKeys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupKey_ID,Key_ID,Group_ID")] GroupKeys groupKeys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupKeys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Group_ID", groupKeys.Group_ID);
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Key_ID", groupKeys.Key_ID);
            return View(groupKeys);
        }

        // GET: GroupKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupKeys = await _context.GroupKeys.FindAsync(id);
            if (groupKeys == null)
            {
                return NotFound();
            }
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Group_ID", groupKeys.Group_ID);
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Key_ID", groupKeys.Key_ID);
            return View(groupKeys);
        }

        // POST: GroupKeys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupKey_ID,Key_ID,Group_ID")] GroupKeys groupKeys)
        {
            if (id != groupKeys.GroupKey_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupKeys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupKeysExists(groupKeys.GroupKey_ID))
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
            ViewData["Group_ID"] = new SelectList(_context.Groups, "Group_ID", "Group_ID", groupKeys.Group_ID);
            ViewData["Key_ID"] = new SelectList(_context.Keys, "Key_ID", "Key_ID", groupKeys.Key_ID);
            return View(groupKeys);
        }

        // GET: GroupKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupKeys = await _context.GroupKeys
                .Include(g => g.Groups)
                .Include(g => g.Keys)
                .FirstOrDefaultAsync(m => m.GroupKey_ID == id);
            if (groupKeys == null)
            {
                return NotFound();
            }

            return View(groupKeys);
        }

        // POST: GroupKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupKeys = await _context.GroupKeys.FindAsync(id);
            if (groupKeys != null)
            {
                _context.GroupKeys.Remove(groupKeys);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupKeysExists(int id)
        {
            return _context.GroupKeys.Any(e => e.GroupKey_ID == id);
        }
    }
}
