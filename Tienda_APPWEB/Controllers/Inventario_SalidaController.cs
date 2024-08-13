using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda_APPWEB.Data;
using Tienda_APPWEB.Models;

namespace Tienda_APPWEB.Controllers
{
    public class Inventario_SalidaController : Controller
    {
        private readonly Tienda_APPWEBContext _context;

        public Inventario_SalidaController(Tienda_APPWEBContext context)
        {
            _context = context;
        }

        // GET: Inventario_Salida
        public async Task<IActionResult> Index()
        {
            var salidas = await (from salida in _context.Inventario_Salida
                                 join producto in _context.Producto on salida.idProducto equals producto.idProducto
                                 select new Inventario_Salida
                                 {
                                     idInventario_Salida = salida.idInventario_Salida,
                                     NombreProducto = producto.Nombre,
                                     Fecha = salida.Fecha,
                                     Cantidad = salida.Cantidad,
                                     Activo = salida.Activo,
                                 }
                ).ToListAsync();
            return View(salidas);
        }

        // GET: Inventario_Salida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario_Salida = await _context.Inventario_Salida
                .FirstOrDefaultAsync(m => m.idInventario_Salida == id);
            if (inventario_Salida == null)
            {
                return NotFound();
            }

            return View(inventario_Salida);
        }

        // GET: Inventario_Salida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventario_Salida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idInventario_Entrada,idProducto,Cantidad,Fecha,Activo")] Inventario_Salida inventario_Salida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario_Salida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario_Salida);
        }

        // GET: Inventario_Salida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario_Salida = await _context.Inventario_Salida.FindAsync(id);
            if (inventario_Salida == null)
            {
                return NotFound();
            }
            return View(inventario_Salida);
        }

        // POST: Inventario_Salida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idInventario_Entrada,idProducto,Cantidad,Fecha,Activo")] Inventario_Salida inventario_Salida)
        {
            if (id != inventario_Salida.idInventario_Salida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario_Salida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Inventario_SalidaExists(inventario_Salida.idInventario_Salida))
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
            return View(inventario_Salida);
        }

        // GET: Inventario_Salida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario_Salida = await _context.Inventario_Salida
                .FirstOrDefaultAsync(m => m.idInventario_Salida == id);
            if (inventario_Salida == null)
            {
                return NotFound();
            }

            return View(inventario_Salida);
        }

        // POST: Inventario_Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario_Salida = await _context.Inventario_Salida.FindAsync(id);
            if (inventario_Salida != null)
            {
                _context.Inventario_Salida.Remove(inventario_Salida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Inventario_SalidaExists(int id)
        {
            return _context.Inventario_Salida.Any(e => e.idInventario_Salida == id);
        }
    }
}
