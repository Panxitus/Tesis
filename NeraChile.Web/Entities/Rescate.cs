
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeraChile.Web.Entities
{
    public class Rescate
    {
        public int Id { get; set; }

        [Display (Name = "Ingrese Fecha y Hora de Solicitud")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Odometro Inicial")]
        public int Odometro_inicial { get; set; }

        [Display(Name = "Tipo de Servicio")]
        public string Tipo_de_servicio { get; set; }

        [Display(Name = "vehículo Utilizado")]
        public string Tipo_vehiculo { get; set; }

        [Display(Name = "Odometro salida atención ")]
        public int Odometro_de_llegada { get; set; }

        public string Observaciones { get; set; }

        [Display(Name = "Odometro llegada base")]
        public int Odometro_final { get; set; }

        [Display(Name = "Ingrese Estado del Servicio")]
        public string Estado_del_Servicio { get; set; }

        public Autopista Autopista { get; set; }

        public Propietario Propietario { get; set; }

        public TipoVehiculo TipoVehiculo { get; set; }

        public ICollection <Registro> Registros { get; set; }

        [Display(Name = "hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datelocal => Date.ToLocalTime();

    }
}
