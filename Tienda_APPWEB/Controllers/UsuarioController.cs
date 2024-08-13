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
    public class UsuarioController : BaseController
    {
        private readonly Tienda_APPWEBContext _context;

        public Respuesta respuesta = new Respuesta();

        public UsuarioController(Tienda_APPWEBContext context) : base(context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUsuario,Contrasenia,Bloqueo,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUsuario,Contrasenia,Bloqueo,TipoUsuario")] Usuario usuario)
        {
            if (id != usuario.idUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.idUsuario))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.idUsuario == id);
        }

        private Usuario validarUsuario(int inputId, string inputPassword)
        {


            try
            {
                var user = _context.Usuario.SingleOrDefault(u => u.idUsuario == inputId && u.Contrasenia == inputPassword);
                return user;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al buscar usuario: {ex.Message}");
                return null;
            }
        }

        private bool usuarioExiste(int id)
        {
            return _context.Usuario.Any(e => e.idUsuario == id);
        }

        private bool usuarioBloqueado(int id)
        {
            return _context.Usuario.Any(u => u.idUsuario == id && u.Bloqueo != 0);
        }

        private void Bloquear(int id, int bloqueo)
        {
            var user = _context.Usuario.SingleOrDefault(u => u.idUsuario == id);

            if (bloqueo == 0)
            {
                user.Bloqueo = 3;
            }
            else { user.Bloqueo--; }
            _context.SaveChanges();
        }

        [HttpPost]
        public Respuesta ValidarUsuario(Login model)
        {

            try
            {
                bool centinela = usuarioExiste(model.Usuario);

                if (centinela)
                {
                    bool bloqueado = usuarioBloqueado(model.Usuario);

                    if (bloqueado)
                    {
                        Usuario userTemp = validarUsuario(model.Usuario, model.contrasenia);

                        if (userTemp != null)
                        {
                            bool primer_ingreso = _context.Usuario.Any(u => u.idUsuario == model.Usuario && u.Bloqueo == 4);
                            if (primer_ingreso)
                            {
                                Bloquear(model.Usuario, 1);
                                HttpContext.Session.SetInt32("idUsuario", userTemp.idUsuario);
                                HttpContext.Session.SetInt32("TipoUsuario", userTemp.TipoUsuario);
                                respuesta.codigo = 2;
                            }
                            else
                            {
                                Bloquear(model.Usuario, 0);
                                HttpContext.Session.SetInt32("idUsuario", userTemp.idUsuario);
                                HttpContext.Session.SetInt32("TipoUsuario", userTemp.TipoUsuario);
                                respuesta.codigo = 1;
                            }
                            return respuesta;
                        }
                        else
                        {
                            Bloquear(model.Usuario, 1);
                            respuesta.codigo = -1;
                            respuesta.mensaje = "La contraseña es incorrecta";
                            return respuesta;
                        }
                    }
                    else
                    {
                        respuesta.codigo = -1;
                        respuesta.mensaje = "El usuario ha sido bloqueado";
                        return respuesta;
                    }

                }
                else
                {
                    respuesta.codigo = -1;
                    respuesta.mensaje = "El usuario no existe";
                    return respuesta;
                }
            }

            catch (Exception ex)
            {


                return respuesta;
            }
        }


        public async Task<IActionResult> SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
