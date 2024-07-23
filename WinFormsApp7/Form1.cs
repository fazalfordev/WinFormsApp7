using MySql.Data.MySqlClient;
using UAS;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;user=root;database=kartu_keluarga;port=3306;password=";

        public Form1()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string nomorKK = GetNomorKK();

            if (!string.IsNullOrEmpty(nomorKK))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM KartuKeluarga WHERE Nomor_KK = @NomorKK";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NomorKK", nomorKK);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        Form2 form2 = new Form2(nomorKK, connectionString);
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nomor KK tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pastikan input sudah 16 digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addKKButton_Click(object sender, EventArgs e)
        {
            Data_Kepala_Keluarga dataKepalaKeluargaForm = new Data_Kepala_Keluarga();
            if (dataKepalaKeluargaForm.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string newKKNumber = GetNomorKK();
                    string insertKKQuery = "INSERT INTO KartuKeluarga (Nomor_KK) VALUES (@NomorKK)";
                    MySqlCommand insertKKCommand = new MySqlCommand(insertKKQuery, connection);
                    insertKKCommand.Parameters.AddWithValue("@NomorKK", newKKNumber);

                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        insertKKCommand.Transaction = transaction;
                        insertKKCommand.ExecuteNonQuery();

                        // Collect data from the Data_Kepala_Keluarga form
                        string namaKepalaKeluarga = dataKepalaKeluargaForm.NamaKepalaKeluarga;
                        string alamat = dataKepalaKeluargaForm.Alamat;
                        string kodePos = dataKepalaKeluargaForm.KodePos;
                        string rt = dataKepalaKeluargaForm.Rt;
                        string rw = dataKepalaKeluargaForm.Rw;
                        string jumlahAnggotaKeluarga = dataKepalaKeluargaForm.JumlahAnggotaKeluarga;
                        string telepon = dataKepalaKeluargaForm.Telepon;
                        string email = dataKepalaKeluargaForm.EMail;

                        // Insert additional data as needed

                        transaction.Commit();
                        MessageBox.Show("Nomor KK dan data Kepala Keluarga berhasil ditambahkan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GetNomorKK()
        {
            string part1 = textBox1.Text.Trim();
            string part2 = textBox2.Text.Trim();
            string part3 = textBox3.Text.Trim();
            string part4 = textBox4.Text.Trim();

            if (part1.Length == 4 && part2.Length == 4 && part3.Length == 4 && part4.Length == 4)
            {
                return part1 + part2 + part3 + part4;
            }
            else
            {
                return null;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length == 4)
            {
                this.SelectNextControl(textBox, true, true, true, true);
            }
        }
    }
}
