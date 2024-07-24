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
                    DataSource = new string[] { "Islam", "Kristen", "Katolik", "Hindu", "Budha", "Konghucu" }
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

                DataGridViewComboBoxColumn comboWNIColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Kewarganegaraan",
                    HeaderText = "Kewarganegaraan",
                    DataPropertyName = "Kewarganegaraan",
                    DataSource = new string[] { "WNI", "WNA" }
                };
                int kewarganegaraanColumnIndex = dataGridView1.Columns["Kewarganegaraan"].Index;
                dataGridView1.Columns.RemoveAt(kewarganegaraanColumnIndex);
                dataGridView1.Columns.Insert(kewarganegaraanColumnIndex, comboWNIColumn);

                DataGridViewComboBoxColumn combogoldarColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Golongan_Darah",
                    HeaderText = "Golongan Darah",
                    DataPropertyName = "Golongan_Darah",
                    DataSource = new string[] { "A", "AB", "B", "O" }
                };
                int goldarColumnIndex = dataGridView1.Columns["Golongan_Darah"].Index;
                dataGridView1.Columns.RemoveAt(goldarColumnIndex);
                dataGridView1.Columns.Insert(goldarColumnIndex, combogoldarColumn);

                //status perkawinan
                DataGridViewComboBoxColumn combostatuskawinColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Status_Perkawinan",
                    HeaderText = "Status Perkawinan",
                    DataPropertyName = "Status_Perkawinan",
                    DataSource = new string[] { "BELUM KAWIN", "KAWIN", "CERAI HIDUP", "CERAI MATI" }
                };
                int statuskawinColumnIndex = dataGridView1.Columns["Status_Perkawinan"].Index;
                dataGridView1.Columns.RemoveAt(statuskawinColumnIndex);
                dataGridView1.Columns.Insert(statuskawinColumnIndex, combostatuskawinColumn);

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
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["NIK"].Index ||
        dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["NIK_Ibu"].Index ||
        dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["NIK_Ayah"].Index)
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

                string FormatDate(object date)
                {
                    if (date is DateTime dateTime)
                        return dateTime.ToString("dd-MM-yyyy");
                    else if (DateTime.TryParse(date?.ToString(), out dateTime))
                        return dateTime.ToString("dd-MM-yyyy");
                    return " ";
                }

                // Helper function to safely get cell value and format it
                string SafeGetCellValue(DataGridViewRow row, string columnName)
                {
                    var cell = row.Cells[columnName];
                    return cell?.Value?.ToString().ToUpper() ?? " ";
                }

                // Helper function to ensure three digits
                string EnsureThreeDigits(string input)
                {
                    return input.PadLeft(3, '0');
                }

                // Helper function to ensure two digits
                string EnsureTwoDigits(string input)
                {
                    return input.PadLeft(2, '0');
                }
               

                worksheet.Cells[$"S{14}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "nama_kepala_keluarga");
                worksheet.Cells[$"S{16}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "alamat");

                // RT split
                string rt = SafeGetCellValue(dataGridView1.Rows[0], "rt");
                rt = EnsureThreeDigits(rt);
                if (rt.Length >= 3)
                {
                    worksheet.Cells[$"AB{20}"].Value = rt[0].ToString();
                    worksheet.Cells[$"AC{20}"].Value = rt[1].ToString();
                    worksheet.Cells[$"AD{20}"].Value = rt[2].ToString();
                }

                // RW split
                string rw = SafeGetCellValue(dataGridView1.Rows[0], "rw");
                rw = EnsureThreeDigits(rw);
                if (rw.Length >= 3)
                {
                    worksheet.Cells[$"AI{20}"].Value = rw[0].ToString();
                    worksheet.Cells[$"AJ{20}"].Value = rw[1].ToString();
                    worksheet.Cells[$"AK{20}"].Value = rw[2].ToString();
                }

                string jumlahAnggotaKeluarga = SafeGetCellValue(dataGridView1.Rows[0], "jumlah_Anggota_Keluarga");
                jumlahAnggotaKeluarga = EnsureThreeDigits(jumlahAnggotaKeluarga);
                if (jumlahAnggotaKeluarga.Length >= 3)
                {
                    worksheet.Cells[$"AX{20}"].Value = jumlahAnggotaKeluarga[0].ToString();
                    worksheet.Cells[$"AY{20}"].Value = jumlahAnggotaKeluarga[1].ToString();
                    worksheet.Cells[$"AZ{20}"].Value = jumlahAnggotaKeluarga[2].ToString();
                }

                // Telepon
                worksheet.Cells[$"S{22}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "telepon");

                // Email
                worksheet.Cells[$"S{24}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "email");

                // Kode Desa split
                string kodeDesa = SafeGetCellValue(dataGridView1.Rows[0], "kode_desa");
                kodeDesa = EnsureTwoDigits(kodeDesa);
                if (kodeDesa.Length >= 2)
                {
                    worksheet.Cells[$"S{33}"].Value = kodeDesa[0].ToString();
                    worksheet.Cells[$"T{33}"].Value = kodeDesa[1].ToString();
                }

                // Nama Dusun
                worksheet.Cells[$"S{35}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "nama_dusun");

                // Alamat Luar Negeri
                worksheet.Cells[$"N{37}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "alamat_luar_negeri");

                // Kota Luar Negeri
                worksheet.Cells[$"N{39}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "kota_luar_negeri");

                // Provinsi Negara Bagian Luar Negeri
                worksheet.Cells[$"AL{39}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "provinsi_negara_bagian_luar_negeri");

                // Negara
                worksheet.Cells[$"N{41}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "negara_luar_negeri");

                // Kode Pos Luar Negeri
                worksheet.Cells[$"N{43}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "kode_pos_luar_negeri");

                string jumlahAnggotaKeluargaLN = SafeGetCellValue(dataGridView1.Rows[0], "jumlah_Anggota_Keluarga_Luar_Negeri");
                jumlahAnggotaKeluargaLN = EnsureTwoDigits(jumlahAnggotaKeluargaLN);
                if (jumlahAnggotaKeluargaLN.Length >= 2)
                {
                    worksheet.Cells[$"AM{43}"].Value = jumlahAnggotaKeluargaLN[0].ToString();
                    worksheet.Cells[$"AN{43}"].Value = jumlahAnggotaKeluargaLN[1].ToString();
                }

                string teleponLuarNegeri = SafeGetCellValue(dataGridView1.Rows[0], "telepon_luar_negeri");

                // Store each character in the corresponding cell starting from N45 onwards
                for (int a = 0; a < teleponLuarNegeri.Length; a++)
                {
                    // Calculate the target cell column based on the current index
                    int targetColumn = 78 + a; // 78 is ASCII for 'N'
                    if (targetColumn > 90) break; // Stop if it goes past 'Z'

                    worksheet.Cells[$"{(char)targetColumn}45"].Value = teleponLuarNegeri[a].ToString();
                }

                worksheet.Cells[$"N{47}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "email_luar_negeri");

                string kodenegara = SafeGetCellValue(dataGridView1.Rows[0], "kode_negara");
                kodenegara = EnsureThreeDigits(kodenegara);
                if (kodenegara.Length >= 3)
                {
                    worksheet.Cells[$"N{49}"].Value = kodenegara[0].ToString();
                    worksheet.Cells[$"O{49}"].Value = kodenegara[1].ToString();
                    worksheet.Cells[$"P{49}"].Value = kodenegara[2].ToString();
                }

                worksheet.Cells[$"S{49}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "nama_negara");

                string kodeperwakilan = SafeGetCellValue(dataGridView1.Rows[0], "kode_perwakilan_ri");
                kodeperwakilan = EnsureTwoDigits(kodeperwakilan);
                if (kodeperwakilan.Length >= 2)
                {
                    worksheet.Cells[$"N{51}"].Value = kodeperwakilan[0].ToString();
                    worksheet.Cells[$"O{51}"].Value = kodeperwakilan[1].ToString();
                }

                worksheet.Cells[$"S{51}"].Value = SafeGetCellValue(dataGridView1.Rows[0], "nama_perwakilan_ri");

                for (int i = 0; i < dataGridView1.Rows.Count && i < 10; i++)
                {
                    var row = dataGridView1.Rows[i];
                    if (row == null) continue; // Skip null rows


                    

                    worksheet.Cells[$"B{64 + i}"].Value = SafeGetCellValue(row, "Nama_Lengkap");
                    worksheet.Cells[$"S{64 + i}"].Value = SafeGetCellValue(row, "Gelar_Depan");
                    worksheet.Cells[$"W{64 + i}"].Value = SafeGetCellValue(row, "Gelar_Belakang");
                    worksheet.Cells[$"AA{64 + i}"].Value = SafeGetCellValue(row, "Passport_Number");
                    worksheet.Cells[$"AH{64 + i}"].Value = FormatDate(row.Cells["Tgl_Berakhir_Paspor"].Value);
                    worksheet.Cells[$"AP{64 + i}"].Value = SafeGetCellValue(row, "Nama_Sponsor");
                    worksheet.Cells[$"B{78 + i}"].Value = SafeGetCellValue(row, "Tipe_Sponsor");
                    worksheet.Cells[$"G{78 + i}"].Value = SafeGetCellValue(row, "Alamat_Sponsor");
                    worksheet.Cells[$"O{78 + i}"].Value = SafeGetCellValue(row, "Jenis_Kelamin");
                    worksheet.Cells[$"U{78 + i}"].Value = SafeGetCellValue(row, "Tempat_Lahir");
                    worksheet.Cells[$"AB{78 + i}"].Value = FormatDate(row.Cells["Tanggal_Lahir"].Value);
                    worksheet.Cells[$"AK{78 + i}"].Value = SafeGetCellValue(row, "Kewarganegaraan");
                    worksheet.Cells[$"AR{78 + i}"].Value = SafeGetCellValue(row, "No_SK_Penetapan_WNI");
                    worksheet.Cells[$"B{98 + i}"].Value = SafeGetCellValue(row, "Nomor_Akta_Kelahiran");
                    worksheet.Cells[$"I{98 + i}"].Value = SafeGetCellValue(row, "Golongan_Darah");
                    worksheet.Cells[$"M{98 + i}"].Value = SafeGetCellValue(row, "Agama");
                    worksheet.Cells[$"Q{98 + i}"].Value = SafeGetCellValue(row, "Nama_Organisasi_Kepercayaan");
                    worksheet.Cells[$"AD{98 + i}"].Value = SafeGetCellValue(row, "Status_Perkawinan");
                    //worksheet.Cells[$"AK{98 + i}"].Value = SafeGetCellValue(row, "Akta_Perkawinan");
                    worksheet.Cells[$"AP{98 + i}"].Value = SafeGetCellValue(row, "Nomor_Akta_Perkawinan");
                    worksheet.Cells[$"AY{98 + i}"].Value = FormatDate(row.Cells["Tanggal_Perkawinan"].Value);
                    //worksheet.Cells[$"B{112 + i}"].Value = SafeGetCellValue(row, "Akta_Cerai");
                    worksheet.Cells[$"E{112 + i}"].Value = SafeGetCellValue(row, "Nomor_Akta_Cerai");
                    worksheet.Cells[$"J{112 + i}"].Value = FormatDate(row.Cells["Tanggal_Perceraian"].Value);
                    worksheet.Cells[$"M{112 + i}"].Value = SafeGetCellValue(row, "Status_Hubungan_Dalam_Keluarga");
                    worksheet.Cells[$"T{112 + i}"].Value = SafeGetCellValue(row, "Kelainan_Fisik_dan_Mental");
                    worksheet.Cells[$"AA{112 + i}"].Value = SafeGetCellValue(row, "Penyandang_Cacat");
                    worksheet.Cells[$"AF{112 + i}"].Value = SafeGetCellValue(row, "Pendidikan_Terakhir");
                    worksheet.Cells[$"AK{112 + i}"].Value = SafeGetCellValue(row, "Jenis_Pekerjaan");
                    worksheet.Cells[$"AO{112 + i}"].Value = SafeGetCellValue(row, "Nomor_ITAS_ITAP");
                    worksheet.Cells[$"AV{112 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Cells[$"B{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Terbit_ITAS_ITAP"].Value);
                    worksheet.Cells[$"G{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Akhir_ITAS_ITAP"].Value);
                    worksheet.Cells[$"K{126 + i}"].Value = SafeGetCellValue(row, "Tempat_Datang_Pertama");
                    worksheet.Cells[$"S{126 + i}"].Value = FormatDate(row.Cells["Tanggal_Kedatangan_Pertama"].Value);
                    worksheet.Cells[$"Z{126 + i}"].Value = SafeGetCellValue(row, "NIK_Ibu");
                    worksheet.Cells[$"AG{126 + i}"].Value = SafeGetCellValue(row, "Nama_Ibu");
                    worksheet.Cells[$"AO{126 + i}"].Value = SafeGetCellValue(row, "NIK_Ayah");
                    worksheet.Cells[$"AU{126 + i}"].Value = SafeGetCellValue(row, "Nama_Ayah");

                    // New fields
                    // Alamat
                    

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
