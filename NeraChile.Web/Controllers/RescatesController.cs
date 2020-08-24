using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeraChile.Web.Entities;
using NeraChile.Web.Helpers;

namespace NeraChile.Web.Controllers
{
   
    public class RescatesController : Controller
    {
        private readonly DataContext _dataContext;
        

        public RescatesController(DataContext context)
        {
            _dataContext = context;
            
        }

        // GET: Rescates
        public IActionResult Index()
        {
            return View(_dataContext.Rescate
                .Include (r => r.Autopista)
                .Include (r => r.Registros));
        }

        // GET: Rescates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rescate = await _dataContext.Rescate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rescate == null)
            {
                return NotFound();
            }

            return View(rescate);
        }

        // GET: Rescates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rescates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Odometro_inicial,Tipo_de_servicio,Tipo_vehiculo,Odometro_de_llegada,Observaciones,Odometro_final,Estado_del_Servicio")] Rescate rescate)
        {
            if (ModelState.IsValid)
            {
                if(rescate.Odometro_inicial <= rescate.Odometro_de_llegada){
                    if (rescate.Odometro_de_llegada <= rescate.Odometro_final){
                        _dataContext.Add(rescate);
                        await _dataContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }else{
                           //Console.WriteLine("Odometro invalido");
                            throw new Exception();
                    }
                }else{
                       //Console.WriteLine("Odometro invalido");
                        throw new Exception();
                }
            }
            return View(rescate);
        }

        // GET: Rescates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rescate = await _dataContext.Rescate.FindAsync(id);
            if (rescate == null)
            {
                return NotFound();
            }
            return View(rescate);
        }

        // POST: Rescates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Odometro_inicial,Tipo_de_servicio,Tipo_vehiculo,Odometro_de_llegada,Observaciones,Odometro_final,Estado_del_Servicio")] Rescate rescate)
        {
            if (id != rescate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(rescate);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RescateExists(rescate.Id))
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
            return View(rescate);
        }

        // GET: Rescates/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRescate (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rescate = await _dataContext.Rescate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rescate == null)
            {
                return NotFound();
            }
            _dataContext.Rescate.Remove(rescate);
            await _dataContext.SaveChangesAsync();
            //return RedirectToAction($"{nameof(rescate)}/{rescate.Id}");
            //return null;
            return RedirectToAction("Index", "Rescates");
        }

        // POST: Rescates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        private bool RescateExists(int id)
        {
            return _dataContext.Rescate.Any(e => e.Id == id);
        }
    }
}
