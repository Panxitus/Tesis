using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Propietario
    {
        public int Id { get; set; }
        public string  Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Dirección { get; set; }
        public string Comuna { get; set; }
        public string Ciudad { get; set; }
        public string  Celular { get; set; }
        public string Correo_Electronico { get; set; }
        public Propietario propietario   { get; set; }
        public ICollection <Vehiculo> Vehiculos { get; set; }

    }
}
