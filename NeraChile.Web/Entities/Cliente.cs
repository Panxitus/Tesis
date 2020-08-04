using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Atencion> Atencions { get; set; }
    }
}
