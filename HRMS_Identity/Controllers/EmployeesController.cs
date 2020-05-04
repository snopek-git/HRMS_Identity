using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMS_Identity.Models;

namespace HRMS_Identity.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly s15153Context _context;

        public EmployeesController(s15153Context context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var s15153Context = _context.Employee.Include(e => e.IdJobNavigation).Include(e => e.IdManagerNavigation).Include(e => e.IdRoleNavigation);
            return View(await s15153Context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.IdJobNavigation)
                .Include(e => e.IdManagerNavigation)
                .Include(e => e.IdRoleNavigation)
                .FirstOrDefaultAsync(m => m.IdEmployee == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "JobName");
            ViewData["IdManager"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress");
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "RoleName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmployee,FirstName,SecondName,LastName,Pesel,IdCardNumber,BirthDate,PhoneNumber,EmailAddress,Login,Password,IdJob,IdManager,IsActive,IdRole")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "JobName", employee.IdJob);
            ViewData["IdManager"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress", employee.IdManager);
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "RoleName", employee.IdRole);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "JobName", employee.IdJob);
            ViewData["IdManager"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress", employee.IdManager);
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "RoleName", employee.IdRole);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmployee,FirstName,SecondName,LastName,Pesel,IdCardNumber,BirthDate,PhoneNumber,EmailAddress,Login,Password,IdJob,IdManager,IsActive,IdRole")] Employee employee)
        {
            if (id != employee.IdEmployee)
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
                    if (!EmployeeExists(employee.IdEmployee))
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
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "JobName", employee.IdJob);
            ViewData["IdManager"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress", employee.IdManager);
            ViewData["IdRole"] = new SelectList(_context.Role, "IdRole", "RoleName", employee.IdRole);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.IdJobNavigation)
                .Include(e => e.IdManagerNavigation)
                .Include(e => e.IdRoleNavigation)
                .FirstOrDefaultAsync(m => m.IdEmployee == id);
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
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.IdEmployee == id);
        }
    }
}
