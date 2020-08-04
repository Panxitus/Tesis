using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeraChile.Web.Entities;
using NeraChile.Web.Helpers;
using NeraChile.Web.Models;

namespace NeraChile.Web.Controllers
{
    public class AtencionsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public AtencionsController(DataContext context,IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: Atencions
        public IActionResult Index()
        {
            return View( _context.Atencions.
                Include(a=>a.atencion));
        }

        // GET: Atencions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // GET: Atencions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atencions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(AddAtencionViewModel model)
        { 
        
            if (ModelState.IsValid)
            {

                var atencion = new Atencion
                {
                    Hora_de_llamada = model.Hora_de_llamada,
                    Fecha_de_llamada = model.Fecha_de_llamada,
                    Odometro_inicial = model.Odometro_inicial,
                    Tipo_de_servicio = model.Tipo_de_servicio,
                    Tipo_vehiculo = model.Tipo_vehiculo,
                    Hora_de_llegada = model.Hora_de_llegada, 
                    Odometro_de_llegada = model.Odometro_final,
                    Observaciones = model.Observaciones,
                    Odometro_final= model.Odometro_final,
                    Hora_termino = model.Hora_termino,
                    Estado_del_Servicio =model.Estado_del_Servicio

                };

                _context.Add(atencion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Atencions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencions.FindAsync(id);
            if (atencion == null)
            {
                return NotFound();
            }
            return View(atencion);
        }

        // POST: Atencions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> 
        Edit(int id, [Bind("Id,Hora_de_llamada,Fecha_de_llamada,Odometro_inicial,Tipo_de_servicio,Tipo_vehiculo,Hora_de_llegada,Odometro_de_llegada,Observaciones,Odometro_final,Hora_termino,Estado_del_Servicio")] Atencion atencion)
        {
            if (id != atencion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atencion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtencionExists(atencion.Id))
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
            return View(atencion);
        }

        // GET: Atencions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atencions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // POST: Atencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atencion = await _context.Atencions.FindAsync(id);
            _context.Atencions.Remove(atencion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtencionExists(int id)
        {
            return _context.Atencions.Any(e => e.Id == id);
        }
    }
}
