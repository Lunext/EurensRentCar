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
    public partial class Marcas : Form
    {
        readonly Marca marca = new Marca();
        readonly MarcasRepository marcaRepository= new MarcasRepository();
        List<string> errores = new List<string>();
        public Marcas()
        {
            InitializeComponent();
        }

        private Marca GetMarca()
        {
            marca.Descripcion=txtDescripcion.Text.Trim();
            marca.Estado=chBEstado.Checked;
            return marca;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            marca.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            marca.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            marca.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtDescripcion.Text= marca.Descripcion;
            chBEstado.Checked= marca.Estado;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            marca.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            marca.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            marca.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtDescripcion.Text= marca.Descripcion;
            chBEstado.Checked= marca.Estado;


        }
        private void Clear()
        {
            txtDescripcion.Text="";
            chBEstado.Checked=false;
        }
        public void LoadData()
        {
            dataGridView1.DataSource=marcaRepository.View();
            dataGridView1.ClearSelection();
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            marca.Id=null;
            if (Validar())
            {
                marcaRepository.Create(GetMarca());
                LoadData();
                Clear();
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            if (Validar())
            {
                marcaRepository.Update(GetMarca());
                LoadData();
                Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                var m = GetMarca();
                if (m!=null)
                {
                    marcaRepository.Delete(m);
                    LoadData();
                    Clear();
                }
            }
          
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnBorrar.Enabled=dataGridView1.SelectedRows.Count>0;

        }
        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text.Trim()))
            {
                errores.Add("Favor introducir una descripcion antes de continuar.");
            }
            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.Marcas.Where(x => x.Descripcion == txtDescripcion.Text && x.Id != marca.Id).Any())
            {
                errores.Add("Combustible existente...");
            }

            var message = "";
            foreach (var e in errores)
            {
                message += e + "\n";
            }
            if (errores.Count > 0)
            {
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
