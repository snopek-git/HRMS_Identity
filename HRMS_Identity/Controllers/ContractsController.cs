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
    public class ContractsController : Controller
    {
        private readonly s15153Context _context;

        public ContractsController(s15153Context context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var s15153Context = _context.Contract.Include(c => c.IdContractStatusNavigation).Include(c => c.IdContractTypeNavigation).Include(c => c.IdEmployeeNavigation);
            return View(await s15153Context.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .Include(c => c.IdContractStatusNavigation)
                .Include(c => c.IdContractTypeNavigation)
                .Include(c => c.IdEmployeeNavigation)
                .FirstOrDefaultAsync(m => m.IdContract == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["IdContractStatus"] = new SelectList(_context.ContractStatus, "IdContractStatus", "StatusName");
            ViewData["IdContractType"] = new SelectList(_context.ContractType, "IdContractType", "ContractType1");
            ViewData["IdEmployee"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContract,ContractNumber,Salary,ContractStart,ContractEnd,IdContractType,IdEmployee,IdContractStatus")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdContractStatus"] = new SelectList(_context.ContractStatus, "IdContractStatus", "StatusName", contract.IdContractStatus);
            ViewData["IdContractType"] = new SelectList(_context.ContractType, "IdContractType", "ContractType1", contract.IdContractType);
            ViewData["IdEmployee"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress", contract.IdEmployee);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["IdContractStatus"] = new SelectList(_context.ContractStatus, "IdContractStatus", "StatusName", contract.IdContractStatus);
            ViewData["IdContractType"] = new SelectList(_context.ContractType, "IdContractType", "ContractType1", contract.IdContractType);
            ViewData["IdEmployee"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress", contract.IdEmployee);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContract,ContractNumber,Salary,ContractStart,ContractEnd,IdContractType,IdEmployee,IdContractStatus")] Contract contract)
        {
            if (id != contract.IdContract)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.IdContract))
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
            ViewData["IdContractStatus"] = new SelectList(_context.ContractStatus, "IdContractStatus", "StatusName", contract.IdContractStatus);
            ViewData["IdContractType"] = new SelectList(_context.ContractType, "IdContractType", "ContractType1", contract.IdContractType);
            ViewData["IdEmployee"] = new SelectList(_context.Employee, "IdEmployee", "EmailAddress", contract.IdEmployee);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .Include(c => c.IdContractStatusNavigation)
                .Include(c => c.IdContractTypeNavigation)
                .Include(c => c.IdEmployeeNavigation)
                .FirstOrDefaultAsync(m => m.IdContract == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.IdContract == id);
        }
    }
}
