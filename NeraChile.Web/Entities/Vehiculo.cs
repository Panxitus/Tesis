using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Cliente  { get; set; }
        public string Patente  { get; set; }
        public string  Marca { get; set; }
        public string  color { get; set; }

        public Vehiculo vehiculo { get; set; }

    }
}
