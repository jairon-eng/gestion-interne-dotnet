using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionInterne.Data;
using GestionInterne.Models;

namespace GestionInterne.Controllers
{
    public class AffectationsController : Controller
    {
        private readonly AppDbContext _context;

        public AffectationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Affectations
       public async Task<IActionResult> Index()
{
    var affectations = _context.Affectations
        .Include(a => a.Equipement);

    return View(await affectations.ToListAsync());
}


        // GET: Affectations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var affectation = await _context.Affectations
    .Include(a => a.Equipement)
    .FirstOrDefaultAsync(m => m.Id == id);

            if (affectation == null)
            {
                return NotFound();
            }

            return View(affectation);
        }

        // GET: Affectations/Create
        public IActionResult Create()
        {
            ViewData["EquipementId"] = new SelectList(_context.Equipements, "Id", "Nom");
            return View();
        }

        // POST: Affectations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipementId,AssigneA,Departement,DateDebut,DateFin,Statut,Commentaire")] Affectation affectation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(affectation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipementId"] = new SelectList(_context.Equipements, "Id", "Nom", affectation.EquipementId);
            return View(affectation);
        }

        // GET: Affectations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affectation = await _context.Affectations.FindAsync(id);
            if (affectation == null)
            {
                return NotFound();
            }
            ViewData["EquipementId"] = new SelectList(_context.Equipements, "Id", "Nom", affectation.EquipementId);
            return View(affectation);
        }

        // POST: Affectations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipementId,AssigneA,Departement,DateDebut,DateFin,Statut,Commentaire")] Affectation affectation)
        {
            if (id != affectation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(affectation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AffectationExists(affectation.Id))
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
            ViewData["EquipementId"] = new SelectList(_context.Equipements, "Id", "Nom", affectation.EquipementId);
            return View(affectation);
        }

        // GET: Affectations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affectation = await _context.Affectations
                .Include(a => a.Equipement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (affectation == null)
            {
                return NotFound();
            }

            return View(affectation);
        }

        // POST: Affectations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var affectation = await _context.Affectations.FindAsync(id);
            if (affectation != null)
            {
                _context.Affectations.Remove(affectation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AffectationExists(int id)
        {
            return _context.Affectations.Any(e => e.Id == id);
        }
    }
}
