using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Autopista
    {
        public int Id { get; set; }
        public int Nombre { get; set; }

        public ICollection <Rescate> Rescates { get; set; }

    }
}
