using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_Challange.Models;

namespace MVC_CRUD_Challange.Controllers
{
    public class DeptsController : Controller
    {
        private readonly MVC_CRUD_DBContext _context;

        public DeptsController(MVC_CRUD_DBContext context)
        {
            _context = context;
        }

        // GET: Depts
        public async Task<IActionResult> Index()
        {
              return _context.Depts != null ? 
                          View(await _context.Depts.ToListAsync()) :
                          Problem("Entity set 'MVC_CRUD_DBContext.Depts'  is null.");
        }

        // GET: Depts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Depts == null)
            {
                return NotFound();
            }

            var dept = await _context.Depts
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        // GET: Depts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Depts/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptId,DeptName")] Dept dept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

        // GET: Depts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Depts == null)
            {
                return NotFound();
            }

            var dept = await _context.Depts.FindAsync(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        // POST: Depts/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptId,DeptName")] Dept dept)
        {
            if (id != dept.DeptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptExists(dept.DeptId))
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
            return View(dept);
        }

        // GET: Depts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Depts == null)
            {
                return NotFound();
            }

            var dept = await _context.Depts
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        // POST: Depts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Depts == null)
            {
                return Problem("Entity set 'MVC_CRUD_DBContext.Depts'  is null.");
            }
            var dept = await _context.Depts.FindAsync(id);
            if (dept != null)
            {
                _context.Depts.Remove(dept);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptExists(int id)
        {
          return (_context.Depts?.Any(e => e.DeptId == id)).GetValueOrDefault();
        }
    }
}
