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
    public class Inventario_EntradaController : Controller
    {
        private readonly Tienda_APPWEBContext _context;

        public Inventario_EntradaController(Tienda_APPWEBContext context)
        {
            _context = context;
        }

        // GET: Inventario_Entrada
        public async Task<IActionResult> Index()
        {
            var entradas = await (from Entradas in _context.Inventario_Entrada
                                  join producto in _context.Producto on Entradas.idProducto equals producto.idProducto
                                  select new Inventario_Entrada { 
                                            idInventario_Entrada = Entradas.idInventario_Entrada,
                                            idProducto = Entradas.idProducto,
                                            NombreProducto = producto.Nombre,
                                            Cantidad = Entradas.Cantidad,
                                            Fecha = Entradas.Fecha.Date,

                                  }).ToListAsync();
            return View(entradas);
        }

        // GET: Inventario_Entrada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario_Entrada = await _context.Inventario_Entrada
                .FirstOrDefaultAsync(m => m.idInventario_Entrada == id);
            if (inventario_Entrada == null)
            {
                return NotFound();
            }

            return View(inventario_Entrada);
        }

        // GET: Inventario_Entrada/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventario_Entrada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idInventario_Entrada,idProducto,Cantidad,Fecha,Activo")] Inventario_Entrada inventario_Entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario_Entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario_Entrada);
        }

        // GET: Inventario_Entrada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario_Entrada = await _context.Inventario_Entrada.FindAsync(id);
            if (inventario_Entrada == null)
            {
                return NotFound();
            }
            return View(inventario_Entrada);
        }

        // POST: Inventario_Entrada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idInventario_Entrada,idProducto,Cantidad,Fecha,Activo")] Inventario_Entrada inventario_Entrada)
        {
            if (id != inventario_Entrada.idInventario_Entrada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario_Entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Inventario_EntradaExists(inventario_Entrada.idInventario_Entrada))
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
            return View(inventario_Entrada);
        }

        // GET: Inventario_Entrada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario_Entrada = await _context.Inventario_Entrada
                .FirstOrDefaultAsync(m => m.idInventario_Entrada == id);
            if (inventario_Entrada == null)
            {
                return NotFound();
            }

            return View(inventario_Entrada);
        }

        // POST: Inventario_Entrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario_Entrada = await _context.Inventario_Entrada.FindAsync(id);
            if (inventario_Entrada != null)
            {
                _context.Inventario_Entrada.Remove(inventario_Entrada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Inventario_EntradaExists(int id)
        {
            return _context.Inventario_Entrada.Any(e => e.idInventario_Entrada == id);
        }
    }
}
