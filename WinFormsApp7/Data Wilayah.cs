using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS
{
    public partial class Data_Wilayah : Form
    {
        private Data_Kepala_Keluarga dataKepalaKeluargaForm;
        private Data_Alamat_WNI dataAlamatWNIForm;
        private bool isLivingAbroad;

        public Data_Wilayah()
        {
            InitializeComponent();
            dataKepalaKeluargaForm = new Data_Kepala_Keluarga();
            dataAlamatWNIForm = new Data_Alamat_WNI(dataKepalaKeluargaForm, this); // Pass the required parameters
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        public string KodeProvinsi => Kode_Provinsi.Text;
        public string NamaProvinsi => Nama_Provinsi.Text;
        public string KodeKabupaten => Kode_Kabupaten.Text;
        public string NamaKabupaten => Nama_Kabupaten.Text;
        public string KodeKecamatan => Kode_Kecamatan.Text;
        public string NamaKecamatan => Nama_Kecamatan.Text;
        public string KodeKelurahan => Kode_Kelurahan.Text;
        public string NamaKelurahan => Nama_Kelurahan.Text;
        public string NamaDusun => Nama_Dusun.Text;

        private void Kode_Provinsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nama_Provinsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Kabupaten_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nama_Kabupaten_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Kecamatan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nama_Kecamatan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Kelurahan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nama_Kelurahan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nama_Dusun_TextChanged(object sender, EventArgs e)
        {

        }

        private void Data_Wilayah_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=kartu_keluarga;user=root;password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO datakeluarga (
                                    nama_kepala_keluarga, alamat, kode_pos, rt, rw, jumlah_anggota_keluarga, 
                                    telepon, email, kode_provinsi, nama_provinsi, kode_kabupaten, 
                                    nama_kabupaten, kode_kecamatan, nama_kecamatan, kode_desa, 
                                    nama_desa, nama_dusun, alamat_luar_negeri, kota_luar_negeri, 
                                    provinsi_negara_bagian, negara_luar_negeri, kode_pos_luar_negeri, 
                                    jumlah_anggota_luar_negeri, telepon_luar_negeri, email_luar_negeri, 
                                    kode_nama_negara, kode_nama_perwakilan_ri)
                                VALUES (
                                    @nama_kepala_keluarga, @alamat, @kode_pos, @rt, @rw, @jumlah_anggota_keluarga, 
                                    @telepon, @alamat_email, @kode_provinsi, @nama_provinsi, @kode_kabupaten, 
                                    @nama_kabupaten, @kode_kecamatan, @nama_kecamatan, @kode_desa, 
                                    @nama_desa, @nama_dusun, @alamat_luar_negeri, @kota_luar_negeri, 
                                    @provinsi_negara_bagian, @negara_luar_negeri, @kode_pos_luar_negeri, 
                                    @jumlah_anggota_luar_negeri, @telepon_luar_negeri, @email_luar_negeri, 
                                    @kode_nama_negara, @kode_nama_perwakilan_ri)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nama_kepala_keluarga", dataKepalaKeluargaForm.NamaKepalaKeluarga);
                command.Parameters.AddWithValue("@alamat", dataKepalaKeluargaForm.Alamat);
                command.Parameters.AddWithValue("@kode_pos", dataKepalaKeluargaForm.KodePos);
                command.Parameters.AddWithValue("@rt", dataKepalaKeluargaForm.Rt);
                command.Parameters.AddWithValue("@rw", dataKepalaKeluargaForm.Rw);
                command.Parameters.AddWithValue("@jumlah_anggota_keluarga", dataKepalaKeluargaForm.JumlahAnggotaKeluarga);
                command.Parameters.AddWithValue("@telepon", dataKepalaKeluargaForm.Telepon);
                command.Parameters.AddWithValue("@alamat_email", dataKepalaKeluargaForm.EMail);
                command.Parameters.AddWithValue("@kode_provinsi", KodeProvinsi);
                command.Parameters.AddWithValue("@nama_provinsi", NamaProvinsi);
                command.Parameters.AddWithValue("@kode_kabupaten", KodeKabupaten);
                command.Parameters.AddWithValue("@nama_kabupaten", NamaKabupaten);
                command.Parameters.AddWithValue("@kode_kecamatan", KodeKecamatan);
                command.Parameters.AddWithValue("@nama_kecamatan", NamaKecamatan);
                command.Parameters.AddWithValue("@kode_desa", KodeKelurahan);
                command.Parameters.AddWithValue("@nama_desa", NamaKelurahan);
                command.Parameters.AddWithValue("@nama_dusun", NamaDusun);

                if (isLivingAbroad)
                {
                    command.Parameters.AddWithValue("@alamat_luar_negeri", dataAlamatWNIForm.Alamat);
                    command.Parameters.AddWithValue("@kota_luar_negeri", dataAlamatWNIForm.Kota);
                    command.Parameters.AddWithValue("@provinsi_negara_bagian", dataAlamatWNIForm.Provinsi);
                    command.Parameters.AddWithValue("@negara_luar_negeri", dataAlamatWNIForm.Negara);
                    command.Parameters.AddWithValue("@kode_pos_luar_negeri", dataAlamatWNIForm.KodePos);
                    command.Parameters.AddWithValue("@jumlah_anggota_luar_negeri", dataAlamatWNIForm.JumlahAnggotaKeluarga);
                    command.Parameters.AddWithValue("@telepon_luar_negeri", dataAlamatWNIForm.Telepon);
                    command.Parameters.AddWithValue("@email_luar_negeri", dataAlamatWNIForm.Email);
                    command.Parameters.AddWithValue("@kode_nama_negara", dataAlamatWNIForm.KodeNamaNegara);
                    command.Parameters.AddWithValue("@kode_nama_perwakilan_ri", dataAlamatWNIForm.KodeNamaPerwakilanRI);
                }
                else
                {
                    command.Parameters.AddWithValue("@alamat_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@kota_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@provinsi_negara_bagian", DBNull.Value);
                    command.Parameters.AddWithValue("@negara_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@kode_pos_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@jumlah_anggota_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@telepon_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@email_luar_negeri", DBNull.Value);
                    command.Parameters.AddWithValue("@kode_nama_negara", DBNull.Value);
                    command.Parameters.AddWithValue("@kode_nama_perwakilan_ri", DBNull.Value);
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data successfully saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isLivingAbroad = checkBox1.Checked;
            if (isLivingAbroad)
            {
                dataAlamatWNIForm.ShowDialog();
            }
        }
    }
}
