using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [StringLength(11, MinimumLength = 10, ErrorMessage = "El Rut no es valido.")]
        [Required(ErrorMessage = "El Rut es obligatorio.")]
        public string Rut { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "El Apellido Paterno es obligatorio.")]
        [Display(Name = "Apellido Paterno")]
        public string Apellido_Paterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El Apellido Materno es obligatorio.")]
        public string Apellido_Materno { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El Apellido Materno es obligatorio.")]
        public string Direccion { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Comuna")]
        public string Comuna { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

    }
}
