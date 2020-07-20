using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Dirección { get; set; }
        public string Comuna { get; set; }
        public string  Ciudad { get; set; }
        public string telefono { get; set; }

    }
}
