using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euren_sRentCar.Models
{
    internal class Empleado
    {
       
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Tanda { get; set; }

        public double PorcientoComision { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }


        public bool Estado { get; set; }

        public override string ToString()
        {
            return Nombre; 
        }

    }
}
