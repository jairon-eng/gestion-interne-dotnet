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
    public class EquipementsController : Controller
    {
        private readonly AppDbContext _context;

        public EquipementsController(AppDbContext context)
        {
            _context = context;
        }

        private void PopulateStatutDropDown(string? selected = null)
        {
            ViewData["Statut"] = new SelectList(new[]
            {
        "Disponible",
        "Assigné",
        "En réparation"
    }, selected ?? "Disponible");
        }


        // GET: Equipements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipements.ToListAsync());
        }

        // GET: Equipements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipement = await _context.Equipements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipement == null)
            {
                return NotFound();
            }

            return View(equipement);
        }

        // GET: Equipements/Create
        public IActionResult Create()
        {
            PopulateStatutDropDown();
            return View();
        }


        // POST: Equipements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Type,NumSerie,Statut,DateAchat")] Equipement equipement)
        {
            if (ModelState.IsValid)
            {

                _context.Add(equipement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateStatutDropDown(equipement.Statut);
            return View(equipement);
        }

        // GET: Equipements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipement = await _context.Equipements.FindAsync(id);
            if (equipement == null)
            {
                return NotFound();
            }
            PopulateStatutDropDown(equipement.Statut);
            return View(equipement);
        }

        // POST: Equipements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Type,NumSerie,Statut,DateAchat")] Equipement equipement)
        {
            if (id != equipement.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                PopulateStatutDropDown(equipement.Statut);
                return View(equipement);
            }

            var existing = await _context.Equipements.FindAsync(id);
            if (existing == null)
                return NotFound();

            // Actualiza campos uno por uno (robusto)
            existing.Nom = equipement.Nom;
            existing.Type = equipement.Type;
            existing.NumSerie = equipement.NumSerie;
            existing.Statut = equipement.Statut;
            existing.DateAchat = equipement.DateAchat; // <-- aquí queda la fecha

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Equipements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipement = await _context.Equipements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipement == null)
            {
                return NotFound();
            }

            return View(equipement);
        }

        // POST: Equipements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipement = await _context.Equipements.FindAsync(id);
            if (equipement != null)
            {
                _context.Equipements.Remove(equipement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipementExists(int id)
        {
            return _context.Equipements.Any(e => e.Id == id);
        }
    }

}
