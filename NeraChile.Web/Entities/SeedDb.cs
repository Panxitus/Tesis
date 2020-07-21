using NeraChile.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;


        public SeedDb(DataContext context,
                       IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {

            {
                await _dataContext.Database.EnsureCreatedAsync();
                await CheckRoles();
                var manager = await CheckUserAsync
                ("15720044", "Francisco Javier", "Gonzalez", "Uribe", "Fgonzalez@gmail.com", "65380808", "Los escaños 0236", "Puente Alto", "Santiago", "Admin");
                var customer = await CheckUserAsync
                ("15720044", "Francisco Javier", "Gonzalez", "Uribe", "Fgonzalez@gmail.com", "65380808", "Los escaños 0236", "Puente Alto", "Santiago", "Customer");
                await CheckManagerAsync(manager);
                await CheckClienteAsync(customer);
                

            }
        }

        private async Task CheckClienteAsync(User user)
        {
            if (!_dataContext.Clientes.Any())
            {
                _dataContext.Clientes.Add(new Cliente { User = user });
                await _dataContext.SaveChangesAsync();
            }


        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }

        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

        }

        private async Task<User> CheckUserAsync
        (string Rut, string Nombre, string Apellido_Paterno, string Apellido_Materno,
         string email, string Direccion, string Comuna, string Ciudad, string Telefono, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Rut = Rut,
                    Nombre = Nombre,
                    Apellido_Paterno = Apellido_Paterno,
                    Apellido_Materno = Apellido_Materno,
                    Email = email,
                    UserName = email,
                    Telefono = Telefono,
                    Dirección = Direccion,
                    Comuna = Comuna,
                    Ciudad = Ciudad

                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }
    }
}
