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

        private void Numeric_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.Text.Length > 16)
            {
                tb.Text = tb.Text.Substring(0, 16); // Trim the text to 16 characters if it exceeds the limit
                tb.SelectionStart = tb.Text.Length; // Set the cursor to the end of the text
            }
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true; // Suppress the key press if it's not a digit or control key

            if (tb != null && tb.Text.Length >= 16 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press if the length exceeds 16 characters
            }
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

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                DataGridViewComboBoxColumn comboagamaColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Agama",
                    HeaderText = "Agama",
                    DataPropertyName = "Agama",
                    DataSource = new string[] { "Islam", "Kristen", "Katholik", "Hindu", "Budha", "KongHucu" }
                };
                int genderagamaIndex = dataGridView1.Columns["Agama"].Index;
                dataGridView1.Columns.RemoveAt(genderagamaIndex);
                dataGridView1.Columns.Insert(genderagamaIndex, comboagamaColumn);

                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Jenis_Kelamin",
                    HeaderText = "Jenis Kelamin",
                    DataPropertyName = "Jenis_Kelamin",
                    DataSource = new string[] { "Laki-laki", "Perempuan" }
                };
                int genderColumnIndex = dataGridView1.Columns["Jenis_Kelamin"].Index;
                dataGridView1.Columns.RemoveAt(genderColumnIndex);
                dataGridView1.Columns.Insert(genderColumnIndex, comboBoxColumn);

                DataGridViewCalendarColumn birthdate = new DataGridViewCalendarColumn
                {
                    Name = "Tanggal_Lahir",
                    HeaderText = "Tanggal Lahir",
                    DataPropertyName = "Tanggal_Lahir"
                };
                int birthdateColumnIndex = dataGridView1.Columns["Tanggal_Lahir"].Index;
                dataGridView1.Columns.RemoveAt(birthdateColumnIndex);
                dataGridView1.Columns.Insert(birthdateColumnIndex, birthdate);

                DataGridViewCalendarColumn paspor = new DataGridViewCalendarColumn
                {
                    Name = "Tgl_Berakhir_Paspor",
                    HeaderText = "Tgl_Berakhir_Paspor",
                    DataPropertyName = "Tgl_Berakhir_Paspor"
                };
                int pasporColumnIndex = dataGridView1.Columns["Tgl_Berakhir_Paspor"].Index;
                dataGridView1.Columns.RemoveAt(pasporColumnIndex);
                dataGridView1.Columns.Insert(pasporColumnIndex, paspor);

                DataGridViewCalendarColumn kawin = new DataGridViewCalendarColumn
                {
                    Name = "Tanggal_Perkawinan",
                    HeaderText = "Tanggal_Perkawinan",
                    DataPropertyName = "Tanggal_Perkawinan"
                };
                int kawinColumnIndex = dataGridView1.Columns["Tanggal_Perkawinan"].Index;
                dataGridView1.Columns.RemoveAt(kawinColumnIndex);
                dataGridView1.Columns.Insert(kawinColumnIndex, kawin);

                DataGridViewCalendarColumn cerai = new DataGridViewCalendarColumn
                {
                    Name = "Tanggal_Perceraian",
                    HeaderText = "Tanggal_Perceraian",
                    DataPropertyName = "Tanggal_Perceraian"
                };
                int ceraiColumnIndex = dataGridView1.Columns["Tanggal_Perceraian"].Index;
                dataGridView1.Columns.RemoveAt(ceraiColumnIndex);
                dataGridView1.Columns.Insert(ceraiColumnIndex, cerai);

                DataGridViewCalendarColumn terbitItasItap = new DataGridViewCalendarColumn
                {
                    Name = "Tanggal_Terbit_ITAS_ITAP",
                    HeaderText = "Tanggal_Terbit_ITAS_ITAP",
                    DataPropertyName = "Tanggal_Terbit_ITAS_ITAP"
                };
                int terbitItasItapColumnIndex = dataGridView1.Columns["Tanggal_Terbit_ITAS_ITAP"].Index;
                dataGridView1.Columns.RemoveAt(terbitItasItapColumnIndex);
                dataGridView1.Columns.Insert(terbitItasItapColumnIndex, terbitItasItap);

                DataGridViewCalendarColumn akhirItasItap = new DataGridViewCalendarColumn
                {
                    Name = "Tanggal_Akhir_ITAS_ITAP",
                    HeaderText = "Tanggal_Akhir_ITAS_ITAP",
                    DataPropertyName = "Tanggal_Akhir_ITAS_ITAP"
                };
                int akhirItasItapColumnIndex = dataGridView1.Columns["Tanggal_Akhir_ITAS_ITAP"].Index;
                dataGridView1.Columns.RemoveAt(akhirItasItapColumnIndex);
                dataGridView1.Columns.Insert(akhirItasItapColumnIndex, akhirItasItap);

                DataGridViewCalendarColumn datang = new DataGridViewCalendarColumn
                {
                    Name = "Tanggal_Kedatangan_Pertama",
                    HeaderText = "Tanggal_Kedatangan_Pertama",
                    DataPropertyName = "Tanggal_Kedatangan_Pertama"
                };
                int datangColumnIndex = dataGridView1.Columns["Tanggal_Kedatangan_Pertama"].Index;
                dataGridView1.Columns.RemoveAt(datangColumnIndex);
                dataGridView1.Columns.Insert(datangColumnIndex, datang);
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
                dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["NIK"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
                    tb.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
                    tb.TextChanged -= new EventHandler(Numeric_TextChanged);
                    tb.TextChanged += new EventHandler(Numeric_TextChanged);
                }
            }
            else
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= new KeyPressEventHandler(Numeric_KeyPress);
                    tb.TextChanged -= new EventHandler(Numeric_TextChanged);
                }
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
            string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), $"FI.01 Form KK-{nomorKK}" + Path.GetExtension(filePath));

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                for (int i = 0; i < dataGridView1.Rows.Count && i < 10; i++)
                {
                    var row = dataGridView1.Rows[i];
                    if (row == null) continue; // Skip null rows

                    // Helper function to safely get cell value and format it
                    string SafeGetCellValue(string columnName)
                    {
                        var cell = row.Cells[columnName];
                        return cell?.Value?.ToString().ToUpper() ?? " ";
                    }

                    // Helper function to format date
                    string FormatDate(object date)
                    {
                        if (date is DateTime dateTime)
                            return dateTime.ToString("dd-MM-yyyy");
                        else if (DateTime.TryParse(date?.ToString(), out dateTime))
                            return dateTime.ToString("dd-MM-yyyy");
                        return " ";
                    }

                    worksheet.Cells[$"B{64 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Lengkap"].Value?.ToString();
                    worksheet.Cells[$"S{64 + i}"].Value = dataGridView1.Rows[i].Cells["Gelar_Depan"].Value?.ToString();
                    worksheet.Cells[$"W{64 + i}"].Value = dataGridView1.Rows[i].Cells["Gelar_Belakang"].Value?.ToString();
                    worksheet.Cells[$"AA{64 + i}"].Value = dataGridView1.Rows[i].Cells["Passport_Number"].Value?.ToString();
                    worksheet.Cells[$"AH{64 + i}"].Value = FormatDate(row.Cells["Tgl_Berakhir_Paspor"].Value);
                    worksheet.Cells[$"AP{64 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Sponsor"].Value?.ToString();
                    worksheet.Cells[$"B{78 + i}"].Value = dataGridView1.Rows[i].Cells["Tipe_Sponsor"].Value?.ToString();
                    worksheet.Cells[$"G{78 + i}"].Value = dataGridView1.Rows[i].Cells["Alamat_Sponsor"].Value?.ToString();
                    worksheet.Cells[$"O{78 + i}"].Value = dataGridView1.Rows[i].Cells["Jenis_Kelamin"].Value?.ToString();
                    worksheet.Cells[$"U{78 + i}"].Value = dataGridView1.Rows[i].Cells["Tempat_Lahir"].Value?.ToString();
                    worksheet.Cells[$"AB{78 + i}"].Value = FormatDate(row.Cells["Tanggal_Lahir"].Value);
                    worksheet.Cells[$"AK{78 + i}"].Value = dataGridView1.Rows[i].Cells["Kewarganegaraan"].Value?.ToString();
                    worksheet.Cells[$"AR{78 + i}"].Value = dataGridView1.Rows[i].Cells["No_SK_Penetapan_WNI"].Value?.ToString();
                    //worksheet.Cells[$"AY{78 + i}"].Value = dataGridView1.Rows[i].Cells["Akta_Lahir"].Value?.ToString();
                    worksheet.Cells[$"B{98 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_Akta_Kelahiran"].Value?.ToString();
                    worksheet.Cells[$"I{98 + i}"].Value = dataGridView1.Rows[i].Cells["Golongan_Darah"].Value?.ToString();
                    worksheet.Cells[$"M{98 + i}"].Value = dataGridView1.Rows[i].Cells["Agama"].Value?.ToString();
                    worksheet.Cells[$"Q{98 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Organisasi_Kepercayaan"].Value?.ToString();
                    worksheet.Cells[$"AD{98 + i}"].Value = dataGridView1.Rows[i].Cells["Status_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"AK{98 + i}"].Value = dataGridView1.Rows[i].Cells["Akta_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"AP{98 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_Akta_Perkawinan"].Value?.ToString();
                    worksheet.Cells[$"AY{98 + i}"].Value = FormatDate(row.Cells["Tanggal_Perkawinan"].Value);
                    worksheet.Cells[$"B{112 + i}"].Value = dataGridView1.Rows[i].Cells["Akta_Cerai"].Value?.ToString();
                    worksheet.Cells[$"E{112 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_Akta_Cerai"].Value?.ToString();
                    worksheet.Cells[$"J{112 + i}"].Value = FormatDate(row.Cells["Tanggal_Perceraian"].Value);
                    worksheet.Cells[$"M{112 + i}"].Value = dataGridView1.Rows[i].Cells["Status_Hubungan_Dalam_Keluarga"].Value?.ToString();
                    worksheet.Cells[$"T{112 + i}"].Value = dataGridView1.Rows[i].Cells["Kelainan_Fisik_dan_Mental"].Value?.ToString();
                    worksheet.Cells[$"AA{112 + i}"].Value = dataGridView1.Rows[i].Cells["Penyandang_Cacat"].Value?.ToString();
                    worksheet.Cells[$"AF{112 + i}"].Value = dataGridView1.Rows[i].Cells["Pendidikan_Terakhir"].Value?.ToString();
                    worksheet.Cells[$"AK{112 + i}"].Value = dataGridView1.Rows[i].Cells["Jenis_Pekerjaan"].Value?.ToString();
                    worksheet.Cells[$"AO{112 + i}"].Value = dataGridView1.Rows[i].Cells["Nomor_ITAS_ITAP"].Value?.ToString();
                    worksheet.Cells[$"AV{112 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Cells[$"B{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Cells[$"G{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Akhir_ITAS_ITAP"].Value);
                    worksheet.Cells[$"K{126 + i}"].Value = dataGridView1.Rows[i].Cells["Tempat_Datang_Pertama"].Value?.ToString();
                    worksheet.Cells[$"S{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Kedatangan_Pertama"].Value);
                    worksheet.Cells[$"Z{126 + i}"].Value = dataGridView1.Rows[i].Cells["NIK_Ibu"].Value?.ToString();
                    worksheet.Cells[$"AG{126 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Ibu"].Value?.ToString();
                    worksheet.Cells[$"AO{126 + i}"].Value = dataGridView1.Rows[i].Cells["NIK_Ayah"].Value?.ToString();
                    worksheet.Cells[$"AU{126 + i}"].Value = dataGridView1.Rows[i].Cells["Nama_Ayah"].Value?.ToString();
                    worksheet.Cells[$"B{64 + i}"].Value = SafeGetCellValue("Nama_Lengkap");
                    worksheet.Cells[$"S{64 + i}"].Value = SafeGetCellValue("Gelar_Depan");
                    worksheet.Cells[$"W{64 + i}"].Value = SafeGetCellValue("Gelar_Belakang");
                    worksheet.Cells[$"AA{64 + i}"].Value = SafeGetCellValue("Passport_Number");
                    worksheet.Cells[$"AH{64 + i}"].Value = FormatDate(row.Cells["Tgl_Berakhir_Paspor"].Value);
                    worksheet.Cells[$"AP{64 + i}"].Value = SafeGetCellValue("Nama_Sponsor");
                    worksheet.Cells[$"B{78 + i}"].Value = SafeGetCellValue("Tipe_Sponsor");
                    worksheet.Cells[$"G{78 + i}"].Value = SafeGetCellValue("Alamat_Sponsor");
                    worksheet.Cells[$"O{78 + i}"].Value = SafeGetCellValue("Jenis_Kelamin");
                    worksheet.Cells[$"U{78 + i}"].Value = SafeGetCellValue("Tempat_Lahir");
                    worksheet.Cells[$"AB{78 + i}"].Value = FormatDate(row.Cells["Tanggal_Lahir"].Value);
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
                    worksheet.Cells[$"AV{112 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Cells[$"B{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Cells[$"G{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Akhir_ITAS_ITAP"].Value);
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
                    // Helper function to ensure string has 3 digits
                    string EnsureThreeDigits(string input)
                    {
                        return input.PadLeft(3, '0');
                    }

                    string EnsureTwoDigits(string input)
                    {
                        return input.PadLeft(2, '0');
                    }

                    // RT split
                    string rt = SafeGetCellValue("rt");
                    rt = EnsureThreeDigits(rt);
                    if (rt.Length >= 3)
                    {
                        worksheet.Cells[$"AB{20}"].Value = rt[0].ToString();
                        worksheet.Cells[$"AC{20}"].Value = rt[1].ToString();
                        worksheet.Cells[$"AD{20}"].Value = rt[2].ToString();
                    }

                    // RW split
                    string rw = SafeGetCellValue("rw");
                    rw = EnsureThreeDigits(rw);
                    if (rw.Length >= 3)
                    {
                        worksheet.Cells[$"AI{20}"].Value = rw[0].ToString();
                        worksheet.Cells[$"AJ{20}"].Value = rw[1].ToString();
                        worksheet.Cells[$"AK{20}"].Value = rw[2].ToString();
                    }

                    string jumlahAnggotaKeluarga = SafeGetCellValue("jumlah_Anggota_Keluarga");
                    jumlahAnggotaKeluarga = EnsureThreeDigits(jumlahAnggotaKeluarga);
                    if (rw.Length >= 3)
                    {
                        worksheet.Cells[$"AX{20}"].Value = jumlahAnggotaKeluarga[0].ToString();
                        worksheet.Cells[$"AY{20}"].Value = jumlahAnggotaKeluarga[1].ToString();
                        worksheet.Cells[$"AZ{20}"].Value = jumlahAnggotaKeluarga[2].ToString();
                    }

                    // Telepon
                    worksheet.Cells[$"S{22 + i}"].Value = SafeGetCellValue("telepon");

                    // Email
                    worksheet.Cells[$"S{24}"].Value = SafeGetCellValue("email");

                    //worksheet.Cells[$"S{24 + i}"].Value = SafeGetCellValue("email");

                    // Kode Desa split
                    string kodeDesa = SafeGetCellValue("kode_desa");
                    kodeDesa = EnsureTwoDigits(kodeDesa);
                    if (kodeDesa.Length >= 2)
                    {
                        worksheet.Cells[$"S{33}"].Value = kodeDesa[0].ToString();
                        worksheet.Cells[$"T{33}"].Value = kodeDesa[1].ToString();
                    }

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
                    worksheet.Cells[$"N{43}"].Value = SafeGetCellValue("kode_pos_luar_negeri");

                    string jumlahAnggotaKeluargaLN = SafeGetCellValue("jumlah_Anggota_Keluarga_Luar_Negeri");
                    jumlahAnggotaKeluargaLN = EnsureTwoDigits(jumlahAnggotaKeluargaLN);
                    if (rw.Length >= 2)
                    {
                        worksheet.Cells[$"AM{43}"].Value = jumlahAnggotaKeluargaLN[0].ToString();
                        worksheet.Cells[$"AN{43}"].Value = jumlahAnggotaKeluargaLN[1].ToString();
                    }
                    //string teleponLuarNegeri = SafeGetCellValue("telepon_luar_negeri");

                    // Reverse the string to place digits from Z45 backwards
                    //char[] reversedTelepon = teleponLuarNegeri.ToCharArray();
                    //Array.Reverse(reversedTelepon);

                    //for (int a = 0; a < reversedTelepon.Length; a++)
                    // {
                    //     // Calculate the target cell column based on the current index
                    //     int targetColumn = 90 - a; // 90 is ASCII for 'Z'
                    //     if (targetColumn < 78) break; // Stop if it goes past 'N'
                    //
                    //     worksheet.Cells[$"{(char)targetColumn}45"].Value = reversedTelepon[a].ToString();
                    // }

                    string teleponLuarNegeri = SafeGetCellValue("telepon_luar_negeri");

                    // Store each character in the corresponding cell starting from N45 onwards
                    for (int a = 0; a < teleponLuarNegeri.Length; a++)
                    {
                        // Calculate the target cell column based on the current index
                        int targetColumn = 78 + a; // 78 is ASCII for 'N'
                        if (targetColumn > 90) break; // Stop if it goes past 'Z'

                        worksheet.Cells[$"{(char)targetColumn}45"].Value = teleponLuarNegeri[a].ToString();
                    }

                    worksheet.Cells[$"N{47}"].Value = SafeGetCellValue("email_luar_negeri");

                    string kodenegara = SafeGetCellValue("kode_negara");
                    kodenegara = EnsureThreeDigits(kodenegara);
                    if (rw.Length >= 3)
                    {
                        worksheet.Cells[$"N{49}"].Value = kodenegara[0].ToString();
                        worksheet.Cells[$"O{49}"].Value = kodenegara[1].ToString();
                        worksheet.Cells[$"P{49}"].Value = kodenegara[2].ToString();
                    }

                    worksheet.Cells[$"S{49}"].Value = SafeGetCellValue("nama_negara");

                    string kodeperwakilan = SafeGetCellValue("kode_perwakilan_ri");
                    kodeperwakilan = EnsureTwoDigits(kodeperwakilan);
                    if (kodeperwakilan.Length >= 2)
                    {
                        worksheet.Cells[$"N{51}"].Value = kodeperwakilan[0].ToString();
                        worksheet.Cells[$"O{51}"].Value = kodeperwakilan[1].ToString();
                    }

                    worksheet.Cells[$"S{51}"].Value = SafeGetCellValue("nama_perwakilan_ri");

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
