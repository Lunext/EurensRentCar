using Euren_sRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class EmpleadoRepository: IRecordRepository<Empleado>
    {
        public Empleado Create(Empleado e)
        {
            e.Id= null;

            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(e);
            db.SaveChanges();
            return data.Entity;



        }

        public void Delete(Empleado e)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(e);
            db.SaveChanges();
        }

        public Empleado Update(Empleado e)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(e);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Empleado> View(bool q= true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {
                return db.Empleados.ToList();

            }
            else
            {
                return db.Empleados.Where(x => x.Estado == true).ToList();

            }
           
        }
    }
}
