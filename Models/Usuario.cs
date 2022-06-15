using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Models
{
    internal class Usuario
    {
        public int? Id { get; set; } 
        public string User { get; set; }

        [Required]
        public string Password { get; set; }

        public override string ToString()
        {
            return User;
        }
    }
}
