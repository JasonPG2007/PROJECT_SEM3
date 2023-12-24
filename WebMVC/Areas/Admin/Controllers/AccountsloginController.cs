using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObjectBussiness;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsloginController : Controller
    {
        private readonly PetroleumBusinessDBContext _context;

        public AccountsloginController(PetroleumBusinessDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Accountslogin
        public async Task<IActionResult> Index()
        {
            var petroleumBusinessDBContext = _context.Accounts.Include(a => a.Exam).Include(a => a.ExamRegister);
            return View(await petroleumBusinessDBContext.ToListAsync());
        }

        // GET: Admin/Accountslogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Exam)
                .Include(a => a.ExamRegister)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/Accountslogin/Create
        public IActionResult Create()
        {
            ViewData["ExamID"] = new SelectList(_context.Exams, "ExamID", "Status");
            ViewData["ExamRegisterID"] = new SelectList(_context.ExamRegister, "ExamRegisterID", "CandidateName");
            return View();
        }

        // POST: Admin/Accountslogin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,ExamID,ExamRegisterID,HashedPassword")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamID"] = new SelectList(_context.Exams, "ExamID", "Status", account.ExamID);
            ViewData["ExamRegisterID"] = new SelectList(_context.ExamRegister, "ExamRegisterID", "CandidateName", account.ExamRegisterID);
            return View(account);
        }

        // GET: Admin/Accountslogin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["ExamID"] = new SelectList(_context.Exams, "ExamID", "Status", account.ExamID);
            ViewData["ExamRegisterID"] = new SelectList(_context.ExamRegister, "ExamRegisterID", "CandidateName", account.ExamRegisterID);
            return View(account);
        }

        // POST: Admin/Accountslogin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,ExamID,ExamRegisterID,HashedPassword")] Account account)
        {
            if (id != account.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountID))
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
            ViewData["ExamID"] = new SelectList(_context.Exams, "ExamID", "Status", account.ExamID);
            ViewData["ExamRegisterID"] = new SelectList(_context.ExamRegister, "ExamRegisterID", "CandidateName", account.ExamRegisterID);
            return View(account);
        }

        // GET: Admin/Accountslogin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Exam)
                .Include(a => a.ExamRegister)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/Accountslogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'PetroleumBusinessDBContext.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.AccountID == id)).GetValueOrDefault();
        }
    }
}
