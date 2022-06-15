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
    public partial class TiposVehiculos : Form
    {
        readonly TipoVehiculo tipoVehiculo= new TipoVehiculo();
        readonly TipoVehiculoRepository tipoVehiculoRepository = new TipoVehiculoRepository();
        List<string> errores = new List<string>();
        public TiposVehiculos()
        {
            InitializeComponent();
        }
        private TipoVehiculo GetTipoVehiculo()
        {
            tipoVehiculo.Descripcion=txtDescripcion.Text.Trim();
            tipoVehiculo.Estado=chBEstado.Checked;
            return tipoVehiculo; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tipoVehiculo.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tipoVehiculo.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tipoVehiculo.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtDescripcion.Text=tipoVehiculo.Descripcion;
            chBEstado.Checked=tipoVehiculo.Estado;

            

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled=dataGridView1.SelectedRows.Count>0;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tipoVehiculo.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tipoVehiculo.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tipoVehiculo.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtDescripcion.Text=tipoVehiculo.Descripcion;
            chBEstado.Checked=tipoVehiculo.Estado;



        }
        private void Clear()
        {
            txtDescripcion.Text="";
            chBEstado.Checked=false; 
        }
        public void LoadData()
        {
            dataGridView1.DataSource=tipoVehiculoRepository.View();
            dataGridView1.ClearSelection(); 
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            tipoVehiculo.Id=null;
            if (Validar())
            {
                tipoVehiculoRepository.Create(GetTipoVehiculo());
                LoadData();
                Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            /* if (tipoVehiculo==null)
             {
                 return; 
             }*/
            if (Validar())
            {
                tipoVehiculoRepository.Update(GetTipoVehiculo());
                LoadData();
                Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var tv = GetTipoVehiculo();
                if (tv!=null)
                {
                    tipoVehiculoRepository.Delete(tv);
                    LoadData();
                    Clear(); 
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errores.Add("Llenar la descripcion");
            }
            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.TiposVehiculos.Where(x => x.Descripcion == txtDescripcion.Text.Trim() && x.Id != tipoVehiculo.Id).Any())
            {
                errores.Add("Tipo de vehiculo ya existente...");
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

        private void TiposVehiculos_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }
    }
}
