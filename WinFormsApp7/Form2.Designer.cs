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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 14);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(905, 427);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // deleteRowButton
            // 
            deleteRowButton.Location = new Point(14, 448);
            deleteRowButton.Margin = new Padding(4, 3, 4, 3);
            deleteRowButton.Name = "deleteRowButton";
            deleteRowButton.Size = new Size(88, 27);
            deleteRowButton.TabIndex = 1;
            deleteRowButton.Text = "Hapus Baris";
            deleteRowButton.UseVisualStyleBackColor = true;
            deleteRowButton.Click += deleteRowButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(108, 448);
            saveButton.Margin = new Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(88, 27);
            saveButton.TabIndex = 2;
            saveButton.Text = "Simpan Perubahan";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // printButton
            // 
            printButton.Location = new Point(203, 448);
            printButton.Margin = new Padding(4, 3, 4, 3);
            printButton.Name = "printButton";
            printButton.Size = new Size(88, 27);
            printButton.TabIndex = 3;
            printButton.Text = "Print";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += printButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(printButton);
            Controls.Add(saveButton);
            Controls.Add(deleteRowButton);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button printButton;
    }
}
