using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class User : IdentityUser

    {
        [Required]
        public string Rut { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Apellido_Paterno { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string Apellido_Materno { get; set; }
        [Required]
        public string Dirección { get; set; }
        [Required]
        public string Comuna { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}
