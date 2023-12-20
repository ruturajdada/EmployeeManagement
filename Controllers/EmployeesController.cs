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
    public class EmployeesController : Controller
    {
        private readonly MVC_CRUD_DBContext _context;

        public EmployeesController(MVC_CRUD_DBContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
             List<EmployeeViewModel> employees = _context.Employees
               
            .Include(e => e.Address)
            .Include(e => e.Dept)
            .Select(e => new EmployeeViewModel
            {
               StudentId = e.StudentId,
               FirstName = e.FirstName,
                LastName = e.LastName,
                City = e.Address.City,
                DeptName = e.Dept.DeptName

            })
            .ToList();

            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Address)
                .Include(e => e.Dept)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "DeptId");
            return View();
        }

        // POST: Employees/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,DeptId,AddressId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", employee.AddressId);
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "DeptId", employee.DeptId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "City", employee.AddressId);
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "DeptName", employee.DeptId);
            return View(employee);
        }

        // POST: Employees/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,DeptId,AddressId")] Employee employee)
        {
            if (id != employee.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.StudentId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", employee.AddressId);
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "DeptId", employee.DeptId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Address)
                .Include(e => e.Dept)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'MVC_CRUD_DBContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
