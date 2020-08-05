using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeraChile.Web.Entities;

namespace NeraChile.Web.Entities
{
    public class DataContext : IdentityDbContext<User>
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Rescate> Atencions { get; set;}
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<TipoVehiculo> Vehiculos { get; set; }
        
    }

}



