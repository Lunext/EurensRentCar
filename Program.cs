using EurenRentCar.Data;
using EurenRentCar.User_Interface;

namespace EurenRentCar
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            using EurenRentCarContext db = new EurenRentCarContext();
            var u = db.Usuarios.Where(y => y.User=="admin").FirstOrDefault();
            if (u==null)
            {
                u= new Models.Usuario();
                u.User="admin";
                u.Password="admin";
                var repo = new UsuarioRepository();
                repo.Create(u);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());
        }
    }
}