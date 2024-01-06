using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LuuTienDat_174.Data;
using LuuTienDat_174.Models;

namespace LuuTienDat_174.Controllers
{
    public class SinhVienHumgController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SinhVienHumgController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SinhVienHumg
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SinhVienHumg.Include(s => s.SinhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SinhVienHumg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienHumg = await _context.SinhVienHumg
                .Include(s => s.SinhVien)
                .FirstOrDefaultAsync(m => m.SoThuTu == id);
            if (sinhVienHumg == null)
            {
                return NotFound();
            }

            return View(sinhVienHumg);
        }

        // GET: SinhVienHumg/Create
        public IActionResult Create()
        {
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien");
            return View();
        }

        // POST: SinhVienHumg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoThuTu,MaSinhVien,TenSinhVien")] SinhVienHumg sinhVienHumg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVienHumg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien", sinhVienHumg.MaSinhVien);
            return View(sinhVienHumg);
        }

        // GET: SinhVienHumg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienHumg = await _context.SinhVienHumg.FindAsync(id);
            if (sinhVienHumg == null)
            {
                return NotFound();
            }
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien", sinhVienHumg.MaSinhVien);
            return View(sinhVienHumg);
        }

        // POST: SinhVienHumg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoThuTu,MaSinhVien,TenSinhVien")] SinhVienHumg sinhVienHumg)
        {
            if (id != sinhVienHumg.SoThuTu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVienHumg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienHumgExists(sinhVienHumg.SoThuTu))
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
            ViewData["MaSinhVien"] = new SelectList(_context.SinhVien, "MaSinhVien", "MaSinhVien", sinhVienHumg.MaSinhVien);
            return View(sinhVienHumg);
        }

        // GET: SinhVienHumg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVienHumg = await _context.SinhVienHumg
                .Include(s => s.SinhVien)
                .FirstOrDefaultAsync(m => m.SoThuTu == id);
            if (sinhVienHumg == null)
            {
                return NotFound();
            }

            return View(sinhVienHumg);
        }

        // POST: SinhVienHumg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinhVienHumg = await _context.SinhVienHumg.FindAsync(id);
            if (sinhVienHumg != null)
            {
                _context.SinhVienHumg.Remove(sinhVienHumg);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienHumgExists(int id)
        {
            return _context.SinhVienHumg.Any(e => e.SoThuTu == id);
        }
    }
}
