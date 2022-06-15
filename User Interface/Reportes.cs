using Euren_sRentCar.Models;
using EurenRentCar.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurenRentCar.User_Interface
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            cbbClientes.DataSource = (new ClienteRepository()).View();
            cbbVehiculo.DataSource = (new TipoVehiculoRepository()).View();
            cbbMarcas.DataSource = (new MarcasRepository()).View();
            cbbModelo.Enabled = false;
            cbbClientes.Enabled = false;
            cbbVehiculo.Enabled = false;
            cbbMarcas.Enabled = false;
            activoCliente.Checked = false;
            ActivoVehiculo.Checked = false;
            ActivoMarca.Checked = false;
            activoModelo.Checked = false;

        }
        private void WriteExcel()
        {
           
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(Carga()), (typeof(DataTable)));
            var memoryStream = new MemoryStream();

            using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Hoja1");

                List<String> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in table.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (String col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }

                    rowIndex++;
                }
                workbook.Write(fs);
                FileInfo fi = new FileInfo("Result.xlsx");
                if (fi.Exists)
                {
                    using Process fileopener = new Process();

                    fileopener.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\excel.exe";
                    fileopener.StartInfo.Arguments = "\"" + "Result.xlsx" + "\"";
                    fileopener.Start();

                }
                else
                {
                    //file doesn't exist
                }
            }

        }
        private List<Renta> Carga()
        {
            using EurenRentCarContext db = new EurenRentCarContext();
            var query = db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente)
                .Where(x => x.FechaRenta >= fechadesde.Value && x.FechaRenta <= fechahasta.Value);
            if (activoCliente.Checked)
            {
                query = query.Where(x => x.ClienteId == ((Cliente)cbbClientes.SelectedItem).Id);
            }
            if (ActivoVehiculo.Checked)
            {
                query = query.Where(x => x.Vehiculo.TipoVehiculoId == ((TipoVehiculo)cbbVehiculo.SelectedItem).Id);
            }
            if (ActivoMarca.Checked)
            {
                query = query.Where(x => x.Vehiculo.MarcaId == ((Marca)cbbMarcas.SelectedItem).Id);
            }
            if (activoModelo.Checked)
            {
                query = query.Where(x => x.Vehiculo.ModeloId == ((Modelo)cbbModelo.SelectedItem).Id);

            }
            var rentas = query.ToList();
            return rentas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteExcel(); 
        }

        private void cbbMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = (Marca)cbbMarcas.SelectedItem;
            cbbModelo.DataSource = (new ModeloRepository()).View(m);
            if (activoModelo.Checked)
            {
                cbbModelo.Enabled = true;
            }

        }

        private void activoCliente_CheckedChanged(object sender, EventArgs e)
        {
            cbbClientes.Enabled= activoCliente.Checked;
        }

        private void ActivoVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            cbbVehiculo.Enabled=ActivoVehiculo.Checked; 
        }

        private void ActivoMarca_CheckedChanged(object sender, EventArgs e)
        {
            cbbMarcas.Enabled=ActivoMarca.Checked;

        }

        private void activoModelo_CheckedChanged(object sender, EventArgs e)
        {
            cbbModelo.Enabled=activoModelo.Checked; 
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=Carga();
        }
    }
    
}
