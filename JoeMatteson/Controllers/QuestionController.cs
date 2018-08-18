using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JoeMatteson.Models;

namespace JoeMatteson.Controllers
{
    public class QuestionController : Controller
    {
        private readonly JoeMattesonContext _context;

        public QuestionController(JoeMattesonContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionViewModel.ToListAsync());
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionViewModel = await _context.QuestionViewModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (questionViewModel == null)
            {
                return NotFound();
            }

            return View(questionViewModel);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Question,Answer")] QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionViewModel);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionViewModel = await _context.QuestionViewModel.SingleOrDefaultAsync(m => m.ID == id);
            if (questionViewModel == null)
            {
                return NotFound();
            }
            return View(questionViewModel);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Question,Answer")] QuestionViewModel questionViewModel)
        {
            if (id != questionViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionViewModelExists(questionViewModel.ID))
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
            return View(questionViewModel);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionViewModel = await _context.QuestionViewModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (questionViewModel == null)
            {
                return NotFound();
            }

            return View(questionViewModel);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionViewModel = await _context.QuestionViewModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.QuestionViewModel.Remove(questionViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionViewModelExists(int id)
        {
            return _context.QuestionViewModel.Any(e => e.ID == id);
        }
    }
}
