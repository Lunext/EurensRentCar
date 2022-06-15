
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Euren_sRentCar.Models
{
    internal class Renta
    {
        public int? Id { get; set; }
        public int? EmpleadoId { get; set; }

        [JsonConverter(typeof(ToStringJsonConverter))]
        public Empleado Empleado { get; set; }

        public int? ClienteId { get; set; }
        [JsonConverter(typeof(ToStringJsonConverter))]
        public Cliente Cliente { get; set; }
        public int? VehiculoId { get; set; }
        [JsonConverter(typeof(ToStringJsonConverter))]
        public Vehiculo Vehiculo { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public double CantidadDias { get; set; }
        public double MontoDia { get; set; }
        
        public string Comentario { get; set; }
        public bool Estado { get; set; }
        public bool Devuelto { get; set; }



    }
}
