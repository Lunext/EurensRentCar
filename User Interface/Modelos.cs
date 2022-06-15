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
    public partial class Modelos : Form
    {
        readonly Modelo modelo = new Modelo();
        readonly ModeloRepository modeloRepository = new ModeloRepository();
        readonly MarcasRepository marcasRepository = new MarcasRepository();
        List<string> errores = new List<string>(); 
        public Modelos()
        {
            InitializeComponent();
        }
        private Modelo GetModelo()
        {
            modelo.Descripcion=txtDescripcion.Text.Trim();
            modelo.Estado=chBEstado.Checked;
            using EurenRentCarContext db = new EurenRentCarContext();
            var marca = db.Marcas.Where(y => y.Descripcion==cbbMarcas.Text).FirstOrDefault();
            if (marca!=null)
            {
                modelo.MarcaId=marca.Id;
                modelo.Marca=marca;
            }
            else
            {
                modelo.MarcaId=null;
                modelo.Marca=null; 
            }
            return modelo; 

        }

        public void LoadData()
        {
            dataGridView1.DataSource=modeloRepository.View();
            cbbMarcas.DataSource=marcasRepository.View();
            dataGridView1.ClearSelection();
        }
        
        private void Clear()
        {
            txtDescripcion.Text="";
            chBEstado.Checked=false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modelo.Id=null;
            if (Validar())
            {
                
                modeloRepository.Create(GetModelo());
                LoadData();
                Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                modeloRepository.Update(GetModelo());
                LoadData();
                Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var m = GetModelo();
                if (m!=null)
                {
                    modeloRepository.Delete(m);
                    LoadData();
                    Clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message +ex.StackTrace);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled=dataGridView1.SelectedRows.Count>0; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modelo.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            modelo.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            using EurenRentCarContext db = new EurenRentCarContext();
            var marca = db.Marcas.Where(y => y.Id==Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())).FirstOrDefault();
            
          
            if (marca!=null)
            {
                modelo.MarcaId=marca.Id;
                modelo.Marca=marca;
            }
            else
            {
                modelo.MarcaId=null;
                modelo.Marca=null;
            }
            modelo.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            txtDescripcion.Text=modelo.Descripcion;
            chBEstado.Checked=modelo.Estado;

        }

        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errores.Add("La descripcion esta vacia");
            }
            if (string.IsNullOrWhiteSpace(cbbMarcas.Text))
            {
                errores.Add("Debe pertenecer a una marca.");
            }
            using EurenRentCarContext db = new EurenRentCarContext();
            if (string.IsNullOrWhiteSpace(cbbMarcas.Text))
            {
                errores.Add("Se necesita seleccionar una marca .");

            }
            else
            {
                var marca = (Marca)cbbMarcas.SelectedItem;
                if (db.Modelos.Where(x => x.Descripcion == txtDescripcion.Text.Trim() && x.MarcaId == marca.Id && x.Id != modelo.Id).Any())
                {
                    errores.Add("Ya existe un modelo con la misma marca....");
                }
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

        private void Modelos_Load(object sender, EventArgs e)
        {
            LoadData(); 

        }
    }
}
