using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euren_sRentCar.Models
{
    internal class Vehiculo
    {
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public string NoChasis { get; set;}

        public string NoMotor { get; set; } 

        public string NoPlaca { get; set; } 

        public int? TipoVehiculoId { get; set; }

        public TipoVehiculo? TipoVehiculo { get; set; }

        public int?  MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public int? ModeloId { get; set; }

        public Modelo? Modelo { get; set; }

        public int? TipoCombustibleId { get; set; }
        public TipoCombustible? TipoCombustible { get; set; }

        [Required]
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Descripcion; 
        }
    }
}
