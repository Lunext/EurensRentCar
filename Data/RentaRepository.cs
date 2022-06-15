using Euren_sRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class RentaRepository: IRecordRepository<Renta>
    {
        public Renta Create(Renta t)
        {
            t.Id = null;
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(Renta t)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(t);
            db.SaveChanges();
        }
        public Renta Update(Renta t)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Renta> View(bool all = true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (all)
            {
                return db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente).ToList();

            }
            else
            {
                return db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente).Where(x => x.Estado == true).ToList();

            }
        }

    }
}
