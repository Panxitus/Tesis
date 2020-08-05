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
using NeraChile.Web.Models;

namespace NeraChile.Web.Controllers
{
    [Authorize (Roles ="Admin")]
    public class ClientesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public ClientesController(DataContext dataContext, IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View (_dataContext.Clientes
                      .Include(c => c.User));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _dataContext.Clientes
                .Include(c => c.User)
                .Include(c => c.Rescates)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Rut = model.Rut,
                    Nombre = model.Nombre,
                    Apellido_Paterno = model.Apellido_Paterno,
                    Apellido_Materno = model.Apellido_Materno,
                    Dirección = model.Direccion,
                    Ciudad = model.Ciudad,
                    Comuna = model.Comuna,
                    Telefono = model.Telefono,
                    UserName = model.Username,
                    Email = model.Username


                };
                var response = await _userHelper.AddUserAsync(user, model.Password);
                if (response.Succeeded)
                {
                var userInDb = await _userHelper.GetUserByEmailAsync(model.Username);
                await _userHelper.AddUserToRoleAsync(userInDb, "Customer");

                    var cliente = new Cliente
                    {
                        
                        User = userInDb
                        
                    };

                    _dataContext.Clientes.Add(cliente);
                    try
                    {
                        await _dataContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError(string.Empty, ex.ToString());
                        return View(model);
                    }
                
                }
                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        // GET: Clientes/Edit/5
        public async Task <IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var Cliente = await _dataContext.Clientes
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == Id.Value);
            if (Cliente == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Id = Cliente.Id, 
                Rut= Cliente.User.Rut,
                Nombre = Cliente.User.Nombre,
                Apellido_Paterno = Cliente.User.Apellido_Paterno,
                Apellido_Materno = Cliente. User.Apellido_Materno,
                Direccion = Cliente.User.Dirección,
                Comuna = Cliente.User.Comuna,
                Ciudad = Cliente.User.Ciudad,
                Telefono= Cliente.User.Telefono,
                
            };

            return View(model);

        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(EditUserViewModel model)
        {
            {
                if (ModelState.IsValid)
                {
                    var cliente = await _dataContext.Clientes
                        .Include(o => o.User)
                        .FirstOrDefaultAsync(o => o.Id == model.Id);

                   
                    cliente.User.Rut = model.Rut;
                    cliente.User.Nombre = model.Nombre;
                    cliente.User.Apellido_Paterno = model.Apellido_Paterno;
                    cliente.User.Apellido_Materno = model.Apellido_Materno;
                    cliente.User.Dirección = model.Direccion;
                    cliente.User.Comuna = model.Comuna;
                    cliente.User.Ciudad = model.Ciudad;
                    cliente.User.Telefono = model.Telefono;


                    await _userHelper.UpdateUserAsync(cliente.User);
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }

        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _dataContext.Clientes
                .Include(o =>o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }


            await _userHelper.DeleteUserAsync(cliente.User.Email);

            _dataContext.Clientes.Remove(cliente);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       

        private bool ClienteExists(int id)
        {
            return _dataContext.Clientes.Any(e => e.Id == id);
        }
    }
}
