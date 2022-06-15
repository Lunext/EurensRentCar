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
    public partial class Menu : Form
    {
        private Form _formularioReciente;
        public Form FormularioReciente
        {
            get => _formularioReciente; set
            {
                if (_formularioReciente is not null) _formularioReciente.Hide();
                _formularioReciente=value;
                _formularioReciente.Show();
            }
        }
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            var lo = new Login();
            lo.ShowDialog();
        }


        private void OpenChildForm(Form childForm)
        {
            childForm.TopLevel= false;
            Controls.Add(childForm);
            childForm.FormBorderStyle=System.Windows.Forms.FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            childForm.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new TiposVehiculos();
            OpenChildForm(f);
            f.Show();


        }

        private void marcas_Click(object sender, EventArgs e)
        {
            var m = new Marcas();
            OpenChildForm(m);
            m.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tc = new TiposCombustibles();
            OpenChildForm(tc);
            tc.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var m = new Modelos();
            OpenChildForm(m);
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var c = new Clientes();
            OpenChildForm(c);
            c.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var i = new Empleados();
            OpenChildForm(i);
            i.Show(); 

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var v = new Vehiculos();
            OpenChildForm(v);
            v.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = new Rentas();
            OpenChildForm(r);
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var i = new Inspecciones();
            OpenChildForm(i);
            i.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var er = new Reportes();
            OpenChildForm(er);
            er.Show();
        }
    }
}
