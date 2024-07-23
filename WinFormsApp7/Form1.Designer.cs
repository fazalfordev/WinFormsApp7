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
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            labelKK = new Label();
            searchButton = new Button();
            addKKButton = new Button();
            titleLabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(textBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 2);
            tableLayoutPanel1.Controls.Add(textBox3, 2, 2);
            tableLayoutPanel1.Controls.Add(textBox4, 3, 2);
            tableLayoutPanel1.Controls.Add(labelKK, 0, 1);
            tableLayoutPanel1.Controls.Add(searchButton, 1, 3);
            tableLayoutPanel1.Controls.Add(addKKButton, 1, 5);
            tableLayoutPanel1.Controls.Add(titleLabel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new Size(424, 281);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(4, 72);
            textBox1.Margin = new Padding(4);
            textBox1.MaxLength = 4;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(98, 23);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox_TextChanged;
            textBox1.KeyPress += textBox_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(110, 72);
            textBox2.Margin = new Padding(4);
            textBox2.MaxLength = 4;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(98, 23);
            textBox2.TabIndex = 1;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox_TextChanged;
            textBox2.KeyPress += textBox_KeyPress;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(216, 72);
            textBox3.Margin = new Padding(4);
            textBox3.MaxLength = 4;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(98, 23);
            textBox3.TabIndex = 2;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox_TextChanged;
            textBox3.KeyPress += textBox_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(322, 72);
            textBox4.Margin = new Padding(4);
            textBox4.MaxLength = 4;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(98, 23);
            textBox4.TabIndex = 3;
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox4.TextChanged += textBox_TextChanged;
            textBox4.KeyPress += textBox_KeyPress;
            // 
            // labelKK
            // 
            labelKK.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(labelKK, 4);
            labelKK.Dock = DockStyle.Fill;
            labelKK.Location = new Point(4, 34);
            labelKK.Margin = new Padding(4, 0, 4, 0);
            labelKK.Name = "labelKK";
            labelKK.Size = new Size(416, 34);
            labelKK.TabIndex = 10;
            labelKK.Text = "Masukkan Nomor Kartu Keluarga:";
            labelKK.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            tableLayoutPanel1.SetColumnSpan(searchButton, 2);
            searchButton.Dock = DockStyle.Fill;
            searchButton.Location = new Point(110, 106);
            searchButton.Margin = new Padding(4);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(204, 26);
            searchButton.TabIndex = 8;
            searchButton.Text = "Cari";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // addKKButton
            // 
            tableLayoutPanel1.SetColumnSpan(addKKButton, 2);
            addKKButton.Dock = DockStyle.Fill;
            addKKButton.Location = new Point(110, 174);
            addKKButton.Margin = new Padding(4);
            addKKButton.Name = "addKKButton";
            addKKButton.Size = new Size(204, 26);
            addKKButton.TabIndex = 9;
            addKKButton.Text = "Tambah KK";
            addKKButton.UseVisualStyleBackColor = true;
            addKKButton.Click += addKKButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(titleLabel, 4);
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(4, 0);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(416, 34);
            titleLabel.TabIndex = 12;
            titleLabel.Text = "Manajemen Kartu Keluarga";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 281);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
