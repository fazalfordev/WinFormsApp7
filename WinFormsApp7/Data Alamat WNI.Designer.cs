namespace UAS
{
    partial class Data_Alamat_WNI
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
            label2 = new Label();
            AlamatLN = new TextBox();
            label3 = new Label();
            KotaLN = new TextBox();
            label4 = new Label();
            ProvinsiLN = new TextBox();
            label5 = new Label();
            NegaraLN = new TextBox();
            label6 = new Label();
            Kode_PosLN = new TextBox();
            label7 = new Label();
            Jumlah_Anggota_KeluargaLN = new TextBox();
            label8 = new Label();
            Kode_Nama_NegaraLN = new TextBox();
            label9 = new Label();
            Kode_Nama_Perwakilan_RILN = new TextBox();
            label10 = new Label();
            TeleponLN = new TextBox();
            label11 = new Label();
            EmailLN = new TextBox();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(262, 15);
            label1.Name = "label1";
            label1.Size = new Size(194, 30);
            label1.TabIndex = 0;
            label1.Text = "Data Alamat WNI";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(AlamatLN);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(KotaLN);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(ProvinsiLN);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(NegaraLN);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Kode_PosLN);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(Jumlah_Anggota_KeluargaLN);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(Kode_Nama_NegaraLN);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(Kode_Nama_Perwakilan_RILN);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(TeleponLN);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(EmailLN);
            groupBox1.Location = new Point(10, 49);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(665, 375);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informasi Alamat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 30);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 1;
            label2.Text = "Alamat";
            // 
            // AlamatLN
            // 
            AlamatLN.Location = new Point(131, 28);
            AlamatLN.Margin = new Padding(3, 2, 3, 2);
            AlamatLN.Name = "AlamatLN";
            AlamatLN.Size = new Size(517, 23);
            AlamatLN.TabIndex = 3;
            AlamatLN.TextChanged += Alamat_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 64);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 2;
            label3.Text = "Kota";
            // 
            // KotaLN
            // 
            KotaLN.Location = new Point(131, 62);
            KotaLN.Margin = new Padding(3, 2, 3, 2);
            KotaLN.Name = "KotaLN";
            KotaLN.Size = new Size(182, 23);
            KotaLN.TabIndex = 5;
            KotaLN.TextChanged += Kota_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 64);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 7;
            label4.Text = "Provinsi/Negara Bagian";
            // 
            // ProvinsiLN
            // 
            ProvinsiLN.Location = new Point(483, 62);
            ProvinsiLN.Margin = new Padding(3, 2, 3, 2);
            ProvinsiLN.Name = "ProvinsiLN";
            ProvinsiLN.Size = new Size(165, 23);
            ProvinsiLN.TabIndex = 8;
            ProvinsiLN.TextChanged += Provinsi_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 94);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 10;
            label5.Text = "Negara";
            // 
            // NegaraLN
            // 
            NegaraLN.Location = new Point(131, 92);
            NegaraLN.Margin = new Padding(3, 2, 3, 2);
            NegaraLN.Name = "NegaraLN";
            NegaraLN.Size = new Size(517, 23);
            NegaraLN.TabIndex = 11;
            NegaraLN.TextChanged += Negara_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 127);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 13;
            label6.Text = "Kode Pos";
            // 
            // Kode_PosLN
            // 
            Kode_PosLN.Location = new Point(131, 124);
            Kode_PosLN.Margin = new Padding(3, 2, 3, 2);
            Kode_PosLN.Name = "Kode_PosLN";
            Kode_PosLN.Size = new Size(182, 23);
            Kode_PosLN.TabIndex = 14;
            Kode_PosLN.TextChanged += Kode_Pos_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(318, 130);
            label7.Name = "label7";
            label7.Size = new Size(143, 15);
            label7.TabIndex = 16;
            label7.Text = "Jumlah Anggota Keluarga";
            // 
            // Jumlah_Anggota_KeluargaLN
            // 
            Jumlah_Anggota_KeluargaLN.Location = new Point(480, 130);
            Jumlah_Anggota_KeluargaLN.Margin = new Padding(3, 2, 3, 2);
            Jumlah_Anggota_KeluargaLN.Name = "Jumlah_Anggota_KeluargaLN";
            Jumlah_Anggota_KeluargaLN.Size = new Size(168, 23);
            Jumlah_Anggota_KeluargaLN.TabIndex = 17;
            Jumlah_Anggota_KeluargaLN.TextChanged += Jumlah_Anggota_Keluarga_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 232);
            label8.Name = "label8";
            label8.Size = new Size(112, 15);
            label8.TabIndex = 19;
            label8.Text = "Kode-Nama Negara";
            // 
            // Kode_Nama_NegaraLN
            // 
            Kode_Nama_NegaraLN.Location = new Point(236, 230);
            Kode_Nama_NegaraLN.Margin = new Padding(3, 2, 3, 2);
            Kode_Nama_NegaraLN.Name = "Kode_Nama_NegaraLN";
            Kode_Nama_NegaraLN.Size = new Size(412, 23);
            Kode_Nama_NegaraLN.TabIndex = 20;
            Kode_Nama_NegaraLN.TextChanged += Kode_Nama_Negara_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 266);
            label9.Name = "label9";
            label9.Size = new Size(144, 15);
            label9.TabIndex = 22;
            label9.Text = "Kode-Nama Perwakilan RI";
            // 
            // Kode_Nama_Perwakilan_RILN
            // 
            Kode_Nama_Perwakilan_RILN.Location = new Point(236, 264);
            Kode_Nama_Perwakilan_RILN.Margin = new Padding(3, 2, 3, 2);
            Kode_Nama_Perwakilan_RILN.Name = "Kode_Nama_Perwakilan_RILN";
            Kode_Nama_Perwakilan_RILN.Size = new Size(412, 23);
            Kode_Nama_Perwakilan_RILN.TabIndex = 23;
            Kode_Nama_Perwakilan_RILN.TextChanged += Kode_Nama_Perwakilan_RI_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 167);
            label10.Name = "label10";
            label10.Size = new Size(116, 15);
            label10.TabIndex = 25;
            label10.Text = "Telepon/Handphone";
            // 
            // TeleponLN
            // 
            TeleponLN.Location = new Point(163, 165);
            TeleponLN.Margin = new Padding(3, 2, 3, 2);
            TeleponLN.Name = "TeleponLN";
            TeleponLN.Size = new Size(485, 23);
            TeleponLN.TabIndex = 26;
            TeleponLN.TextChanged += Telepon_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 202);
            label11.Name = "label11";
            label11.Size = new Size(36, 15);
            label11.TabIndex = 28;
            label11.Text = "Email";
            // 
            // EmailLN
            // 
            EmailLN.Location = new Point(236, 200);
            EmailLN.Margin = new Padding(3, 2, 3, 2);
            EmailLN.Name = "EmailLN";
            EmailLN.Size = new Size(412, 23);
            EmailLN.TabIndex = 29;
            EmailLN.TextChanged += Email_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(318, 318);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 30;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Data_Alamat_WNI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Data_Alamat_WNI";
            Text = "Data Alamat WNI";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AlamatLN;
        private System.Windows.Forms.TextBox KotaLN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProvinsiLN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NegaraLN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Kode_PosLN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Jumlah_Anggota_KeluargaLN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Kode_Nama_NegaraLN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Kode_Nama_Perwakilan_RILN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TeleponLN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox EmailLN;
        private System.Windows.Forms.Label label11;
        private Button button1;
    }
}
