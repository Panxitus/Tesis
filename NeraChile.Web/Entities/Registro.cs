using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Registro
    {
        public int Id { get; set; }

        public string  Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public string  Comentario { get; set; }

        public Rescate Rescate { get; set; }
    }
}
