using Euren_sRentCar.Models;
using EurenRentCar.Data;
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
    public partial class Empleados : Form
    {
        readonly Empleado empleado= new Empleado();
        readonly EmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private int clienteId;
        List<string> errores = new List<string>();

        private Empleado GetEmpleado()
        {

            empleado.Nombre=txtNombre.Text.Trim();
            empleado.Cedula=txtCedula.Text.Replace("-", "").Trim();
            empleado.FechaIngreso=dtpFechaIngreso.Value.Date;
            empleado.PorcientoComision=Convert.ToDouble(nudCreditLimit.Value);

            empleado.Tanda=cbbTipoPersona.Text;
            empleado.Estado=chBEstado.Checked;
            return empleado;
        }

        public Empleados()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            txtNombre.Text="";
            txtCedula.Text="";
            
            nudCreditLimit.Value=0;
            
            chBEstado.Checked=false;
        }
        public void LoadData()
        {
            dataGridView1.DataSource=empleadoRepository.View();


            dataGridView1.ClearSelection();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            empleado.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            empleado.Nombre=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            empleado.Cedula=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           
            empleado.PorcientoComision=Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            empleado.FechaIngreso=Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());


        

            empleado.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            empleado.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            empleado.Nombre=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            empleado.Cedula=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            empleado.PorcientoComision=Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            empleado.FechaIngreso=Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());




            empleado.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled= dataGridView1.SelectedRows.Count>0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            
            empleado.Id=null;
            if (Validar())
            {
                empleadoRepository.Create(GetEmpleado());
                LoadData();
                Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                empleadoRepository.Update(GetEmpleado());
                LoadData();
                Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var m = GetEmpleado();
                if (m!=null)
                {
                    empleadoRepository.Delete(m);
                    LoadData();
                    Clear();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                MessageBox.Show("Este cliente esta anexado con otra tabla y no puede ser borrado...");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +ex.StackTrace);
            }

        }
        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errores.Add("Nombre vacio,llenar");
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                errores.Add("Cedula Vacia, llenar");
            }
            // TODO: validar cedula
            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.Empleados.Where(x => x.Nombre == txtNombre.Text.Trim() && x.Id != empleado.Id).Any())
            {
                errores.Add("Hay un empleado con este nombre");
            }
            if (db.Empleados.Where(x => x.Cedula == txtCedula.Text.Trim() && x.Id != empleado.Id).Any())
            {
                errores.Add("Hay un empleado con esta cedula.");
            }
            if (nudCreditLimit.Value < 0)
            {
                errores.Add("Comision no puede ser negativa");
            }
            if (!validaCedula(txtCedula.Text.Replace("-", "").Trim()))
            {
                errores.Add("Cedula no valida");
            }
            if (errores.Count > 0)
            {
                var message = "";
                foreach (var e in errores)
                {
                    message += e + "\n";
                }
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool validaCedula(string pCedula)

        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
