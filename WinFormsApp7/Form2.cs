using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormsApp7
{
    public partial class Form2 : Form
    {
        private string connectionString;
        private string nomorKK;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private MySqlConnection connection;

        public Form2(string nomorKK, string connectionString)
        {
            InitializeComponent();
            this.nomorKK = nomorKK;
            this.connectionString = connectionString;
            this.connection = new MySqlConnection(connectionString);
            LoadData();
            dataGridView1.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void LoadData()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM gabungan_keluarga WHERE Nomor_KK = @NomorKK ORDER BY CASE WHEN NIK IS NULL OR NIK = '' THEN 1 ELSE 0 END, NIK ASC";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomorKK", nomorKK);

                dataAdapter = new MySqlDataAdapter(command);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Set DataGridView to display cells with full content
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Add delete button column if not already present
                if (dataGridView1.Columns["deleteButton"] == null)
                {
                    DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
                    {
                        Name = "deleteButton",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView1.Columns.Add(deleteButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    connection.Open();
                    MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    dataAdapter.Update(dataTable);
                    MessageBox.Show("Perubahan berhasil disimpan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Nomor_KK"].Value = nomorKK;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["deleteButton"].Index && e.RowIndex >= 0)
            {
                deleteRowButton_Click(sender, e);
            }
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    connection.Open();
                    string nik = dataGridView1.CurrentRow.Cells["NIK"].Value.ToString();
                    string query = "DELETE FROM gabungan_keluarga WHERE NIK = @nik";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nik", nik);
                    command.ExecuteNonQuery();

                    dataTable.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    dataAdapter.Update(dataTable);
                    MessageBox.Show("Data berhasil dihapus.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Pilih baris yang ingin dihapus terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                dataAdapter.Update(dataTable);
                MessageBox.Show("Perubahan berhasil disimpan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Silahkan load data excel FI.01 Form KK", "Load Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Pilih file FI.01 Form KK",
                FileName = "FI.01 Form KK"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string newFilePath = SaveDataGridViewToExcel(filePath);
                    string pdfFilePath = Path.ChangeExtension(newFilePath, ".pdf");
                    ConvertExcelToPdf(newFilePath, pdfFilePath);
                    MessageBox.Show("File berhasil disimpan sebagai PDF.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string SaveDataGridViewToExcel(string filePath)
        {
            string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_updated" + Path.GetExtension(filePath));

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                for (int i = 0; i < dataGridView1.Rows.Count && i < 10; i++)
                {
                    worksheet.Cells[$"B{64 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Lengkap"].Value?.ToString();
                    worksheet.Cells[$"S{64 + i}"].Value = dataGridView1.Rows[i].Cells["Gelar_Depan"].Value?.ToString();
                    worksheet.Cells[$"W{64 + i}"].Value = dataGridView1.Rows[i].Cells["Gelar_Belakang"].Value?.ToString();
                    worksheet.Cells[$"AA{64 + i}"].Value = dataGridView1.Rows[i].Cells["Passport_Number"].Value?.ToString();
                    worksheet.Cells[$"AH{64 + i}"].Value = dataGridView1.Rows[i].Cells["Tgl_Berakhir_Paspor"].Value?.ToString();
                    worksheet.Cells[$"AP{64 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Sponsor"].Value?.ToString();
                    worksheet.Cells[$"B{78 + i}"].Value = dataGridView1.Rows[i].Cells["Tipe_Sponsor"].Value?.ToString();
                    worksheet.Cells[$"G{78 + i}"].Value = dataGridView1.Rows[i].Cells["Alamat_Sponsor"].Value?.ToString();
                    worksheet.Cells[$"O{78 + i}"].Value = dataGridView1.Rows[i].Cells["Jenis_Kelamin"].Value?.ToString();
                    worksheet.Cells[$"U{78 + i}"].Value = dataGridView1.Rows[i].Cells["Tempat_Lahir"].Value?.ToString();
                    worksheet.Cells[$"AB{78 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Lahir"].Value?.ToString();
                    worksheet.Cells[$"AK{78 + i}"].Value = dataGridView1.Rows[i].Cells["Kewarganegaraan"].Value?.ToString();
                    worksheet.Cells[$"AR{78 + i}"].Value = dataGridView1.Rows[i].Cells["No_SK_Penetapan_WNI"].Value?.ToString();
                    worksheet.Cells[$"AY{78 + i}"].Value = dataGridView1.Rows[i].Cells["Akta_Lahir"].Value?.ToString();
                    worksheet.Cells[$"B{98 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_Akta_Kelahiran"].Value?.ToString();
                    worksheet.Cells[$"I{98 + i}"].Value = dataGridView1.Rows[i].Cells["Golongan_Darah"].Value?.ToString();
                    worksheet.Cells[$"M{98 + i}"].Value = dataGridView1.Rows[i].Cells["Agama"].Value?.ToString();
                    worksheet.Cells[$"Q{98 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Organisasi_Kepercayaan"].Value?.ToString();
                    worksheet.Cells[$"AD{98 + i}"].Value = dataGridView1.Rows[i].Cells["Status_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"AK{98 + i}"].Value = dataGridView1.Rows[i].Cells["Akta_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"AK{98 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_Akta_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"AY{98 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"B{112 + i}"].Value = dataGridView1.Rows[i].Cells["Akta_Cerai"].Value?.ToString();
                    worksheet.Cells[$"E{112 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_Akta_Cerai"].Value?.ToString();
                    worksheet.Cells[$"J{112 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Perceraian"].Value?.ToString();
                    worksheet.Cells[$"M{112 + i}"].Value = dataGridView1.Rows[i].Cells["Status_Hubungan_Dalam_Keluarga"].Value?.ToString();
                    worksheet.Cells[$"T{112 + i}"].Value = dataGridView1.Rows[i].Cells["Kelainan_Fisik_dan_Mental"].Value?.ToString();
                    worksheet.Cells[$"AA{112 + i}"].Value = dataGridView1.Rows[i].Cells["Penyandang_Cacat"].Value?.ToString();
                    worksheet.Cells[$"AF{112 + i}"].Value = dataGridView1.Rows[i].Cells["Pendidikan_Terakhir"].Value?.ToString();
                    worksheet.Cells[$"AK{112 + i}"].Value = dataGridView1.Rows[i].Cells["Jenis_Pekerjaan"].Value?.ToString();
                    worksheet.Cells[$"AO{112 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_ITAS_ITAP"].Value?.ToString();
                    worksheet.Cells[$"AV{112 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Terbit_ITAS_ITAP"].Value?.ToString();
                    worksheet.Cells[$"B{126 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Terbit_ITAS_ITAP"].Value?.ToString();
                    worksheet.Cells[$"G{126 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Akhir_ITAS_ITAP"].Value?.ToString();
                    worksheet.Cells[$"K{126 + i}"].Value = dataGridView1.Rows[i].Cells["Tempat_Datang_Pertama"].Value?.ToString();
                    worksheet.Cells[$"S{126 + i}"].Value = dataGridView1.Rows[i].Cells["Tanggal_Kedatangan_Pertama"].Value?.ToString();
                    worksheet.Cells[$"Z{126 + i}"].Value = dataGridView1.Rows[i].Cells["NIK_Ibu"].Value?.ToString();
                    worksheet.Cells[$"AG{126 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Ibu"].Value?.ToString();
                    worksheet.Cells[$"AO{126 + i}"].Value = dataGridView1.Rows[i].Cells["NIK_Ayah"].Value?.ToString();
                    worksheet.Cells[$"AU{126 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Ayah"].Value?.ToString();
                }

                package.SaveAs(new FileInfo(newFilePath));
            }

            return newFilePath;
        }


        private void ConvertExcelToPdf(string excelFilePath, string pdfFilePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);

            try
            {
                workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfFilePath);
            }
            finally
            {
                workbook.Close(false);
                excelApp.Quit();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
