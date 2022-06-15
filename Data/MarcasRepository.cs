using Euren_sRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class MarcasRepository: IRecordRepository<Marca>
    {
         public Marca Create(Marca m)
        {
            m.Id= null;

             using EurenRentCarContext db = new EurenRentCarContext();
             var data = db.Add(m);
             db.SaveChanges();
             return data.Entity; 

           
          
        }

        public void Delete(Marca m)
        {
           using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(m);
            db.SaveChanges();
        }

        public Marca Update(Marca m)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(m);
            db.SaveChanges();
            return data.Entity; 
        }

        public List<Marca> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {
                return db.Marcas.ToList();

            }
            else
            {
                return db.Marcas.Where(x => x.Estado == true).ToList();

            }
        }
    }
}
