using Euren_sRentCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class ModeloRepository: IRecordRepository<Modelo>
    {
        public Modelo Create(Modelo m)
        {
            m.Id= null;
            m.Marca=null; 

            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(m);
            db.SaveChanges();
            return data.Entity;



        }

        public void Delete(Modelo m)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(m);
            db.SaveChanges();
        }

        public Modelo Update(Modelo m)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(m);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Modelo> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {
                return db.Modelos.Include(m => m.Marca).ToList();
            }
            else
            {
                return db.Modelos.Include(m => m.Marca).Where(x => x.Estado == true).ToList();
            }
        }

        public List<Modelo> View(Marca marca, bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {

                return db.Modelos.Include(m => m.Marca).ToList();
            }
            else
            {

                return db.Modelos.Where(x => x.MarcaId == marca.Id).Include(m => m.Marca).ToList();
            }
        }
    }
}
