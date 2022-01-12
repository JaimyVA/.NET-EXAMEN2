#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStoreExamen.Areas.Identity.Data;
using MovieStoreExamen.Data;

namespace MovieStoreExamen.Controllers
{
    public class ApplicationUserViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUserViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUserViewModel.ToListAsync());
        }

        // GET: ApplicationUserViewModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserViewModel = await _context.ApplicationUserViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserViewModel == null)
            {
                return NotFound();
            }

            return View(applicationUserViewModel);
        }

        // GET: ApplicationUserViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUserViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,FirstName,LastName,Email,Language,PhoneNumber,Lockout,Customer,Worker,Administrator")] ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUserViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUserViewModel);
        }

        // GET: ApplicationUserViewModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserViewModel = await _context.ApplicationUserViewModel.FindAsync(id);
            if (applicationUserViewModel == null)
            {
                return NotFound();
            }
            return View(applicationUserViewModel);
        }

        // POST: ApplicationUserViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,FirstName,LastName,Email,Language,PhoneNumber,Lockout,Customer,Worker,Administrator")] ApplicationUserViewModel applicationUserViewModel)
        {
            if (id != applicationUserViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUserViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserViewModelExists(applicationUserViewModel.Id))
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
            return View(applicationUserViewModel);
        }

        // GET: ApplicationUserViewModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserViewModel = await _context.ApplicationUserViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserViewModel == null)
            {
                return NotFound();
            }

            return View(applicationUserViewModel);
        }

        // POST: ApplicationUserViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUserViewModel = await _context.ApplicationUserViewModel.FindAsync(id);
            _context.ApplicationUserViewModel.Remove(applicationUserViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserViewModelExists(string id)
        {
            return _context.ApplicationUserViewModel.Any(e => e.Id == id);
        }
    }
}
