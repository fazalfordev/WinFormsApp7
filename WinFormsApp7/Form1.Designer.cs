namespace WinFormsApp7
{
    partial class Form1
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

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            labelKK = new Label();
            searchButton = new Button();
            addKKButton = new Button();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(255, 255, 192);
            textBox1.Location = new Point(525, 419);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 31);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox_TextChanged;
            textBox1.KeyPress += textBox_KeyPress;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(255, 255, 192);
            textBox2.Location = new Point(783, 419);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(240, 31);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox_TextChanged;
            textBox2.KeyPress += textBox_KeyPress;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(255, 255, 192);
            textBox3.Location = new Point(1049, 419);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(234, 31);
            textBox3.TabIndex = 2;
            textBox3.TextChanged += textBox_TextChanged;
            textBox3.KeyPress += textBox_KeyPress;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(255, 255, 192);
            textBox4.Location = new Point(1311, 419);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(239, 31);
            textBox4.TabIndex = 3;
            textBox4.TextChanged += textBox_TextChanged;
            textBox4.KeyPress += textBox_KeyPress;
            // 
            // labelKK
            // 
            labelKK.AutoSize = true;
            labelKK.BackColor = Color.Transparent;
            labelKK.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelKK.ForeColor = Color.Navy;
            labelKK.Location = new Point(940, 354);
            labelKK.Name = "labelKK";
            labelKK.Size = new Size(364, 30);
            labelKK.TabIndex = 4;
            labelKK.Text = "Masukkan Nomor Kartu Keluarga:";
            // 
            // searchButton
            // 
            searchButton.ForeColor = Color.Black;
            searchButton.Image = Properties.Resources.button1;
            searchButton.Location = new Point(950, 537);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(174, 50);
            searchButton.TabIndex = 5;
            searchButton.Text = "Cari";
            searchButton.Click += searchButton_Click;
            // 
            // addKKButton
            // 
            addKKButton.ForeColor = Color.Black;
            addKKButton.Image = Properties.Resources.Cuplikan_layar_2024_07_24_133814;
            addKKButton.Location = new Point(1251, 537);
            addKKButton.Name = "addKKButton";
            addKKButton.Size = new Size(158, 50);
            addKKButton.TabIndex = 6;
            addKKButton.Text = "Tambah KK";
            addKKButton.Click += addKKButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Stencil", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.Navy;
            titleLabel.Location = new Point(783, 220);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(760, 57);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "Manajemen Kartu Keluarga";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            BackgroundImage = Properties.Resources.Pink_Gradient_Motivational_Desktop_Wallpaper;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1714, 949);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(labelKK);
            Controls.Add(searchButton);
            Controls.Add(addKKButton);
            Controls.Add(titleLabel);
            DoubleBuffered = true;
            Margin = new Padding(6, 7, 6, 7);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button addKKButton;
        private System.Windows.Forms.Label labelKK;
        private System.Windows.Forms.Label titleLabel;
    }
}

