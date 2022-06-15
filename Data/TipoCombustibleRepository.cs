using Euren_sRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class TipoCombustibleRepository:IRecordRepository<TipoCombustible>
    {
        public TipoCombustible Create(TipoCombustible tc)
        {
            tc.Id= null;

            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(tc);
            db.SaveChanges();
            return data.Entity;



        }

        public void Delete(TipoCombustible tc)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(tc);
            db.SaveChanges();
        }

        public TipoCombustible Update(TipoCombustible tc)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(tc);
            db.SaveChanges();
            return data.Entity;
        }

        public List<TipoCombustible> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            if (q)
            {
                return db.TiposCombustibles.ToList();

            }
            else
            {
                return db.TiposCombustibles.Where(x => x.Estado == true).ToList();

            }
        }
    }
}
