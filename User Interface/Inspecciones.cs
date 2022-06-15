using Euren_sRentCar.Models;
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
    public partial class Inspecciones : Form
    {
        VehiculoRepository vehiculoRepository = new VehiculoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        EmpleadoRepository empleadoRepository = new EmpleadoRepository();
        InspeccionRepository inspeccionRepository = new InspeccionRepository();
        readonly Inspeccion inspeccion = new Inspeccion();
        public List<string> errores = new List<string>();

        public Inspecciones()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            cbbVehiculo.DataSource = vehiculoRepository.View(true);
            cbbCliente.DataSource = clienteRepository.View(true);
            cbbEmpleado.DataSource = empleadoRepository.View(true);
            dataGridView1.DataSource = inspeccionRepository.View();
            dataGridView1.ClearSelection();
        }
         Inspeccion GetInspeccion()
        {
            inspeccion.Ralladuras = chbRalladuras.Checked;
            inspeccion.Combustible = Convert.ToDouble(cbbCombustible.Text);
            inspeccion.GomaRespuesta = chbGomaRespuesta.Checked;
            inspeccion.Gato = chbgato.Checked;
            inspeccion.RoturaCristal = chbcristalRoto.Checked;
            inspeccion.GomaIzqDelantera = chebdIzq.Checked;
            inspeccion.GomaIzqTrasera = chbtraizq.Checked;
            inspeccion.CheckDerTrasera= traderc.Checked;
            inspeccion.GomaDerDelantera = chbdDer.Checked;
            inspeccion.Fecha = fecha.Value;
            var vehiculo = (Vehiculo)cbbVehiculo.SelectedItem;
            inspeccion.VehiculoId = vehiculo.Id;
            var cliente = (Cliente)cbbCliente.SelectedItem;
            inspeccion.ClienteId = cliente.Id;
            var empleado = (Empleado)cbbEmpleado.SelectedItem;
            inspeccion.EmpleadoId = (int)empleado.Id;

            return inspeccion;
        }
        private void Clear()
        {
            chbGomaRespuesta.Checked=false;
            chebdIzq.Checked=false;
            chbtraizq.Checked=false;
            traderc.Checked=false;
            chbdDer.Checked=false; 






        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            inspeccion.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using EurenRentCarContext db = new EurenRentCarContext();
            inspeccion.VehiculoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            var vehiculo = db.Vehiculos.Where(x => x.Id == inspeccion.VehiculoId).FirstOrDefault();
            if (vehiculo != null)
            {
                inspeccion.Vehiculo = vehiculo;
            }
            else
            {
                // TODO: ERROR
            }
            inspeccion.ClienteId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            inspeccion.Combustible = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            inspeccion.Ralladuras = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            inspeccion.GomaRespuesta = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
            inspeccion.Gato = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
            inspeccion.RoturaCristal = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[9].Value.ToString());
            inspeccion.GomaIzqDelantera= Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[10].Value.ToString());
            inspeccion.GomaIzqTrasera = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[11].Value.ToString());
            inspeccion.GomaDerDelantera = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[12].Value.ToString());
            inspeccion.CheckDerTrasera = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[13].Value.ToString());
            inspeccion.Fecha = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[14].Value.ToString());
            inspeccion.EmpleadoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[15].Value.ToString());
            var empleado = db.Empleados.Where(x => x.Id == inspeccion.EmpleadoId).FirstOrDefault();
            inspeccion.Empleado = empleado;
            //inspeccion.Estado = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[16].Value.ToString());
            cbbEmpleado.Text = inspeccion.Combustible.ToString();
            chbRalladuras.Checked = inspeccion.Ralladuras;
            chbgato.Checked = inspeccion.Gato;
            chbcristalRoto.Checked = inspeccion.RoturaCristal;
            chebdIzq.Checked = inspeccion.GomaIzqDelantera;
            chbtraizq.Checked = inspeccion.GomaIzqTrasera;
            traderc.Checked = inspeccion.GomaDerDelantera;
            chbdDer.Checked = inspeccion.CheckDerTrasera;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                inspeccionRepository.Create(GetInspeccion());
                LoadData();
                Clear(); 
            }
        }

        public bool Validar()
        {
            errores.Clear();
            using EurenRentCarContext db = new EurenRentCarContext();
            if (string.IsNullOrWhiteSpace(cbbCombustible.Text.Trim()))
            {
                errores.Add("Llene el combustible .");
            }
            if (fecha.Value.Date > DateTime.Today.Date)
            {
                errores.Add("La fecha no puede ser futurista");
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

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (Validar())
            {
                inspeccionRepository.Update(GetInspeccion());
                LoadData();
                Clear();
            }





        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var t = GetInspeccion();
                if (t != null)
                {
                    inspeccionRepository.Delete(t);
                    LoadData();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                MessageBox.Show("La tabla no puede ser borrada al estar anexada con otras tablas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled = dataGridView1.SelectedRows.Count > 0;
            btnEditar.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void Inspecciones_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
