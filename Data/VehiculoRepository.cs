using Euren_sRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class VehiculoRepository:IRecordRepository<Vehiculo>
    {
        public Vehiculo Create(Vehiculo v)
        {
            v.Id= null;
            v.Marca=null;
            v.TipoVehiculo=null;
            v.Modelo=null;
            v.TipoCombustible=null;  
            

            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(v);
            db.SaveChanges();
            return data.Entity;



        }

        public void Delete(Vehiculo v)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(v);
            db.SaveChanges();
        }

        public Vehiculo Update(Vehiculo v)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(v);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Vehiculo> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {
                return db.Vehiculos.Include(x => x.Modelo).Include(x => x.Marca).Include(x => x.TipoVehiculo).Include(x => x.TipoCombustible).ToList();

            }
            else
            {
                return db.Vehiculos.Include(x => x.Modelo).Include(x => x.Marca).Include(x => x.TipoVehiculo).Include(x => x.TipoCombustible).Where(x => x.Estado == true).ToList();

            }
            
        }

      

    }
}
