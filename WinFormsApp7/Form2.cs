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
                    worksheet.Cells[$"AB{78 + i}"].Value = SafeGetCellValue("Tanggal_Lahir");
                    worksheet.Cells[$"AK{78 + i}"].Value = SafeGetCellValue("Kewarganegaraan");
                    worksheet.Cells[$"AR{78 + i}"].Value = SafeGetCellValue("No_SK_Penetapan_WNI");
                    worksheet.Cells[$"AY{78 + i}"].Value = SafeGetCellValue("Akta_Lahir");
                    worksheet.Cells[$"B{98 + i}"].Value = SafeGetCellValue("Nomor_Akta_Kelahiran");
                    worksheet.Cells[$"I{98 + i}"].Value = SafeGetCellValue("Golongan_Darah");
                    worksheet.Cells[$"M{98 + i}"].Value = SafeGetCellValue("Agama");
                    worksheet.Cells[$"Q{98 + i}"].Value = SafeGetCellValue("Nama_Organisasi_Kepercayaan");
                    worksheet.Cells[$"AD{98 + i}"].Value = SafeGetCellValue("Status_Perkawinan");
                    worksheet.Cells[$"AK{98 + i}"].Value = SafeGetCellValue("Akta_Perkawinan");
                    worksheet.Cells[$"AK{98 + i}"].Value = SafeGetCellValue("Nomor_Akta_Perkawinan");
                    worksheet.Cells[$"AY{98 + i}"].Value = SafeGetCellValue("Tanggal_Perkawinan");
                    worksheet.Cells[$"B{112 + i}"].Value = SafeGetCellValue("Akta_Cerai");
                    worksheet.Cells[$"E{112 + i}"].Value = SafeGetCellValue("Nomor_Akta_Cerai");
                    worksheet.Cells[$"J{112 + i}"].Value = SafeGetCellValue("Tanggal_Perceraian");
                    worksheet.Cells[$"M{112 + i}"].Value = SafeGetCellValue("Status_Hubungan_Dalam_Keluarga");
                    worksheet.Cells[$"T{112 + i}"].Value = SafeGetCellValue("Kelainan_Fisik_dan_Mental");
                    worksheet.Cells[$"AA{112 + i}"].Value = SafeGetCellValue("Penyandang_Cacat");
                    worksheet.Cells[$"AF{112 + i}"].Value = SafeGetCellValue("Pendidikan_Terakhir");
                    worksheet.Cells[$"AK{112 + i}"].Value = SafeGetCellValue("Jenis_Pekerjaan");
                    worksheet.Cells[$"AO{112 + i}"].Value = SafeGetCellValue("Nomor_ITAS_ITAP");
                    worksheet.Cells[$"AV{112 + i}"].Value = SafeGetCellValue("Tanggal_Terbit_ITAS_ITAP");
                    worksheet.Cells[$"B{126 + i}"].Value = SafeGetCellValue("Tanggal_Terbit_ITAS_ITAP");
                    worksheet.Cells[$"G{126 + i}"].Value = SafeGetCellValue("Tanggal_Akhir_ITAS_ITAP");
                    worksheet.Cells[$"K{126 + i}"].Value = SafeGetCellValue("Tempat_Datang_Pertama");
                    worksheet.Cells[$"S{126 + i}"].Value = SafeGetCellValue("Tanggal_Kedatangan_Pertama");
                    worksheet.Cells[$"Z{126 + i}"].Value = SafeGetCellValue("NIK_Ibu");
                    worksheet.Cells[$"AG{126 + i}"].Value = SafeGetCellValue("Nama_Ibu");
                    worksheet.Cells[$"AO{126 + i}"].Value = SafeGetCellValue("NIK_Ayah");
                    worksheet.Cells[$"AU{126 + i}"].Value = SafeGetCellValue("Nama_Ayah");

                    // New fields
                    // Alamat
                    worksheet.Cells[$"S{14 + i}"].Value = SafeGetCellValue("nama_kepala_keluarga");

                    worksheet.Cells[$"S{16 + i}"].Value = SafeGetCellValue("alamat");

                    // RT split
                    var rt = SafeGetCellValue("rt").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rt.Length > 0) worksheet.Cells[$"AB{20}"].Value = rt[0];
                    if (rt.Length > 1) worksheet.Cells[$"AC{20}"].Value = rt[1];
                    if (rt.Length > 2) worksheet.Cells[$"AD{20}"].Value = rt[2];

                    // RW split
                    var rw = SafeGetCellValue("rw").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (rw.Length > 0) worksheet.Cells[$"AI{20}"].Value = rw[0];
                    if (rw.Length > 1) worksheet.Cells[$"AJ{20}"].Value = rw[1];
                    if (rw.Length > 2) worksheet.Cells[$"AK{20}"].Value = rw[2];

                    // Jumlah Anggota Keluarga split
                    var jumlahAnggotaKeluarga = SafeGetCellValue("jumlah_anggota_keluarga").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (jumlahAnggotaKeluarga.Length > 0) worksheet.Cells[$"AX{20}"].Value = jumlahAnggotaKeluarga[0];
                    if (jumlahAnggotaKeluarga.Length > 1) worksheet.Cells[$"AY{20}"].Value = jumlahAnggotaKeluarga[1];
                    if (jumlahAnggotaKeluarga.Length > 2) worksheet.Cells[$"AZ{20}"].Value = jumlahAnggotaKeluarga[2];

                    // Telepon
                    worksheet.Cells[$"S{22 + i}"].Value = SafeGetCellValue("telepon");

                    // Email
                    worksheet.Cells[$"S{24 + i}"].Value = SafeGetCellValue("email");

                    // Kode Desa split
                    var kodeDesa = SafeGetCellValue("kode_desa").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (kodeDesa.Length > 0) worksheet.Cells[$"S{33}"].Value = kodeDesa[0];
                    if (kodeDesa.Length > 1) worksheet.Cells[$"T{33}"].Value = kodeDesa[1];

                    // Nama Dusun
                    worksheet.Cells[$"S{35}"].Value = SafeGetCellValue("nama_dusun");

                    // Alamat Luar Negeri
                    worksheet.Cells[$"N{37}"].Value = SafeGetCellValue("alamat_luar_negeri");

                    // Kota Luar Negeri
                    worksheet.Cells[$"N{39}"].Value = SafeGetCellValue("kota_luar_negeri");

                    // Provinsi Negara Bagian Luar Negeri
                    worksheet.Cells[$"AL{39}"].Value = SafeGetCellValue("provinsi_negara_bagian_luar_negeri");

                    // Negara
                    worksheet.Cells[$"N{41}"].Value = SafeGetCellValue("negara_luar_negeri");

                    // Kode Pos
                    worksheet.Cells[$"S{43}"].Value = SafeGetCellValue("kode_pos_luar_negeri");
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
