using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euren_sRentCar.Models
{
  
    
    internal class Cliente
    {
        public int? Id { get; set; } 
        public string Nombre{ get; set; }

        public string Cedula { get; set; }

        public string NoTarjetaCredito { get; set; }

        public double LimiteCredito { get; set;}

        public string TipoPersona { get; set; }

        [Required]
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }



    }
}
