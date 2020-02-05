using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WikiDataNepal.Models;
using WikiNepalData;
using WikiNepalData.Model;

namespace WikiDataNepal.Controllers
{
    public class NepalDataModelsController : Controller
    {
        private readonly NepalDataContext _context;

        public NepalDataModelsController(NepalDataContext context)
        {
            _context = context;
        }

        public IActionResult Home()
        {
          
            return View( );
        }

        // GET: NepalDataModels
        public async Task<IActionResult> Index(string SearchString, int? pageNumber, string sortOrder, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            ViewData["CurrentFilter"] = SearchString;

            var Datas = from d in _context.Test select d;

            Stopwatch sw = Stopwatch.StartNew();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                Datas = Datas.Where(d => d.Title.Contains(SearchString) || d.Paragraph.Contains(SearchString));

            }
            sw.Stop();

            ViewBag.SearchedData = Datas.Count();

            ViewBag.Time = sw.Elapsed.TotalMilliseconds;

            int pageSize = 10;
            

            return View(await PaginatedList<NepalDataModel>.CreateAsync(Datas.AsNoTracking(), pageNumber ?? 1 , pageSize));
        }


        public async Task<IActionResult> Search(string searchString, int? pageNumber, string sortOrder, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var Datas = from d in _context.Test select d;
            

            Stopwatch sw = Stopwatch.StartNew();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                Datas = Datas.Where(d => d.Title.Contains(searchString) || d.Paragraph.Contains(searchString));

            }
            sw.Stop();

            ViewBag.SearchedData = Datas.Count();

            ViewBag.Time = sw.Elapsed.TotalMilliseconds;

            int pageSize = 10;

            return View(await PaginatedList<NepalDataModel>.CreateAsync(Datas.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        //Search Deatil
        public async Task<IActionResult> SearchDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nepalDataModel = await _context.Test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nepalDataModel == null)
            {
                return NotFound();
            }

            return View(nepalDataModel);
        }

        // GET: NepalDataModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nepalDataModel = await _context.Test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nepalDataModel == null)
            {
                return NotFound();
            }

            return View(nepalDataModel);
        }

        // GET: NepalDataModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NepalDataModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Paragraph")] NepalDataModel nepalDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nepalDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nepalDataModel);
        }

        // GET: NepalDataModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nepalDataModel = await _context.Test.FindAsync(id);
            if (nepalDataModel == null)
            {
                return NotFound();
            }
            return View(nepalDataModel);
        }

        // POST: NepalDataModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Paragraph")] NepalDataModel nepalDataModel)
        {
            if (id != nepalDataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nepalDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NepalDataModelExists(nepalDataModel.Id))
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
            return View(nepalDataModel);
        }

        // GET: NepalDataModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nepalDataModel = await _context.Test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nepalDataModel == null)
            {
                return NotFound();
            }

            return View(nepalDataModel);
        }

        // POST: NepalDataModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nepalDataModel = await _context.Test.FindAsync(id);
            _context.Test.Remove(nepalDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NepalDataModelExists(int id)
        {
            return _context.Test.Any(e => e.Id == id);
        }
    }
}
