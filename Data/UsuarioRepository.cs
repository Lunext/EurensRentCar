using EurenRentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal class UsuarioRepository: IRecordRepository<Usuario>
    {
        public Usuario Create(Usuario u)
        {
            u.Id= null;

            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Add(u);
            db.SaveChanges();
            return data.Entity;



        }

        public void Delete(Usuario u)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            db.Remove(u);
            db.SaveChanges();
        }

        public Usuario Update(Usuario u)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var data = db.Update(u);
            db.SaveChanges();
            return data.Entity;
        }

        public List<Usuario> View(bool q=true)
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            return db.Usuarios.ToList();
        }

    }
}
