namespace UAS
{
    partial class Data_Kepala_Keluarga
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
            label10 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            Nama_Kepala_Keluarga = new TextBox();
            label3 = new Label();
            Alamat1 = new TextBox();
            Alamat2 = new TextBox();
            label4 = new Label();
            Kode_Pos = new TextBox();
            label5 = new Label();
            RT = new TextBox();
            label6 = new Label();
            RW = new TextBox();
            label7 = new Label();
            Jumlah_Anggota_Keluarga = new TextBox();
            label8 = new Label();
            telephone = new TextBox();
            label9 = new Label();
            Email = new TextBox();
            label11 = new Label();
            Nomor_KK = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(271, 12);
            label1.Name = "label1";
            label1.Size = new Size(260, 32);
            label1.TabIndex = 0;
            label1.Text = "Data Kepala Keluarga";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(Nomor_KK);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Nama_Kepala_Keluarga);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Alamat1);
            groupBox1.Controls.Add(Alamat2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Kode_Pos);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(RT);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(RW);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(Jumlah_Anggota_Keluarga);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(telephone);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(Email);
            groupBox1.Location = new Point(11, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(760, 383);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informasi Kepala Keluarga";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 64);
            label10.Name = "label10";
            label10.Size = new Size(146, 20);
            label10.TabIndex = 19;
            label10.Text = "NIK Kepala Keluarga";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(240, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(500, 27);
            textBox1.TabIndex = 20;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(592, 333);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(97, 31);
            button1.TabIndex = 18;
            button1.Text = "Selanjutnya";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 108);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 1;
            label2.Text = "Nama Kepala Keluarga";
            // 
            // Nama_Kepala_Keluarga
            // 
            Nama_Kepala_Keluarga.Location = new Point(240, 105);
            Nama_Kepala_Keluarga.Name = "Nama_Kepala_Keluarga";
            Nama_Kepala_Keluarga.Size = new Size(500, 27);
            Nama_Kepala_Keluarga.TabIndex = 3;
            Nama_Kepala_Keluarga.TextChanged += Nama_Kepala_Keluarga_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 153);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Alamat";
            // 
            // Alamat1
            // 
            Alamat1.Location = new Point(240, 150);
            Alamat1.Name = "Alamat1";
            Alamat1.Size = new Size(500, 27);
            Alamat1.TabIndex = 4;
            Alamat1.TextChanged += Alamat1_TextChanged;
            // 
            // Alamat2
            // 
            Alamat2.Location = new Point(240, 194);
            Alamat2.Name = "Alamat2";
            Alamat2.Size = new Size(500, 27);
            Alamat2.TabIndex = 5;
            Alamat2.TextChanged += Alamat2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 240);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 6;
            label4.Text = "Kode Pos";
            // 
            // Kode_Pos
            // 
            Kode_Pos.Location = new Point(240, 237);
            Kode_Pos.Name = "Kode_Pos";
            Kode_Pos.Size = new Size(79, 27);
            Kode_Pos.TabIndex = 7;
            Kode_Pos.Text = "16120";
            Kode_Pos.TextChanged += Kode_Pos_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(341, 240);
            label5.Name = "label5";
            label5.Size = new Size(27, 20);
            label5.TabIndex = 8;
            label5.Text = "RT";
            // 
            // RT
            // 
            RT.Location = new Point(386, 237);
            RT.Name = "RT";
            RT.Size = new Size(48, 27);
            RT.TabIndex = 9;
            RT.Text = "001";
            RT.TextChanged += RT_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(451, 240);
            label6.Name = "label6";
            label6.Size = new Size(30, 20);
            label6.TabIndex = 10;
            label6.Text = "RW";
            // 
            // RW
            // 
            RW.Location = new Point(503, 237);
            RW.Name = "RW";
            RW.Size = new Size(48, 27);
            RW.TabIndex = 11;
            RW.Text = "001";
            RW.TextChanged += RW_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 282);
            label7.Name = "label7";
            label7.Size = new Size(173, 20);
            label7.TabIndex = 12;
            label7.Text = "Jumlah Anggota Keluarga";
            // 
            // Jumlah_Anggota_Keluarga
            // 
            Jumlah_Anggota_Keluarga.Location = new Point(240, 279);
            Jumlah_Anggota_Keluarga.Name = "Jumlah_Anggota_Keluarga";
            Jumlah_Anggota_Keluarga.Size = new Size(48, 27);
            Jumlah_Anggota_Keluarga.TabIndex = 13;
            Jumlah_Anggota_Keluarga.TextChanged += Jumlah_Anggota_Keluarga_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(341, 282);
            label8.Name = "label8";
            label8.Size = new Size(71, 20);
            label8.TabIndex = 14;
            label8.Text = "Telepon";
            // 
            // telephone
            // 
            telephone.Location = new Point(418, 279);
            telephone.Name = "telephone";
            telephone.Size = new Size(160, 27);
            telephone.TabIndex = 15;
            telephone.TextChanged += telephone_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 327);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 16;
            label9.Text = "Email";
            // 
            // Email
            // 
            Email.Location = new Point(240, 324);
            Email.Name = "Email";
            Email.Size = new Size(308, 27);
            Email.TabIndex = 17;
            Email.TextChanged += Email_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(21, 29);
            label11.Name = "label11";
            label11.Size = new Size(72, 20);
            label11.TabIndex = 21;
            label11.Text = "Nomor KK";
            // 
            // Nomor_KK
            // 
            Nomor_KK.Location = new Point(240, 26);
            Nomor_KK.Name = "Nomor_KK";
            Nomor_KK.Size = new Size(500, 27);
            Nomor_KK.TabIndex = 22;
            Nomor_KK.TextChanged += Nomor_KK_TextChanged;
            // 
            // Data_Kepala_Keluarga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 451);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Data_Kepala_Keluarga";
            Text = "Data Kepala Keluarga";
            Load += Data_Kepala_Keluarga_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox Nama_Kepala_Keluarga;
        private Label label3;
        private TextBox Alamat1;
        private TextBox Alamat2;
        private Label label4;
        private TextBox Kode_Pos;
        private Label label5;
        private TextBox RT;
        private Label label6;
        private TextBox RW;
        private Label label7;
        private TextBox Jumlah_Anggota_Keluarga;
        private Label label8;
        private TextBox telephone;
        private Label label9;
        private TextBox Email;
        private Button button1;
        private Label label10;
        private TextBox textBox1;
        private Label label11;
        private TextBox Nomor_KK;
    }
}
