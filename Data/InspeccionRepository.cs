using EurenRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class InspeccionRepository:IRecordRepository<Inspeccion>
    {
        public Inspeccion Create(Inspeccion t)
        {
            t.Id = null;
            t.Empleado = null;
            t.Cliente = null;
            t.Vehiculo = null;
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(t);
            db.SaveChanges();
            return data.Entity;
        }

        public void Delete(Inspeccion t)
        {
            using EurenRentCarContext db = new EurenRentCarContext();

            db.Remove(t);
            db.SaveChanges();
        }
        public Inspeccion Update(Inspeccion t)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(t);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Inspeccion> View(bool all = true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (all)
            {
                return db.Inspecciones.Include(x => x.Vehiculo).Include(x => x.Cliente).Include(x => x.Empleado).ToList();

            }
            else
            {
                return db.Inspecciones.Include(x => x.Vehiculo).Include(x => x.Cliente).Include(x => x.Empleado).Where(x => x.Estado == true).ToList();
            }
        }
    }
}
