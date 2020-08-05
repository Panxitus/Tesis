using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class TipoVehiculo
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Nombre { get; set; }
        public TipoVehiculo vehiculo { get; set; }

        public ICollection<Rescate> Rescates { get; set; }
    }
}
