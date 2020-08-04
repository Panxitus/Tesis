using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Atencion
    {
        public int Id { get; set; }

        [Display (Name = "Ingrese hora de Llamada")]
        public DateTime Hora_de_llamada { get; set; }

        [Display(Name = "Ingrese fecha")]
        public DateTime Fecha_de_llamada { get; set; }

        [Display(Name = "Odometro Inicial")]
        public int Odometro_inicial { get; set; }

        [Display(Name = "Tipo de Servicio")]
        public string Tipo_de_servicio { get; set; }

        [Display(Name = "vehículo Utilizado")]
        public string Tipo_vehiculo { get; set; }

        [Display(Name = "Ingrese hora de Llegada")]
        public DateTime Hora_de_llegada { get; set; }

        [Display(Name = "Ingrese odometro ")]
        public int Odometro_de_llegada { get; set; }

        [Display(Name = "observaciones")]
        public string Observaciones { get; set; }

        [Display(Name = "Ingrese Odometro")]
        public int Odometro_final { get; set; }

        [Display(Name = "Ingrese hora de Termino")]
        public DateTime Hora_termino { get; set; }

        [Display(Name = "Ingrese Estado del Servicio")]
        public string Estado_del_Servicio { get; set; }

        public Atencion atencion { get; set; }
    }
}
