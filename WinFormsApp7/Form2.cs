using System;
using System.Data;
using System.Drawing;
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

                // Disable the automatic new row
                dataGridView1.AllowUserToAddRows = false;

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
                    var row = dataGridView1.Rows[i];
                    if (row == null) continue; // Skip null rows

                    // Helper function to safely get cell value
                    string SafeGetCellValue(string columnName)
                    {
                        var cell = row.Cells[columnName];
                        return cell?.Value?.ToString() ?? " ";
                    }

                    // Existing fields
                    worksheet.Cells[$"B{64 + i}"].Value = SafeGetCellValue("Nama_Lengkap");
                    worksheet.Cells[$"S{64 + i}"].Value = SafeGetCellValue("Gelar_Depan");
                    worksheet.Cells[$"W{64 + i}"].Value = SafeGetCellValue("Gelar_Belakang");
                    worksheet.Cells[$"AA{64 + i}"].Value = SafeGetCellValue("Passport_Number");
                    worksheet.Cells[$"AH{64 + i}"].Value = SafeGetCellValue("Tgl_Berakhir_Paspor");
                    worksheet.Cells[$"AP{64 + i}"].Value = SafeGetCellValue("Nama_Sponsor");
                    worksheet.Cells[$"B{78 + i}"].Value = SafeGetCellValue("Tipe_Sponsor");
                    worksheet.Cells[$"G{78 + i}"].Value = SafeGetCellValue("Alamat_Sponsor");
                    worksheet.Cells[$"O{78 + i}"].Value = SafeGetCellValue("Jenis_Kelamin");
                    worksheet.Cells[$"U{78 + i}"].Value = SafeGetCellValue("Tempat_Lahir");
                    worksheet.Cells[$"AB{78 + i}"].Value = SafeGetCellValue("Tgl_Lahir");
                    worksheet.Cells[$"AM{78 + i}"].Value = SafeGetCellValue("Agama");
                    worksheet.Cells[$"AR{78 + i}"].Value = SafeGetCellValue("Kepercayaan_Tuhan_YME");
                    worksheet.Cells[$"AW{78 + i}"].Value = SafeGetCellValue("Status_Perkawinan");
                    worksheet.Cells[$"BB{78 + i}"].Value = SafeGetCellValue("Tgl_Perkawinan");
                    worksheet.Cells[$"BG{78 + i}"].Value = SafeGetCellValue("Akta_Perkawinan");
                    worksheet.Cells[$"BL{78 + i}"].Value = SafeGetCellValue("Nomor_Akta_Perkawinan");
                    worksheet.Cells[$"BQ{78 + i}"].Value = SafeGetCellValue("Akta_Perceraian");
                    worksheet.Cells[$"BV{78 + i}"].Value = SafeGetCellValue("Nomor_Akta_Perceraian");
                    worksheet.Cells[$"CA{78 + i}"].Value = SafeGetCellValue("Tanggal_Perceraian");
                    worksheet.Cells[$"CH{78 + i}"].Value = SafeGetCellValue("Status_Hubungan");
                    worksheet.Cells[$"CP{78 + i}"].Value = SafeGetCellValue("Kelainan_Fisik");
                    worksheet.Cells[$"CU{78 + i}"].Value = SafeGetCellValue("Penyandang_Cacat");
                    worksheet.Cells[$"B{92 + i}"].Value = SafeGetCellValue("Pendidikan_Terakhir");
                    worksheet.Cells[$"H{92 + i}"].Value = SafeGetCellValue("Pekerjaan");

                    // Additional fields
                    worksheet.Cells[$"O{92 + i}"].Value = SafeGetCellValue("NIK_Ayah");
                    worksheet.Cells[$"U{92 + i}"].Value = SafeGetCellValue("Nama_Ayah");
                    worksheet.Cells[$"AD{92 + i}"].Value = SafeGetCellValue("NIK_Ibu");
                    worksheet.Cells[$"AJ{92 + i}"].Value = SafeGetCellValue("Nama_Ibu");
                    worksheet.Cells[$"AS{92 + i}"].Value = SafeGetCellValue("No_Akta_Lahir");
                    worksheet.Cells[$"AZ{92 + i}"].Value = SafeGetCellValue("Gol_Darah");
                    worksheet.Cells[$"BE{92 + i}"].Value = SafeGetCellValue("Jenis_Dokumen_Imigrasi");
                    worksheet.Cells[$"BJ{92 + i}"].Value = SafeGetCellValue("No_Dokumen_Imigrasi");
                    worksheet.Cells[$"BP{92 + i}"].Value = SafeGetCellValue("Tanggal_Terbit_Dokumen");
                    worksheet.Cells[$"BY{92 + i}"].Value = SafeGetCellValue("Tempat_Terbit_Dokumen");
                    worksheet.Cells[$"CF{92 + i}"].Value = SafeGetCellValue("Nomor_KITAS");
                    worksheet.Cells[$"CL{92 + i}"].Value = SafeGetCellValue("Nomor_KITAP");
                    worksheet.Cells[$"B{106 + i}"].Value = SafeGetCellValue("NIK");
                    worksheet.Cells[$"J{106 + i}"].Value = SafeGetCellValue("Nama_Lengkap");
                    worksheet.Cells[$"AA{106 + i}"].Value = SafeGetCellValue("Nomor_Akta_Lahir");
                }

                package.SaveAs(new FileInfo(newFilePath));
            }

            return newFilePath;
        }

        private void ConvertExcelToPdf(string excelFilePath, string pdfFilePath)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, pdfFilePath);

            workbook.Close(false);
            excelApp.Quit();

            ReleaseObject(workbook);
            ReleaseObject(excelApp);
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void tambahBarisButton_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataTable.NewRow();
            newRow["Nomor_KK"] = nomorKK; // Set Nomor_KK for new row
            dataTable.Rows.Add(newRow);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click events if needed
        }
    }
}
