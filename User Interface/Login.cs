using EurenRentCar.Data;
using EurenRentCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurenRentCar.User_Interface
{
    public partial class Login : Form
    {
        private Usuario? user = null;
        readonly UsuarioRepository userRepository = new UsuarioRepository();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using EurenRentCarContext db = new EurenRentCarContext();

            user= db.Usuarios.Where(u => u.User==txtUser.Text.Trim() && u.Password== txtPassword.Text.Trim()).FirstOrDefault();
            if (user== null)
            {
                MessageBox.Show("El usuario que es usted ha introducido es incorrecto");
            }
            else
            {
                Close();
            }


        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (user==null)
            {
                Application.Exit();
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}
