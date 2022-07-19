using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Data;
using SacramentPlanner.Models;

namespace SacramentPlanner.Controllers
{
    public class SacramentPlansController : Controller
    {
        private readonly SacramentPlannerContext _context;

        public SacramentPlansController(SacramentPlannerContext context)
        {
            _context = context;
        }

        // GET: SacramentPlans
        public async Task<IActionResult> Index()
        {
            return View(await _context.SacramentPlan
                .Include(s => s.OpeningHymn)
                .Include(s => s.SacramentHymn)
                .Include(s => s.ClosingHymn)
                .ToListAsync());
        }

        // GET: SacramentPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentPlan = await _context.SacramentPlan
                .FirstOrDefaultAsync(m => m.SacramentPlanID == id);
            if (sacramentPlan == null)
            {
                return NotFound();
            }

            var speakerQuery = from s in _context.Speaker
                               where s.SacramentPlanID == sacramentPlan.SacramentPlanID
                               select s;
            ViewBag.speaker = new List<Speaker>(speakerQuery);

            return View(sacramentPlan);
        }

        // GET: SacramentPlans/Create
        public IActionResult Create()
        {
            ViewData["HymnTitle"] = new SelectList(_context.Hymn, "HymnTitle", "HymnTitle");
            return View();
        }

        [BindProperty]
        public SacramentPlan SacramentPlan { get; set; }


        [BindProperty]
        public Hymn OpeningHymn { get; set; }
        [BindProperty]
        public Hymn SacramentHymn { get; set; }
        [BindProperty]
        public Hymn ClosingHymn { get; set; }

        // POST: SacramentPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SacramentPlanID,Date,Conducting,Invocation,NumberOfSpeakers,Benediction")] SacramentPlan sacramentPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Hymn.Add(OpeningHymn);
                await _context.SaveChangesAsync();
                sacramentPlan.OpeningHymn = OpeningHymn;

                _context.Hymn.Add(SacramentHymn);
                await _context.SaveChangesAsync();
                sacramentPlan.SacramentHymn = SacramentHymn;

                _context.Hymn.Add(ClosingHymn);
                await _context.SaveChangesAsync();
                sacramentPlan.ClosingHymn = ClosingHymn;

                _context.Add(sacramentPlan);
                await _context.SaveChangesAsync();
                //await AddSpeakers(sacramentPlan.SacramentPlanID);
                ViewBag.ID = sacramentPlan.SacramentPlanID;
                ViewBag.NumberOfSpeakers = sacramentPlan.NumberOfSpeakers;
                return RedirectToAction("Index", "Speakers", new {id = sacramentPlan.SacramentPlanID});
            }
            // "~/Views/Speakers/Index.cshtml"


            return View(sacramentPlan);
        }
        // GET: SacramentPlans/AddSpeakers/5
        public async Task<IActionResult> AddSpeakers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentPlan = await _context.SacramentPlan.FindAsync(id);
            if (sacramentPlan == null)
            {
                return NotFound();
            }

            ViewBag.ID = sacramentPlan.SacramentPlanID;
            ViewBag.NumberOfSpeakers = sacramentPlan.NumberOfSpeakers;
            return View(sacramentPlan);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSpeakers()
        {
            return View();
        }

        // GET: SacramentPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentPlan = await _context.SacramentPlan.FindAsync(id);
            if (sacramentPlan == null)
            {
                return NotFound();
            }
            return View(sacramentPlan);
        }

        // POST: SacramentPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SacramentPlanID,Date,Conducting,Invocation,NumberOfSpeakers,Benediction")] SacramentPlan sacramentPlan)
        {
            if (id != sacramentPlan.SacramentPlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacramentPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentPlanExists(sacramentPlan.SacramentPlanID))
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
            return View(sacramentPlan);
        }

        // GET: SacramentPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentPlan = await _context.SacramentPlan
                .FirstOrDefaultAsync(m => m.SacramentPlanID == id);
            if (sacramentPlan == null)
            {
                return NotFound();
            }

            return View(sacramentPlan);
        }

        // POST: SacramentPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sacramentPlan = await _context.SacramentPlan.FindAsync(id);
            _context.SacramentPlan.Remove(sacramentPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentPlanExists(int id)
        {
            return _context.SacramentPlan.Any(e => e.SacramentPlanID == id);
        }
    }
}
