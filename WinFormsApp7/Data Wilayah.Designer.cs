namespace UAS
{
    partial class Data_Wilayah
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            checkBox1 = new CheckBox();
            button1 = new Button();
            label2 = new Label();
            Kode_Provinsi = new TextBox();
            Nama_Provinsi = new TextBox();
            label3 = new Label();
            Kode_Kabupaten = new TextBox();
            Nama_Kabupaten = new TextBox();
            label4 = new Label();
            Kode_Kecamatan = new TextBox();
            Nama_Kecamatan = new TextBox();
            label5 = new Label();
            Kode_Kelurahan = new TextBox();
            Nama_Kelurahan = new TextBox();
            label6 = new Label();
            Nama_Dusun = new TextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(662, 101);
            label1.Name = "label1";
            label1.Size = new Size(165, 32);
            label1.TabIndex = 0;
            label1.Text = "Data Wilayah";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(3, 83, 164);
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(510, 316);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(257, 24);
            checkBox1.TabIndex = 26;
            checkBox1.Text = "Anggota Keluarga di Luar Negeri?";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackgroundImage = WinFormsApp7.Properties.Resources.Cuplikan_layar_2024_07_24_133814;
            button1.Location = new Point(317, 312);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 30);
            button1.TabIndex = 27;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(3, 83, 164);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(34, 66);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 15;
            label2.Text = "Kode Provinsi";
            // 
            // Kode_Provinsi
            // 
            Kode_Provinsi.BackColor = Color.FromArgb(255, 255, 192);
            Kode_Provinsi.Location = new Point(163, 63);
            Kode_Provinsi.Margin = new Padding(3, 2, 3, 2);
            Kode_Provinsi.MaxLength = 2;
            Kode_Provinsi.Name = "Kode_Provinsi";
            Kode_Provinsi.ReadOnly = true;
            Kode_Provinsi.Size = new Size(60, 27);
            Kode_Provinsi.TabIndex = 14;
            Kode_Provinsi.TabStop = false;
            Kode_Provinsi.Text = "32";
            // 
            // Nama_Provinsi
            // 
            Nama_Provinsi.BackColor = Color.FromArgb(255, 255, 192);
            Nama_Provinsi.Location = new Point(254, 63);
            Nama_Provinsi.Margin = new Padding(3, 2, 3, 2);
            Nama_Provinsi.Name = "Nama_Provinsi";
            Nama_Provinsi.ReadOnly = true;
            Nama_Provinsi.Size = new Size(500, 27);
            Nama_Provinsi.TabIndex = 16;
            Nama_Provinsi.TabStop = false;
            Nama_Provinsi.Text = "Jawa Barat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(3, 83, 164);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(34, 111);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 17;
            label3.Text = "Kode Kabupaten";
            // 
            // Kode_Kabupaten
            // 
            Kode_Kabupaten.BackColor = Color.FromArgb(255, 255, 192);
            Kode_Kabupaten.Location = new Point(163, 108);
            Kode_Kabupaten.Margin = new Padding(3, 2, 3, 2);
            Kode_Kabupaten.MaxLength = 2;
            Kode_Kabupaten.Name = "Kode_Kabupaten";
            Kode_Kabupaten.ReadOnly = true;
            Kode_Kabupaten.Size = new Size(60, 27);
            Kode_Kabupaten.TabIndex = 18;
            Kode_Kabupaten.TabStop = false;
            Kode_Kabupaten.Text = "01";
            // 
            // Nama_Kabupaten
            // 
            Nama_Kabupaten.BackColor = Color.FromArgb(255, 255, 192);
            Nama_Kabupaten.Location = new Point(254, 108);
            Nama_Kabupaten.Margin = new Padding(3, 2, 3, 2);
            Nama_Kabupaten.Name = "Nama_Kabupaten";
            Nama_Kabupaten.ReadOnly = true;
            Nama_Kabupaten.Size = new Size(500, 27);
            Nama_Kabupaten.TabIndex = 19;
            Nama_Kabupaten.TabStop = false;
            Nama_Kabupaten.Text = "Kabupaten Bogor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(3, 83, 164);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(34, 156);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 23;
            label4.Text = "Kode Kecamatan";
            // 
            // Kode_Kecamatan
            // 
            Kode_Kecamatan.BackColor = Color.FromArgb(255, 255, 192);
            Kode_Kecamatan.Location = new Point(163, 152);
            Kode_Kecamatan.Margin = new Padding(3, 2, 3, 2);
            Kode_Kecamatan.MaxLength = 2;
            Kode_Kecamatan.Name = "Kode_Kecamatan";
            Kode_Kecamatan.ReadOnly = true;
            Kode_Kecamatan.Size = new Size(60, 27);
            Kode_Kecamatan.TabIndex = 20;
            Kode_Kecamatan.TabStop = false;
            Kode_Kecamatan.Text = "11";
            // 
            // Nama_Kecamatan
            // 
            Nama_Kecamatan.BackColor = Color.FromArgb(255, 255, 192);
            Nama_Kecamatan.Location = new Point(254, 152);
            Nama_Kecamatan.Margin = new Padding(3, 2, 3, 2);
            Nama_Kecamatan.Name = "Nama_Kecamatan";
            Nama_Kecamatan.ReadOnly = true;
            Nama_Kecamatan.Size = new Size(500, 27);
            Nama_Kecamatan.TabIndex = 21;
            Nama_Kecamatan.TabStop = false;
            Nama_Kecamatan.Text = "Kecamatan Ciseeng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(3, 83, 164);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(34, 200);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 28;
            label5.Text = "Kode Kelurahan";
            // 
            // Kode_Kelurahan
            // 
            Kode_Kelurahan.BackColor = Color.FromArgb(255, 255, 192);
            Kode_Kelurahan.Location = new Point(163, 198);
            Kode_Kelurahan.Margin = new Padding(3, 2, 3, 2);
            Kode_Kelurahan.MaxLength = 2;
            Kode_Kelurahan.Name = "Kode_Kelurahan";
            Kode_Kelurahan.Size = new Size(60, 27);
            Kode_Kelurahan.TabIndex = 22;
            // 
            // Nama_Kelurahan
            // 
            Nama_Kelurahan.BackColor = Color.FromArgb(255, 255, 192);
            Nama_Kelurahan.Location = new Point(254, 198);
            Nama_Kelurahan.Margin = new Padding(3, 2, 3, 2);
            Nama_Kelurahan.Name = "Nama_Kelurahan";
            Nama_Kelurahan.ReadOnly = true;
            Nama_Kelurahan.Size = new Size(500, 27);
            Nama_Kelurahan.TabIndex = 24;
            Nama_Kelurahan.TabStop = false;
            Nama_Kelurahan.Text = "Kelurahan CIBEUTEUNG MUARA";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(3, 83, 164);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(34, 246);
            label6.Name = "label6";
            label6.Size = new Size(212, 20);
            label6.TabIndex = 29;
            label6.Text = "Nama Dusun/Dukuh/Kampung";
            // 
            // Nama_Dusun
            // 
            Nama_Dusun.BackColor = Color.FromArgb(255, 255, 192);
            Nama_Dusun.Location = new Point(254, 243);
            Nama_Dusun.Margin = new Padding(3, 2, 3, 2);
            Nama_Dusun.Name = "Nama_Dusun";
            Nama_Dusun.Size = new Size(500, 27);
            Nama_Dusun.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = WinFormsApp7.Properties.Resources.Desain_tanpa_judul__2__removebg_preview;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(Kode_Provinsi);
            panel1.Controls.Add(Nama_Provinsi);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(Kode_Kabupaten);
            panel1.Controls.Add(Nama_Kabupaten);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(Kode_Kecamatan);
            panel1.Controls.Add(Nama_Kecamatan);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(Kode_Kelurahan);
            panel1.Controls.Add(Nama_Kelurahan);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(Nama_Dusun);
            panel1.Location = new Point(292, 148);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(813, 398);
            panel1.TabIndex = 30;
            // 
            // Data_Wilayah
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = WinFormsApp7.Properties.Resources.Descargar_Fondo_de_diseño_hexagonal_azul_claro_geométrico_abstracto__gratis;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1371, 759);
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Data_Wilayah";
            Text = "Data Wilayah";
            Load += Data_Wilayah_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CheckBox checkBox1;
        private Button button1;
        private Label label2;
        private TextBox Kode_Provinsi;
        private TextBox Nama_Provinsi;
        private Label label3;
        private TextBox Kode_Kabupaten;
        private TextBox Nama_Kabupaten;
        private Label label4;
        private TextBox Kode_Kecamatan;
        private TextBox Nama_Kecamatan;
        private Label label5;
        private TextBox Kode_Kelurahan;
        private TextBox Nama_Kelurahan;
        private Label label6;
        private TextBox Nama_Dusun;
        private Panel panel1;
    }
}
