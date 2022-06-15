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
    public partial class TiposCombustibles : Form
    {

        readonly TipoCombustible tipoCombustible = new TipoCombustible();
        readonly TipoCombustibleRepository tipoCombustibleRepository = new TipoCombustibleRepository();
        List<string> errores = new List<string>();
        public TiposCombustibles()
        {
            InitializeComponent();
        }
        private TipoCombustible GetTipoCombustible()
        {
            tipoCombustible.Descripcion=txtDescripcion.Text.Trim();
            tipoCombustible.Estado=chBEstado.Checked;
            return tipoCombustible;
        }
        private void Clear()
        {
            txtDescripcion.Text="";
            chBEstado.Checked=false;
        }
        public void LoadData()
        {
            dataGridView1.DataSource=tipoCombustibleRepository.View();
            dataGridView1.ClearSelection();
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            btnBorrar.Enabled=dataGridView1.SelectedRows.Count>0;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tipoCombustible.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tipoCombustible.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tipoCombustible.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtDescripcion.Text=tipoCombustible.Descripcion;
            chBEstado.Checked=tipoCombustible.Estado;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tipoCombustible.Id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tipoCombustible.Descripcion=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tipoCombustible.Estado=Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtDescripcion.Text=tipoCombustible.Descripcion;
            chBEstado.Checked=tipoCombustible.Estado;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tipoCombustible.Id=null;
            if (Validar())
            {
                tipoCombustibleRepository.Create(GetTipoCombustible());
                LoadData();
                Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            /* if (tipoCombustible==null)
             {
                 return;
             }*/
            if (Validar()){
                tipoCombustibleRepository.Update(GetTipoCombustible());
                LoadData();

                Clear();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                var tc = GetTipoCombustible();
                if (tc!=null)
                {
                    tipoCombustibleRepository.Delete(tc);
                    LoadData();
                    Clear();
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
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errores.Add("Descripción no puede estar en blanco");
            }
            using EurenRentCarContext db = new EurenRentCarContext();
            if (db.TiposCombustibles.Where(x => x.Descripcion == txtDescripcion.Text && x.Id != tipoCombustible.Id).Any())
            {
                errores.Add("Combustible existente...");
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

        private void TiposCombustibles_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=tipoCombustibleRepository.View();
            dataGridView1.ClearSelection();


        }
    }
}
