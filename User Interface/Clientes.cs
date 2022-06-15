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
    public partial class Clientes : Form
    {
        readonly Cliente cliente = new Cliente();
        readonly ClienteRepository clienteRepository = new ClienteRepository();
        private int clienteId; 
        List<string> errores = new List<string>();


        public Clientes()
        {
            InitializeComponent();
        }
        private Cliente GetCliente()
        {
            
            cliente.Nombre=txtNombre.Text.Trim();
            cliente.Cedula=txtCedula.Text.Replace("-", "").Trim();
            cliente.NoTarjetaCredito=txtTarjetaCredito.Text.Trim();
            cliente.LimiteCredito=Convert.ToDouble(nudCreditLimit.Value);
            
            cliente.TipoPersona=cbbTipoPersona.Text;
            cliente.Estado=chBEstado.Checked;
            return cliente;
        }

        private void Clear()
        {
            txtNombre.Text="";
            txtCedula.Text="";
            txtTarjetaCredito.Text="";
            nudCreditLimit.Value=0;
           
            chBEstado.Checked=false;
        }
        public void LoadData()
        {
            dataGridView1.DataSource=clienteRepository.View();
            

            dataGridView1.ClearSelection();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled= dataGridView1.SelectedRows.Count>0;
           // btnEditar.Enabled=dataGridView1.SelectedRows.Count>0;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cliente.Nombre=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cliente.Cedula=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cliente.NoTarjetaCredito=dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cliente.LimiteCredito=Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());


          
           // cbbTipoPersona.Text=cliente.TipoPersona;

            cliente.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            cliente.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cliente.Nombre=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cliente.Cedula=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cliente.NoTarjetaCredito=dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cliente.LimiteCredito=Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            


          


           // cbbTipoPersona.Text=cliente.TipoPersona;

            cliente.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cliente.Id=null;

            if (Validar())
            {

               
                clienteRepository.Create(GetCliente());
                LoadData();
                Clear();
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                clienteRepository.Update(GetCliente());
                LoadData();
                Clear();
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var m = GetCliente();
                if (m!=null)
                {
                    clienteRepository.Delete(m);
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


        private void Clientes_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }
        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errores.Add("El nombre esta vacio");
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                errores.Add("La cedula esta vacia");
            }
            if (string.IsNullOrWhiteSpace(txtTarjetaCredito.Text))
            {
                errores.Add("La tarjeta de credito esta vacia");
            }
            if (nudCreditLimit.Value < 0)
            {
                errores.Add("El limite de credito no puede ser negativo...");
            }
            if (string.IsNullOrWhiteSpace(cbbTipoPersona.Text))
            {
                errores.Add("Llenar tipo de persona");
            }
            if (cbbTipoPersona.Text == "Fisica")
            {
                if (!validaCedula(txtCedula.Text.Replace("-", "").Trim()))
                {
                    errores.Add("Cedula no aceptada");
                }

            }
            else if (cbbTipoPersona.Text == "Juridica")
            {
              /*  if (!esUnRNCValido(cbbTipoPersona.Text.Trim()))
                {
                    errores.Add("RNC no incorrecto");
                }*/
            }
            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.Empleados.Where(x => x.Nombre == txtNombre.Text.Trim() && x.Id != cliente.Id).Any())
            {
                errores.Add("Este cliente ya ha sido registrado");
            }
            if (db.Empleados.Where(x => x.Cedula == txtCedula.Text.Replace("-", "").Trim() && x.Id != cliente.Id).Any())
            {
                errores.Add("Uno de los clientes posee esta cedula.");
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
        private bool esUnRNCValido(string pRNC)

        {

            int vnTotal = 0;

            int[] digitoMult = new int[8] { 7, 9, 8, 6, 5, 4, 3, 2 };

            string vcRNC = pRNC.Replace("-", "").Replace(" ", "");

            string vDigito = vcRNC.Substring(8, 1);

            if (vcRNC.Length.Equals(9))

                if (!"145".Contains(vcRNC.Substring(0, 1)))

                    return false;

            for (int vDig = 1; vDig <= 8; vDig++)

            {

                int vCalculo = Int32.Parse(vcRNC.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];

                vnTotal += vCalculo;

            }

            if (vnTotal % 11 == 0 && vDigito == "1" || vnTotal % 11 == 1 && vDigito == "1" ||

                (11 - (vnTotal % 11)).Equals(vDigito))

                return true;

            else

                return false;

        }
    }
}
