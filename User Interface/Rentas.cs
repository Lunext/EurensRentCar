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
    public partial class Rentas : Form
    {
        Renta renta = new Renta();
        VehiculoRepository vehiculoRepository = new VehiculoRepository();
       
        ClienteRepository clienteRepository = new ClienteRepository();
        EmpleadoRepository empleadoRepository = new EmpleadoRepository();
        RentaRepository rentaRepository = new RentaRepository();
        List<string> errores = new List<string>();
        public Rentas()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadData()
        {
            cbbCliente.DataSource= clienteRepository.View(false);
            cbbVehiculo.DataSource= vehiculoRepository.View(false); 
            cbbEmpleado.DataSource= empleadoRepository.View(false);
            dataGridView1.DataSource=rentaRepository.View();
            dataGridView1.ClearSelection(); 
            
        }

         Renta GetRenta()
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            renta.EmpleadoId=((Empleado)cbbEmpleado.SelectedItem).Id;
            renta.ClienteId= ((Cliente)cbbCliente.SelectedItem).Id;
            renta.VehiculoId=((Vehiculo)cbbVehiculo.SelectedItem).Id;
            renta.FechaRenta=dtpRenta.Value;
            renta.FechaDevolucion=dtpReturn.Value;
            renta.MontoDia=Convert.ToDouble(nudMontoDia.Value);
           
            renta.Comentario=txtComentario.Text.Trim();

            return renta; 
        }
        public void Clear()
        {
            nudMontoDia.Value=0;
          
            txtComentario.Text="";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                renta.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                renta.EmpleadoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                renta.ClienteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                renta.VehiculoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                renta.FechaRenta = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                renta.FechaDevolucion = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
                renta.MontoDia = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[9].Value.ToString());
                renta.Comentario = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                renta.Estado = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[12].Value.ToString());
                renta.CantidadDias=Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[10].Value.ToString());
                renta.Devuelto = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[13].Value.ToString());
                using EurenRentCarContext db = new EurenRentCarContext();
                cbbEmpleado.SelectedItem = db.Empleados.Where(x => x.Id == renta.EmpleadoId).FirstOrDefault();
                cbbCliente.SelectedItem = db.Clientes.Where(x => x.Id == renta.ClienteId).FirstOrDefault();
                cbbVehiculo.SelectedItem = db.Vehiculos.Where(x => x.Id == renta.VehiculoId).FirstOrDefault();
                dtpRenta.Value = renta.FechaRenta;
                dtpReturn.Value = renta.FechaDevolucion;
                nudMontoDia.Value = Convert.ToDecimal(renta.MontoDia);
               
                txtComentario.Text = renta.Comentario;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnEditar.Enabled= dataGridView1.SelectedRows.Count>0;
            btnBorrar.Enabled= dataGridView1.SelectedRows.Count>0; 
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            renta.Devuelto = false;


            if (Validar())
            {
                rentaRepository.Create(GetRenta());
                LoadData();
                Clear();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                rentaRepository.Update(GetRenta());
                LoadData();
                Clear();
            }



        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var t = GetRenta();
                if (t != null)
                {
                    rentaRepository.Delete(t);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }

        }
        public bool Validar()
        {
            errores.Clear();
            GetRenta();
            if (dtpRenta.Value > dtpReturn.Value)
            {
                errores.Add("Introducir una fecha previa a la de retorno.");
            }
            if (nudMontoDia.Value < 0)
            {
                errores.Add("El monto por dia no puede ser negativo");
            }
            if (renta.Devuelto == true)
            {
                errores.Add("Los vehiculos retornados no pueden ser modificados.");
            }
            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.Rentas.Where(x => x.VehiculoId == renta.VehiculoId && x.Devuelto == false).Any())
            {
                errores.Add("El vehiculo esta siendo utilizado");
            }
            if (!db.Inspecciones.Where(x => x.Fecha.Date == renta.FechaRenta.Date && x.VehiculoId == renta.VehiculoId).Any())
            {
                errores.Add("La inspeccion es esencial antes de realizar venta.");
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

        private void Rentas_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
