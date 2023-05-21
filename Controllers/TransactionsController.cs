using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankTransactions.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionDbContext _context;
        public TransactionsController(TransactionDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        //GET TRANSACTION ADD OR EDIT
        public IActionResult AddorEdit(int id = 0)
        {   
            if(id == 0)
                return View(new Transaction());

            return View(_context.Transactions.Find(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddorEdit([Bind(
            )] Transaction transaction)
        {
            if (ModelState.IsValid)
            {   
                if(transaction.TransactionId == 0)
                {
                    _context.Add(transaction);
                }
                else
                {
                    _context.Update(transaction);
                }
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
                //return RedirectToAction(nameof(Index));
            }

            //return View(transaction);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", transaction) });
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
            return Json(new {html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
            // return RedirectToAction(nameof(Index));
        }

    }
}
