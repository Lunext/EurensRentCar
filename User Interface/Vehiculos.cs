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
    public partial class Vehiculos : Form
    {
        readonly Vehiculo vehiculo = new Vehiculo();
        readonly VehiculoRepository vehiculoRepository = new VehiculoRepository();
        readonly MarcasRepository marcasRepository = new MarcasRepository();
        readonly TipoCombustibleRepository tipoCombRepository = new TipoCombustibleRepository();
        readonly TipoVehiculoRepository tipovehiRepository = new TipoVehiculoRepository();
        readonly ModeloRepository modelosRepository = new ModeloRepository();
        List<string> errores = new List<string>();
        public Vehiculos()
        {
            InitializeComponent();
        }
        private Vehiculo GetVehiculo()
        {
            vehiculo.Descripcion=txtDescripcion.Text.Trim();
            vehiculo.NoMotor=txtNMotor.Text.Trim();
            vehiculo.NoPlaca=txtPlaca.Text.Trim();
            vehiculo.NoChasis=txtChasis.Text.Trim();
            vehiculo.Estado=chBEstado.Checked;
            using EurenRentCarContext db = new EurenRentCarContext();
            var marca = db.Marcas.Where(y => y.Descripcion==cbbMarcas.Text).FirstOrDefault();
            if (marca!=null)
            {
                vehiculo.MarcaId=marca.Id;
                vehiculo.Marca=marca;
            }
            else
            {
                vehiculo.MarcaId=null;
                vehiculo.Marca=null;
            }
            var modelo = db.Modelos.Where(y => y.Descripcion==cbbModelos.Text).FirstOrDefault();
            if (modelo!=null)
            {
                vehiculo.ModeloId=modelo.Id;
                vehiculo.Modelo=modelo;
            }
            else
            {
                vehiculo.ModeloId=null;
                vehiculo.Modelo=null;
            }
            var tipoVehi = db.TiposVehiculos.Where(y => y.Descripcion==cbbTipoVeh.Text).FirstOrDefault();
            if (tipoVehi!=null)
            {
                vehiculo.TipoVehiculoId=tipoVehi.Id;
                vehiculo.TipoVehiculo=tipoVehi;
            }
            else
            {
                vehiculo.TipoVehiculoId=null;
                vehiculo.TipoVehiculo=null;

               

            }
            var tipoComb = db.TiposCombustibles.Where(y => y.Descripcion==cbbTipoComb.Text).FirstOrDefault();
            if (tipoComb!=null)
            {
                vehiculo.TipoCombustibleId=tipoComb.Id;
                vehiculo.TipoCombustible=tipoComb;
            }
            else
            {
                vehiculo.TipoCombustibleId=null;
                vehiculo.TipoCombustible=null;



            }
            return vehiculo;
        }
         public void LoadData()
        {
            dataGridView1.DataSource=vehiculoRepository.View();
            cbbMarcas.DataSource=marcasRepository.View();
            cbbModelos.DataSource=modelosRepository.View();
            cbbTipoVeh.DataSource=tipovehiRepository.View(); 
            cbbTipoComb.DataSource=tipoCombRepository.View();
            
            dataGridView1.ClearSelection();
        }
        
        private void Clear()
        {
            txtDescripcion.Text="";
            txtChasis.Text="";
            txtNMotor.Text="";
            txtPlaca.Text="";
            chBEstado.Checked=false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vehiculo.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            vehiculo.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            vehiculo.NoChasis=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            vehiculo.NoPlaca=dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            vehiculo.NoMotor=dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
          
            using EurenRentCarContext db = new EurenRentCarContext();
            var marca = db.Marcas.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())).FirstOrDefault();


            if (marca!=null)
            {
                vehiculo.MarcaId=marca.Id;
                vehiculo.Marca=marca;
            }
            else
            {
                vehiculo.MarcaId=null;
                vehiculo.Marca=null;
            }

            var modelo = db.Modelos.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[9].Value.ToString())).FirstOrDefault();
            if (modelo!=null)
            {
                vehiculo.ModeloId=modelo.Id;
                vehiculo.Modelo=modelo;
            }
            else
            {
                vehiculo.ModeloId=null;
                vehiculo.Modelo=null;
            }

            var tipoComb = db.TiposCombustibles.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[11].Value.ToString())).FirstOrDefault();
            if (tipoComb!=null)
            {
                vehiculo.TipoCombustibleId=tipoComb.Id;
                vehiculo.TipoCombustible=tipoComb;
            }
            else
            {
                vehiculo.TipoCombustibleId=null;
                vehiculo.TipoCombustible=null;

            }
            var tipoVehi = db.TiposVehiculos.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())).FirstOrDefault();
            if (tipoVehi!=null)
            {
                vehiculo.TipoVehiculoId=tipoVehi.Id;
                vehiculo.TipoVehiculo=tipoVehi;
            }
            else
            {
                vehiculo.TipoVehiculoId=null;
                vehiculo.TipoVehiculo=null;



            }

            vehiculo.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[13].Value.ToString());
            txtDescripcion.Text=vehiculo.Descripcion;
            txtChasis.Text=vehiculo.NoChasis;
            txtNMotor.Text=vehiculo.NoMotor;
            txtPlaca.Text=vehiculo.NoPlaca; 
            
            chBEstado.Checked=vehiculo.Estado;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            vehiculo.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            vehiculo.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            vehiculo.NoChasis=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            vehiculo.NoPlaca=dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            vehiculo.NoMotor=dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            using EurenRentCarContext db = new EurenRentCarContext();
            var marca = db.Marcas.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())).FirstOrDefault();


            if (marca!=null)
            {
                vehiculo.MarcaId=marca.Id;
                vehiculo.Marca=marca;
            }
            else
            {
                vehiculo.MarcaId=null;
                vehiculo.Marca=null;
            }

            var modelo = db.Modelos.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[9].Value.ToString())).FirstOrDefault();
            if (modelo!=null)
            {
                vehiculo.ModeloId=modelo.Id;
                vehiculo.Modelo=modelo;
            }
            else
            {
                vehiculo.ModeloId=null;
                vehiculo.Modelo=null;
            }

            var tipoComb = db.TiposCombustibles.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[11].Value.ToString())).FirstOrDefault();
            if (tipoComb!=null)
            {
                vehiculo.TipoCombustibleId=tipoComb.Id;
                vehiculo.TipoCombustible=tipoComb;
            }
            else
            {
                vehiculo.TipoCombustibleId=null;
                vehiculo.TipoCombustible=null;

            }
            var tipoVehi = db.TiposVehiculos.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())).FirstOrDefault();
            if (tipoVehi!=null)
            {
                vehiculo.TipoVehiculoId=tipoVehi.Id;
                vehiculo.TipoVehiculo=tipoVehi;
            }
            else
            {
                vehiculo.TipoVehiculoId=null;
                vehiculo.TipoVehiculo=null;



            }

            vehiculo.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[13].Value.ToString());
            txtDescripcion.Text=vehiculo.Descripcion;
            txtChasis.Text=vehiculo.NoChasis;
            txtNMotor.Text=vehiculo.NoMotor;
            txtPlaca.Text=vehiculo.NoPlaca;

            chBEstado.Checked=vehiculo.Estado;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled=dataGridView1.SelectedRows.Count>0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            vehiculo.Id=null;
            if (Validar())
            {
                
                vehiculoRepository.Create(GetVehiculo());
                LoadData();
                Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                vehiculoRepository.Update(GetVehiculo());
                LoadData();
                Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var m = GetVehiculo();
                if (m!=null)
                {
                    vehiculoRepository.Delete(m);
                    LoadData();
                    Clear();
                }

            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                MessageBox.Show("La tabla no puede ser borrada al estar anexada con otras tablas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +ex.StackTrace);
            }
        }

        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text.Trim()))
            {
                errores.Add("Descripcion vacia...");
            }
            if (string.IsNullOrWhiteSpace(txtNMotor.Text.Trim()))
            {
                errores.Add("Numero de motor vacio...");
            }
            if (string.IsNullOrWhiteSpace(txtChasis.Text.Trim()))
            {
                errores.Add("Numero de chasis vacio...");
            }
            if (string.IsNullOrWhiteSpace(txtPlaca.Text.Trim()))
            {
                errores.Add("Numero de placa vacio...");
            }
            if (string.IsNullOrWhiteSpace(cbbTipoVeh.Text.Trim()))
            {
                errores.Add("Tipo de vehiculo Vacio...");
            }
            if (string.IsNullOrWhiteSpace(cbbMarcas.Text.Trim()))
            {
                errores.Add("Marca vacia...");
            }
            if (string.IsNullOrWhiteSpace(cbbModelos.Text.Trim()))
            {
                errores.Add("Modelo vacio...");
            }
            if (string.IsNullOrWhiteSpace(cbbTipoComb.Text.Trim()))
            {
                errores.Add("Tipo de combustible vacio...");
            }

            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.Vehiculos.Where(x => x.Descripcion == txtDescripcion.Text.Trim() && x.Id != vehiculo.Id).Any())
            {
                errores.Add("Vehiculo existente con la misma descripcion");
            }
            if (db.Vehiculos.Where(x => x.NoChasis == txtChasis.Text.Trim() && x.Id != vehiculo.Id).Any())
            {
                errores.Add("Vehiculo existe con el mismo No. de Chasis.");
            }
            if (db.Vehiculos.Where(x => x.NoPlaca ==txtPlaca.Text.Trim() && x.Id != vehiculo.Id).Any())
            {
                errores.Add("Vehiculo existente con la misma placa...");
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

        private void Vehiculos_Load(object sender, EventArgs e)
        {
            LoadData() ;

        }
    }
}
