using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euren_sRentCar.Models
{
    internal class Modelo
    {
        public int? Id { get; set; }
        [Required ]
        public string Descripcion { get; set; }
        public int? MarcaId { get; set; }
        public Marca? Marca { get; set; }

        [Required]
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Descripcion; 
        }
    }
}
