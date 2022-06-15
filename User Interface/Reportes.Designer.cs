namespace EurenRentCar.User_Interface
{
    partial class Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.activoModelo = new System.Windows.Forms.CheckBox();
            this.fechahasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.activoCliente = new System.Windows.Forms.CheckBox();
            this.ActivoVehiculo = new System.Windows.Forms.CheckBox();
            this.ActivoMarca = new System.Windows.Forms.CheckBox();
            this.cbbModelo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fechadesde = new System.Windows.Forms.DateTimePicker();
            this.cbbMarcas = new System.Windows.Forms.ComboBox();
            this.cbbVehiculo = new System.Windows.Forms.ComboBox();
            this.cbbClientes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbTiposVehiculos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labe = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(78, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 629);
            this.panel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(762, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(566, 309);
            this.dataGridView1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.activoModelo);
            this.panel2.Controls.Add(this.fechahasta);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.activoCliente);
            this.panel2.Controls.Add(this.ActivoVehiculo);
            this.panel2.Controls.Add(this.ActivoMarca);
            this.panel2.Controls.Add(this.cbbModelo);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.fechadesde);
            this.panel2.Controls.Add(this.cbbMarcas);
            this.panel2.Controls.Add(this.cbbVehiculo);
            this.panel2.Controls.Add(this.cbbClientes);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cbbTiposVehiculos);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labe);
            this.panel2.Location = new System.Drawing.Point(3, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 387);
            this.panel2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OrangeRed;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(30, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(637, 29);
            this.button2.TabIndex = 44;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::EurenRentCar.Properties.Resources.icons8_report_64;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(456, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 274);
            this.button1.TabIndex = 43;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // activoModelo
            // 
            this.activoModelo.AutoSize = true;
            this.activoModelo.Location = new System.Drawing.Point(342, 200);
            this.activoModelo.Name = "activoModelo";
            this.activoModelo.Size = new System.Drawing.Size(73, 24);
            this.activoModelo.TabIndex = 43;
            this.activoModelo.Text = "Activo";
            this.activoModelo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.activoModelo.UseVisualStyleBackColor = true;
            this.activoModelo.CheckedChanged += new System.EventHandler(this.activoModelo_CheckedChanged);
            // 
            // fechahasta
            // 
            this.fechahasta.CalendarTrailingForeColor = System.Drawing.Color.DeepSkyBlue;
            this.fechahasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechahasta.Location = new System.Drawing.Point(300, 248);
            this.fechahasta.Name = "fechahasta";
            this.fechahasta.Size = new System.Drawing.Size(106, 27);
            this.fechahasta.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(223, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Hasta";
            // 
            // activoCliente
            // 
            this.activoCliente.AutoSize = true;
            this.activoCliente.Location = new System.Drawing.Point(342, 55);
            this.activoCliente.Name = "activoCliente";
            this.activoCliente.Size = new System.Drawing.Size(73, 24);
            this.activoCliente.TabIndex = 40;
            this.activoCliente.Text = "Activo";
            this.activoCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.activoCliente.UseVisualStyleBackColor = true;
            this.activoCliente.CheckedChanged += new System.EventHandler(this.activoCliente_CheckedChanged);
            // 
            // ActivoVehiculo
            // 
            this.ActivoVehiculo.AutoSize = true;
            this.ActivoVehiculo.Location = new System.Drawing.Point(377, 102);
            this.ActivoVehiculo.Name = "ActivoVehiculo";
            this.ActivoVehiculo.Size = new System.Drawing.Size(73, 24);
            this.ActivoVehiculo.TabIndex = 37;
            this.ActivoVehiculo.Text = "Activo";
            this.ActivoVehiculo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ActivoVehiculo.UseVisualStyleBackColor = true;
            this.ActivoVehiculo.CheckedChanged += new System.EventHandler(this.ActivoVehiculo_CheckedChanged);
            // 
            // ActivoMarca
            // 
            this.ActivoMarca.AutoSize = true;
            this.ActivoMarca.Location = new System.Drawing.Point(346, 146);
            this.ActivoMarca.Name = "ActivoMarca";
            this.ActivoMarca.Size = new System.Drawing.Size(73, 24);
            this.ActivoMarca.TabIndex = 36;
            this.ActivoMarca.Text = "Activo";
            this.ActivoMarca.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ActivoMarca.UseVisualStyleBackColor = true;
            this.ActivoMarca.CheckedChanged += new System.EventHandler(this.ActivoMarca_CheckedChanged);
            // 
            // cbbModelo
            // 
            this.cbbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbModelo.FormattingEnabled = true;
            this.cbbModelo.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "0.75",
            "1"});
            this.cbbModelo.Location = new System.Drawing.Point(102, 200);
            this.cbbModelo.Name = "cbbModelo";
            this.cbbModelo.Size = new System.Drawing.Size(217, 28);
            this.cbbModelo.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Modelo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(15, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Desde";
            // 
            // fechadesde
            // 
            this.fechadesde.CalendarTrailingForeColor = System.Drawing.Color.DeepSkyBlue;
            this.fechadesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechadesde.Location = new System.Drawing.Point(102, 248);
            this.fechadesde.Name = "fechadesde";
            this.fechadesde.Size = new System.Drawing.Size(106, 27);
            this.fechadesde.TabIndex = 25;
            // 
            // cbbMarcas
            // 
            this.cbbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMarcas.FormattingEnabled = true;
            this.cbbMarcas.Location = new System.Drawing.Point(102, 144);
            this.cbbMarcas.Name = "cbbMarcas";
            this.cbbMarcas.Size = new System.Drawing.Size(217, 28);
            this.cbbMarcas.TabIndex = 24;
            this.cbbMarcas.SelectedIndexChanged += new System.EventHandler(this.cbbMarcas_SelectedIndexChanged);
            // 
            // cbbVehiculo
            // 
            this.cbbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVehiculo.FormattingEnabled = true;
            this.cbbVehiculo.Location = new System.Drawing.Point(154, 103);
            this.cbbVehiculo.Name = "cbbVehiculo";
            this.cbbVehiculo.Size = new System.Drawing.Size(217, 28);
            this.cbbVehiculo.TabIndex = 23;
            // 
            // cbbClientes
            // 
            this.cbbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClientes.FormattingEnabled = true;
            this.cbbClientes.Location = new System.Drawing.Point(102, 56);
            this.cbbClientes.Name = "cbbClientes";
            this.cbbClientes.Size = new System.Drawing.Size(217, 28);
            this.cbbClientes.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(11, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cliente";
            // 
            // cbbTiposVehiculos
            // 
            this.cbbTiposVehiculos.AutoSize = true;
            this.cbbTiposVehiculos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbbTiposVehiculos.Location = new System.Drawing.Point(6, 106);
            this.cbbTiposVehiculos.Name = "cbbTiposVehiculos";
            this.cbbTiposVehiculos.Size = new System.Drawing.Size(132, 20);
            this.cbbTiposVehiculos.TabIndex = 9;
            this.cbbTiposVehiculos.Text = "Tipo dde vehiculo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(114, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Genera un reporte!";
            // 
            // labe
            // 
            this.labe.AutoSize = true;
            this.labe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labe.Location = new System.Drawing.Point(3, 152);
            this.labe.Name = "labe";
            this.labe.Size = new System.Drawing.Size(52, 20);
            this.labe.TabIndex = 0;
            this.labe.Text = "Marca";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 699);
            this.Controls.Add(this.panel1);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Panel panel2;
        private DateTimePicker fechahasta;
        private Label label1;
        private CheckBox activoCliente;
        private CheckBox ActivoVehiculo;
        private CheckBox ActivoMarca;
        private ComboBox cbbModelo;
        private Label label5;
        private Label label9;
        private DateTimePicker fechadesde;
        private ComboBox cbbMarcas;
        private ComboBox cbbVehiculo;
        private ComboBox cbbClientes;
        private Label label8;
        private Label cbbTiposVehiculos;
        private Label label3;
        private Label labe;
        private CheckBox activoModelo;
        private DataGridView dataGridView1;
        private Button button2;
    }
}