using Euren_sRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class ClienteRepository: IRecordRepository<Cliente>
    {
        public Cliente Create(Cliente c)
        {
            c.Id= null;

            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(c);
            db.SaveChanges();
            return data.Entity;



        }

        public void Delete(Cliente c)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(c);
            db.SaveChanges();
        }

        public Cliente Update(Cliente c)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(c);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Cliente> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            return db.Clientes.ToList();
            if (q)
            {
                return db.Clientes.ToList();
            }
            else
            {
                return db.Clientes.Where(x => x.Estado == true).ToList();
            }
        }
    }
}
