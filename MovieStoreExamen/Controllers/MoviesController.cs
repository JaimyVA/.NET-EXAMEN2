#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStoreExamen.Data;
using MovieStoreExamen.Models;

namespace MovieStoreExamen.Controllers
{
    public class MoviesController : ApplicationController
    {
        public MoviesController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationController> logger)
            : base(context, httpContextAccessor, logger)
        {
        }

        // GET: Movies
        [Authorize(Roles = "Administrator,Worker")]
        public async Task<IActionResult> Index()
        {
            var movieStoreExamenContext = _context.Movie.Include(m => m.Genre);
            return View(await movieStoreExamenContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Gent()
        {
            var movieStoreExamenContext = _context.Movie.Include(m => m.Genre);
            return View(await movieStoreExamenContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Brussel()
        {
            var movieStoreExamenContext = _context.Movie.Include(m => m.Genre);
            return View(await movieStoreExamenContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Antwerpen()
        {
            var movieStoreExamenContext = _context.Movie.Include(m => m.Genre);
            return View(await movieStoreExamenContext.ToListAsync());
        }

        // GET: Movies/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = "Administrator,Worker")]
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Worker")]
        public async Task<IActionResult> Create([Bind("MovieId,MovieTitle,Rating,Rental_Duration,Amount_Gent,Amount_Brussel,Amount_Antwerpen,Amount_Returned,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Administrator,Worker")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Worker")]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieTitle,Rating,Rental_Duration,Amount_Gent,Amount_Brussel,Amount_Antwerpen,Amount_Returned,GenreId")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Administrator,Worker")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Worker")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }
    }
}
