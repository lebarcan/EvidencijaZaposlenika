using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvidencijaZaposlenika.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EvidencijaZaposlenika.Controllers
{
    public class ZaposleniciController : Controller
    {
        private readonly BazaKontekst _context;
        public ZaposleniciController(BazaKontekst context)
        {
            _context = context;
        }

        // GET: ZaposleniciController
        public ActionResult Index()
        {
            return View(_context.Zaposlenici.ToList());
        }

        // GET: ZaposleniciController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenik = await _context.Zaposlenici.FirstOrDefaultAsync(m => m.Id == id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            return View(zaposlenik);
        }

        // GET: ZaposleniciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZaposleniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Pozicija,Ured,Pčaća,Kontakt")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zaposlenik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zaposlenik);
        }

        // GET: ZaposleniciController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenik = await _context.Zaposlenici.FindAsync(id);
            if (zaposlenik == null)
            {
                return NotFound();
            }
            return View(zaposlenik);
        }

        // POST: ZaposleniciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Pozicija,Ured,Pčaća,Kontakt")] Zaposlenik zaposlenik)
        {
            if (id != zaposlenik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaposlenik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZaposlenikExists(zaposlenik.Id))
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
            return View(zaposlenik);
        }


        // GET: ZaposleniciController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenik = await _context.Zaposlenici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            return View(zaposlenik);
        }

        // POST: ZaposleniciController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaposlenik = await _context.Zaposlenici.FindAsync(id);
            _context.Zaposlenici.Remove(zaposlenik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZaposlenikExists(int id)
        {
            return _context.Zaposlenici.Any(e => e.Id == id);
        }
    }
}
