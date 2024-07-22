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
    public partial class Data_Alamat_WNI : Form
    {
        private Data_Kepala_Keluarga dataKepalaKeluargaForm;
        private Data_Wilayah dataWilayahForm;
        public Data_Alamat_WNI(Data_Kepala_Keluarga kepalaKeluargaForm, Data_Wilayah wilayahForm)
        {
            InitializeComponent();
            this.dataKepalaKeluargaForm = kepalaKeluargaForm;
            this.dataWilayahForm = wilayahForm;
        }

        public string Alamat => AlamatLN.Text;
        public string Kota => KotaLN.Text;
        public string Provinsi => ProvinsiLN.Text;
        public string Negara => NegaraLN.Text;
        public string KodePos => Kode_PosLN.Text;
        public string JumlahAnggotaKeluarga => Jumlah_Anggota_KeluargaLN.Text;
        public string Telepon => TeleponLN.Text;
        public string Email => EmailLN.Text;
        public string KodeNamaNegara => Kode_Nama_NegaraLN.Text;
        public string KodeNamaPerwakilanRI => Kode_Nama_Perwakilan_RILN.Text;

        private void Alamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kota_TextChanged(object sender, EventArgs e)
        {

        }

        private void Provinsi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Negara_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Pos_TextChanged(object sender, EventArgs e)
        {

        }

        private void Jumlah_Anggota_Keluarga_TextChanged(object sender, EventArgs e)
        {

        }

        private void Telepon_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Nama_Negara_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Nama_Perwakilan_RI_TextChanged(object sender, EventArgs e)
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
                command.Parameters.AddWithValue("@kode_provinsi", dataWilayahForm.KodeProvinsi);
                command.Parameters.AddWithValue("@nama_provinsi", dataWilayahForm.NamaProvinsi);
                command.Parameters.AddWithValue("@kode_kabupaten", dataWilayahForm.KodeKabupaten);
                command.Parameters.AddWithValue("@nama_kabupaten", dataWilayahForm.NamaKabupaten);
                command.Parameters.AddWithValue("@kode_kecamatan", dataWilayahForm.KodeKecamatan);
                command.Parameters.AddWithValue("@nama_kecamatan", dataWilayahForm.NamaKecamatan);
                command.Parameters.AddWithValue("@kode_desa", dataWilayahForm.KodeKelurahan);
                command.Parameters.AddWithValue("@nama_desa", dataWilayahForm.NamaKelurahan);
                command.Parameters.AddWithValue("@nama_dusun", dataWilayahForm.NamaDusun);

                command.Parameters.AddWithValue("@alamat_luar_negeri", Alamat);
                command.Parameters.AddWithValue("@kota_luar_negeri", Kota);
                command.Parameters.AddWithValue("@provinsi_negara_bagian", Provinsi);
                command.Parameters.AddWithValue("@negara_luar_negeri", Negara);
                command.Parameters.AddWithValue("@kode_pos_luar_negeri", KodePos);
                command.Parameters.AddWithValue("@jumlah_anggota_luar_negeri", JumlahAnggotaKeluarga);
                command.Parameters.AddWithValue("@telepon_luar_negeri", Telepon);
                command.Parameters.AddWithValue("@email_luar_negeri", Email);
                command.Parameters.AddWithValue("@kode_nama_negara", KodeNamaNegara);
                command.Parameters.AddWithValue("@kode_nama_perwakilan_ri", KodeNamaPerwakilanRI);

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
    }
}
