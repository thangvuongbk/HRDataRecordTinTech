using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRDataRecordTinTech.Models;



namespace HRDataRecordTinTech.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)        
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                //.FirstOrDefaultAsync(m => m.EmployeeId == id);
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,EmployeeNumber,Phone,Email,EmployeeID,Position,Salary,bTOEIC,bEducation,bJapanese")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Server Side Validation for required info
                bool isEmployeeNumberExists = _context.Employees.Any(e => e.EmployeeNumber == employee.EmployeeNumber);
                bool isFullNameExists = _context.Employees.Any(e => e.FullName == employee.FullName);
                bool isPhoneExists = _context.Employees.Any(e => e.Phone == employee.Phone);
                bool isEmailExists = _context.Employees.Any(e => e.Email == employee.Email);
                bool isEmployeeIDExists = _context.Employees.Any(e => e.EmployeeID == employee.EmployeeID);

                if (isEmployeeNumberExists)
                {
                    ModelState.AddModelError("EmployeeNumber", "This Employee numbem already registered");
                    return View(employee);
                }

                if (isFullNameExists)
                {
                    ModelState.AddModelError("FullName", "This Employee Name already registered");
                    return View(employee);
                }

                if (isPhoneExists)
                {
                    ModelState.AddModelError("Phone", "This Phone numbem already registered");
                    return View(employee);
                }

                if (isEmailExists)
                {
                    ModelState.AddModelError("Email", "This Email address already registered");
                    return View(employee);
                }

                if (isEmployeeIDExists)
                {
                    ModelState.AddModelError("EmployeeID", "This Employee ID already registered");
                    return View(employee);
                }


                //
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public string RequiredInfoExist(Employee employee)
        {
            string m_strWarning = "";
            _context.Employees.Any(e => e.FullName == employee.FullName);           

            return m_strWarning;
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,EmployeeNumber,Phone,Email,EmployeeID,Position,Salary,bTOEIC,bEducation,bJapanese")] Employee employee)
        {
            //if (id != employee.EmployeeId)
            if (id != employee.Id)
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
                    //if (!EmployeeExists(employee.EmployeeId))
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                //.FirstOrDefaultAsync(m => m.EmployeeId == id);
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            //return _context.Employees.Any(e => e.EmployeeId == id);
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
