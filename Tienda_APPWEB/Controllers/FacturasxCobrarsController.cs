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
    public class FacturasxCobrarsController : BaseController
    {
        private readonly Tienda_APPWEBContext _context;

        public FacturasxCobrarsController(Tienda_APPWEBContext context) : base(context)
        {
            _context = context;
        }

        // GET: FacturasxCobrars
        public async Task<IActionResult> Index()
        {
            var facturasx = await (from facturas in _context.FacturasxCobrar
                                   join cliente in _context.Cliente on facturas.idCliente equals cliente.idCliente
                                   select new FacturasxCobrar
                                   {
                                       idFacturasxCobrar = facturas.idFacturasxCobrar,
                                       ClienteNombre = cliente.Nombre,
                                       Total = facturas.Total,
                                       Cancelada = facturas.Cancelada,
                                       Activo = facturas.Activo,
                                   }
                                   ).ToListAsync();
            return View(facturasx);
        }

        // GET: FacturasxCobrars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturasxCobrar = await _context.FacturasxCobrar
                .FirstOrDefaultAsync(m => m.idFacturasxCobrar == id);
            if (facturasxCobrar == null)
            {
                return NotFound();
            }

            return View(facturasxCobrar);
        }

        // GET: FacturasxCobrars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacturasxCobrars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFacturasxCobrar,idFactura,idCliente,Total,Cancelada,Activo")] FacturasxCobrar facturasxCobrar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturasxCobrar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturasxCobrar);
        }

        // GET: FacturasxCobrars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturasxCobrar = await _context.FacturasxCobrar.FindAsync(id);
            if (facturasxCobrar == null)
            {
                return NotFound();
            }
            return View(facturasxCobrar);
        }

        // POST: FacturasxCobrars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFacturasxCobrar,idFactura,idCliente,Total,Cancelada,Activo")] FacturasxCobrar facturasxCobrar)
        {
            if (id != facturasxCobrar.idFacturasxCobrar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturasxCobrar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturasxCobrarExists(facturasxCobrar.idFacturasxCobrar))
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
            return View(facturasxCobrar);
        }

        // GET: FacturasxCobrars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturasxCobrar = await _context.FacturasxCobrar
                .FirstOrDefaultAsync(m => m.idFacturasxCobrar == id);
            if (facturasxCobrar == null)
            {
                return NotFound();
            }

            return View(facturasxCobrar);
        }

        // POST: FacturasxCobrars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturasxCobrar = await _context.FacturasxCobrar.FindAsync(id);
            if (facturasxCobrar != null)
            {
                _context.FacturasxCobrar.Remove(facturasxCobrar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturasxCobrarExists(int id)
        {
            return _context.FacturasxCobrar.Any(e => e.idFacturasxCobrar == id);
        }
    }
}
