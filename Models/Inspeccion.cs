using Euren_sRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Models
{
    internal class Inspeccion
    {
        public int? Id { get; set; }
        public int? VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }


        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }    
        public double Combustible { get; set; }
        public bool Ralladuras { get; set; }

        public bool GomaRespuesta { get; set; }

        public bool Gato { get; set; }

        public bool RoturaCristal { get; set; }

        public bool GomaIzqDelantera { get; set; }

        public bool GomaIzqTrasera { get; set; }

        public bool GomaDerDelantera { get; set; }

        public bool CheckDerTrasera { get; set; }

        public DateTime Fecha { get; set; }

        public int? EmpleadoId { get; set; }
        public Empleado? Empleado { get; set;  }

        public bool Estado { get; set;  }

    }
}
