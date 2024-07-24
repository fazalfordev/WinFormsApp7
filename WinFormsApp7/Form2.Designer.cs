namespace WinFormsApp7
{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            deleteRowButton = new Button();
            saveButton = new Button();
            printButton = new Button();
            tambahBarisButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.LightSteelBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.ActiveCaption;
            dataGridView1.Location = new Point(192, 105);
            dataGridView1.Margin = new Padding(6, 5, 6, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1293, 712);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // deleteRowButton
            // 
            deleteRowButton.BackgroundImage = Properties.Resources.Cuplikan_layar_2024_07_24_133814;
            deleteRowButton.Location = new Point(379, 859);
            deleteRowButton.Margin = new Padding(6, 5, 6, 5);
            deleteRowButton.Name = "deleteRowButton";
            deleteRowButton.Size = new Size(126, 45);
            deleteRowButton.TabIndex = 1;
            deleteRowButton.Text = "Hapus Baris";
            deleteRowButton.UseVisualStyleBackColor = true;
            deleteRowButton.Click += deleteRowButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackgroundImage = Properties.Resources.Cuplikan_layar_2024_07_24_133814;
            saveButton.Location = new Point(517, 859);
            saveButton.Margin = new Padding(6, 5, 6, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(126, 45);
            saveButton.TabIndex = 2;
            saveButton.Text = "Simpan Perubahan";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // printButton
            // 
            printButton.BackgroundImage = Properties.Resources.Cuplikan_layar_2024_07_24_133814;
            printButton.Location = new Point(655, 859);
            printButton.Margin = new Padding(6, 5, 6, 5);
            printButton.Name = "printButton";
            printButton.Size = new Size(126, 45);
            printButton.TabIndex = 3;
            printButton.Text = "Print";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += printButton_Click;
            // 
            // tambahBarisButton
            // 
            tambahBarisButton.BackgroundImage = Properties.Resources.Cuplikan_layar_2024_07_24_133814;
            tambahBarisButton.BackgroundImageLayout = ImageLayout.Stretch;
            tambahBarisButton.Location = new Point(192, 859);
            tambahBarisButton.Margin = new Padding(6, 5, 6, 5);
            tambahBarisButton.Name = "tambahBarisButton";
            tambahBarisButton.Size = new Size(171, 45);
            tambahBarisButton.TabIndex = 4;
            tambahBarisButton.Text = "Tambah Baris";
            tambahBarisButton.UseVisualStyleBackColor = true;
            tambahBarisButton.Click += tambahBarisButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            BackgroundImage = Properties.Resources.Descargar_Fondo_de_diseño_hexagonal_azul_claro_geométrico_abstracto__gratis;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1714, 949);
            Controls.Add(tambahBarisButton);
            Controls.Add(printButton);
            Controls.Add(saveButton);
            Controls.Add(deleteRowButton);
            Controls.Add(dataGridView1);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button deleteRowButton;
        private Button saveButton;
        private Button printButton;
        private Button tambahBarisButton;
    }
}
