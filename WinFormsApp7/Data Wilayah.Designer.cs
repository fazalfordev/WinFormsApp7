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
            groupBox1 = new GroupBox();
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
            label7 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(262, 15);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 0;
            label1.Text = "Data Wilayah";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Kode_Provinsi);
            groupBox1.Controls.Add(Nama_Provinsi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Kode_Kabupaten);
            groupBox1.Controls.Add(Nama_Kabupaten);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Kode_Kecamatan);
            groupBox1.Controls.Add(Nama_Kecamatan);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(Kode_Kelurahan);
            groupBox1.Controls.Add(Nama_Kelurahan);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Nama_Dusun);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(10, 49);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(665, 280);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informasi Wilayah";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(434, 218);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(203, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Anggota Keluarga di Luar Negeri?";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // button1
            // 
            button1.Location = new Point(265, 215);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 30);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 1;
            label2.Text = "Kode Provinsi";
            // 
            // Kode_Provinsi
            // 
            Kode_Provinsi.Location = new Point(131, 28);
            Kode_Provinsi.Margin = new Padding(3, 2, 3, 2);
            Kode_Provinsi.MaxLength = 2;
            Kode_Provinsi.Name = "Kode_Provinsi";
            Kode_Provinsi.ReadOnly = true;
            Kode_Provinsi.Size = new Size(53, 23);
            Kode_Provinsi.TabIndex = 0;
            Kode_Provinsi.Text = "32";
            Kode_Provinsi.TextChanged += Kode_Provinsi_TextChanged;
            // 
            // Nama_Provinsi
            // 
            Nama_Provinsi.Location = new Point(210, 28);
            Nama_Provinsi.Margin = new Padding(3, 2, 3, 2);
            Nama_Provinsi.Name = "Nama_Provinsi";
            Nama_Provinsi.ReadOnly = true;
            Nama_Provinsi.Size = new Size(438, 23);
            Nama_Provinsi.TabIndex = 1;
            Nama_Provinsi.Text = "Jawa Barat";
            Nama_Provinsi.TextChanged += Nama_Provinsi_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 64);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 2;
            label3.Text = "Kode Kabupaten";
            // 
            // Kode_Kabupaten
            // 
            Kode_Kabupaten.Location = new Point(131, 62);
            Kode_Kabupaten.Margin = new Padding(3, 2, 3, 2);
            Kode_Kabupaten.MaxLength = 2;
            Kode_Kabupaten.Name = "Kode_Kabupaten";
            Kode_Kabupaten.ReadOnly = true;
            Kode_Kabupaten.Size = new Size(53, 23);
            Kode_Kabupaten.TabIndex = 2;
            Kode_Kabupaten.Text = "01";
            Kode_Kabupaten.TextChanged += Kode_Kabupaten_TextChanged;
            // 
            // Nama_Kabupaten
            // 
            Nama_Kabupaten.Location = new Point(210, 62);
            Nama_Kabupaten.Margin = new Padding(3, 2, 3, 2);
            Nama_Kabupaten.Name = "Nama_Kabupaten";
            Nama_Kabupaten.ReadOnly = true;
            Nama_Kabupaten.Size = new Size(438, 23);
            Nama_Kabupaten.TabIndex = 3;
            Nama_Kabupaten.Text = "Kabupaten Bogor";
            Nama_Kabupaten.TextChanged += Nama_Kabupaten_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 98);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 7;
            label4.Text = "Kode Kecamatan";
            // 
            // Kode_Kecamatan
            // 
            Kode_Kecamatan.Location = new Point(131, 95);
            Kode_Kecamatan.Margin = new Padding(3, 2, 3, 2);
            Kode_Kecamatan.MaxLength = 2;
            Kode_Kecamatan.Name = "Kode_Kecamatan";
            Kode_Kecamatan.ReadOnly = true;
            Kode_Kecamatan.Size = new Size(53, 23);
            Kode_Kecamatan.TabIndex = 4;
            Kode_Kecamatan.Text = "11";
            Kode_Kecamatan.TextChanged += Kode_Kecamatan_TextChanged;
            // 
            // Nama_Kecamatan
            // 
            Nama_Kecamatan.Location = new Point(210, 95);
            Nama_Kecamatan.Margin = new Padding(3, 2, 3, 2);
            Nama_Kecamatan.Name = "Nama_Kecamatan";
            Nama_Kecamatan.ReadOnly = true;
            Nama_Kecamatan.Size = new Size(438, 23);
            Nama_Kecamatan.TabIndex = 5;
            Nama_Kecamatan.Text = "Kecamatan Ciseeng";
            Nama_Kecamatan.TextChanged += Nama_Kecamatan_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 131);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 10;
            label5.Text = "Kode Kelurahan";
            // 
            // Kode_Kelurahan
            // 
            Kode_Kelurahan.Location = new Point(131, 129);
            Kode_Kelurahan.Margin = new Padding(3, 2, 3, 2);
            Kode_Kelurahan.MaxLength = 2;
            Kode_Kelurahan.Name = "Kode_Kelurahan";
            Kode_Kelurahan.Size = new Size(53, 23);
            Kode_Kelurahan.TabIndex = 6;
            Kode_Kelurahan.TextChanged += Kode_Kelurahan_TextChanged;
            // 
            // Nama_Kelurahan
            // 
            Nama_Kelurahan.Location = new Point(210, 129);
            Nama_Kelurahan.Margin = new Padding(3, 2, 3, 2);
            Nama_Kelurahan.Name = "Nama_Kelurahan";
            Nama_Kelurahan.ReadOnly = true;
            Nama_Kelurahan.Size = new Size(438, 23);
            Nama_Kelurahan.TabIndex = 7;
            Nama_Kelurahan.Text = "Kelurahan CIBEUTEUNG MUARA";
            Nama_Kelurahan.TextChanged += Nama_Kelurahan_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 165);
            label6.Name = "label6";
            label6.Size = new Size(173, 15);
            label6.TabIndex = 13;
            label6.Text = "Nama Dusun/Dukuh/Kampung";
            // 
            // Nama_Dusun
            // 
            Nama_Dusun.Location = new Point(210, 163);
            Nama_Dusun.Margin = new Padding(3, 2, 3, 2);
            Nama_Dusun.Name = "Nama_Dusun";
            Nama_Dusun.Size = new Size(438, 23);
            Nama_Dusun.TabIndex = 8;
            Nama_Dusun.TextChanged += Nama_Dusun_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 165);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 16;
            // 
            // Data_Wilayah
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Data_Wilayah";
            Text = "Data Wilayah";
            Load += Data_Wilayah_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Kode_Provinsi;
        private System.Windows.Forms.TextBox Nama_Provinsi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Kode_Kabupaten;
        private System.Windows.Forms.TextBox Nama_Kabupaten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Kode_Kecamatan;
        private System.Windows.Forms.TextBox Nama_Kecamatan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Kode_Kelurahan;
        private System.Windows.Forms.TextBox Nama_Kelurahan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Nama_Dusun;
        private System.Windows.Forms.Label label7;
        private Button button1;
        private CheckBox checkBox1;
    }
}
