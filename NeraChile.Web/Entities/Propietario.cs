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
        public string  Celular { get; set; }
        public string Correo_Electronico { get; set; }

        public ICollection <Rescate> Rescates { get; set; }


    }
}
