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
            tableLayoutPanel1.Margin = new Padding(5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(485, 375);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(5, 95);
            textBox1.Margin = new Padding(5);
            textBox1.MaxLength = 4;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 27);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox_TextChanged;
            textBox1.KeyPress += textBox_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(126, 95);
            textBox2.Margin = new Padding(5);
            textBox2.MaxLength = 4;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(111, 27);
            textBox2.TabIndex = 1;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox_TextChanged;
            textBox2.KeyPress += textBox_KeyPress;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(247, 95);
            textBox3.Margin = new Padding(5);
            textBox3.MaxLength = 4;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(111, 27);
            textBox3.TabIndex = 2;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox_TextChanged;
            textBox3.KeyPress += textBox_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(368, 95);
            textBox4.Margin = new Padding(5);
            textBox4.MaxLength = 4;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(112, 27);
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
            labelKK.Location = new Point(5, 45);
            labelKK.Margin = new Padding(5, 0, 5, 0);
            labelKK.Name = "labelKK";
            labelKK.Size = new Size(475, 45);
            labelKK.TabIndex = 10;
            labelKK.Text = "Masukkan Nomor Kartu Keluarga:";
            labelKK.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            tableLayoutPanel1.SetColumnSpan(searchButton, 2);
            searchButton.Dock = DockStyle.Fill;
            searchButton.Location = new Point(126, 140);
            searchButton.Margin = new Padding(5);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(232, 35);
            searchButton.TabIndex = 8;
            searchButton.Text = "Cari";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // addKKButton
            // 
            tableLayoutPanel1.SetColumnSpan(addKKButton, 2);
            addKKButton.Dock = DockStyle.Fill;
            addKKButton.Location = new Point(126, 230);
            addKKButton.Margin = new Padding(5);
            addKKButton.Name = "addKKButton";
            addKKButton.Size = new Size(232, 35);
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
            titleLabel.Location = new Point(5, 0);
            titleLabel.Margin = new Padding(5, 0, 5, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(475, 45);
            titleLabel.TabIndex = 12;
            titleLabel.Text = "Manajemen Kartu Keluarga";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 375);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5);
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
