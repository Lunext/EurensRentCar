using Euren_sRentCar.Models;
using EurenRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class EurenRentCarContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<TipoVehiculo> TiposVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<TipoCombustible> TiposCombustibles { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Inspeccion> Inspecciones { get; set; }

        public DbSet<Renta> Rentas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=DESKTOP-4A9TF99;Initial Catalog=RentCarDB;Integrated Security=True");
        }
    }
}
