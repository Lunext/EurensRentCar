using Euren_sRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class TipoVehiculoRepository : IRecordRepository<TipoVehiculo>
    {
        public TipoVehiculo Create(TipoVehiculo tv)
        {
             tv.Id= null;

             using EurenRentCarContext db = new EurenRentCarContext();
             var data = db.Add(tv);
             db.SaveChanges();
             return data.Entity; 

           
          
        }

        public void Delete(TipoVehiculo tv)
        {
           using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(tv);
            db.SaveChanges();
        }

        public TipoVehiculo Update(TipoVehiculo tv)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(tv);
            db.SaveChanges();
            return data.Entity; 
        }

        public List<TipoVehiculo> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {
                return db.TiposVehiculos.ToList();

            }
            else
            {
                return db.TiposVehiculos.Where(x => x.Estado == true).ToList();

            }
            
        }
    }
}
