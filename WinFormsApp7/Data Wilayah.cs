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
        private Data_Kepala_Keluarga parentForm;
        private Data_Alamat_WNI dataAlamatWNI;
        public Data_Wilayah(Data_Kepala_Keluarga parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }

        //public string KodeProvinsi => Kode_Provinsi.Text;
        //public string NamaProvinsi => Nama_Provinsi.Text;
        //public string KodeKabupaten => Kode_Kabupaten.Text;
        //public string NamaKabupaten => Nama_Kabupaten.Text;
        //public string KodeKecamatan => Kode_Kecamatan.Text;
        //public string NamaKecamatan => Nama_Kecamatan.Text;
        //public string KodeKelurahan => Kode_Kelurahan.Text;
        //public string NamaKelurahan => Nama_Kelurahan.Text;
        //public string NamaDusun => Nama_Dusun.Text;

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
            if (checkBox1.Checked && dataAlamatWNI != null)
            {
                SaveDataWithAlamatWNI();
                MessageBox.Show("Data WNI nonluar-negeri berhasil disimpan");
            }
            else
            {
                SaveDataWithoutAlamatWNI();
                MessageBox.Show("Data WNI luar negeri berhasil disimpan");
            }
        }

        private void SaveDataWithAlamatWNI()
        {
            string connectionString = "Server=localhost;Database=kartu_keluarga;User ID=root;Password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO datakeluarga (NIK, nama_kepala_keluarga, alamat, kode_pos, rt, rw, jumlah_anggota_keluarga, telepon, email, kode_provinsi, nama_provinsi, kode_kabupaten, nama_kabupaten, kode_kecamatan, nama_kecamatan, kode_desa, nama_desa, nama_dusun, alamat_luar_negeri, kota_luar_negeri, provinsi_negara_bagian_luar_negeri, negara_luar_negeri, kode_pos_luar_negeri, jumlah_anggota_keluarga_luar_negeri, telepon_luar_negeri, email_luar_negeri, kode_negara, nama_negara, kode_perwakilan_ri, nama_perwakilan_ri) VALUES (@NIK, @NamaKepalaKeluarga, @Alamat, @KodePos, @Rt, @Rw, @JumlahAnggotaKeluarga, @Telepon, @Email, @KodeProvinsi, @NamaProvinsi, @KodeKabupaten, @NamaKabupaten, @KodeKecamatan, @NamaKecamatan, @KodeDesa, @NamaDesa, @NamaDusun, @AlamatLuarNegeri, @KotaLuarNegeri, @ProvinsiLuarNegeri, @NegaraLuarNegeri, @KodePosLuarNegeri, @JumlahAnggotaKeluargaLuarNegeri, @TeleponLuarNegeri, @EmailLuarNegeri, @KodeNegara, @NamaNegara, @KodePerwakilanRI, @NamaPerwakilanRI)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NIK", parentForm.NIKKepalaKeluarga);
                    cmd.Parameters.AddWithValue("@NomorKK", parentForm.NomorKK);
                    cmd.Parameters.AddWithValue("@NamaKepalaKeluarga", parentForm.NamaKepalaKeluarga);
                    cmd.Parameters.AddWithValue("@Alamat", parentForm.Alamat);
                    cmd.Parameters.AddWithValue("@KodePos", parentForm.KodePos);
                    cmd.Parameters.AddWithValue("@Rt", parentForm.Rt);
                    cmd.Parameters.AddWithValue("@Rw", parentForm.Rw);
                    cmd.Parameters.AddWithValue("@JumlahAnggotaKeluarga", parentForm.JumlahAnggotaKeluarga);
                    cmd.Parameters.AddWithValue("@Telepon", parentForm.Telepon);
                    cmd.Parameters.AddWithValue("@Email", parentForm.EMail);
                    cmd.Parameters.AddWithValue("@KodeProvinsi", Kode_Provinsi.Text);
                    cmd.Parameters.AddWithValue("@NamaProvinsi", Nama_Provinsi.Text);
                    cmd.Parameters.AddWithValue("@KodeKabupaten", Kode_Kabupaten.Text);
                    cmd.Parameters.AddWithValue("@NamaKabupaten", Nama_Kabupaten.Text);
                    cmd.Parameters.AddWithValue("@KodeKecamatan", Kode_Kecamatan.Text);
                    cmd.Parameters.AddWithValue("@NamaKecamatan", Nama_Kecamatan.Text);
                    cmd.Parameters.AddWithValue("@KodeDesa", Kode_Kelurahan.Text);
                    cmd.Parameters.AddWithValue("@NamaDesa", Nama_Kelurahan.Text);
                    cmd.Parameters.AddWithValue("@NamaDusun", Nama_Dusun.Text);
                    cmd.Parameters.AddWithValue("@AlamatLuarNegeri", dataAlamatWNI.Alamat);
                    cmd.Parameters.AddWithValue("@KotaLuarNegeri", dataAlamatWNI.Kota);
                    cmd.Parameters.AddWithValue("@ProvinsiLuarNegeri", dataAlamatWNI.Provinsi);
                    cmd.Parameters.AddWithValue("@NegaraLuarNegeri", dataAlamatWNI.Negara);
                    cmd.Parameters.AddWithValue("@KodePosLuarNegeri", dataAlamatWNI.KodePos);
                    cmd.Parameters.AddWithValue("@JumlahAnggotaKeluargaLuarNegeri", dataAlamatWNI.JumlahAnggotaKeluarga);
                    cmd.Parameters.AddWithValue("@TeleponLuarNegeri", dataAlamatWNI.Telepon);
                    cmd.Parameters.AddWithValue("@EmailLuarNegeri", dataAlamatWNI.Email);
                    cmd.Parameters.AddWithValue("@KodeNegara", dataAlamatWNI.KodeNegara);
                    cmd.Parameters.AddWithValue("@NamaNegara", dataAlamatWNI.NamaNegara);
                    cmd.Parameters.AddWithValue("@KodePerwakilanRI", dataAlamatWNI.KodePerwakilanRI);
                    cmd.Parameters.AddWithValue("@NamaPerwakilanRI", dataAlamatWNI.NamaPerwakilanRI);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveDataWithoutAlamatWNI()
        {
            string connectionString = "Server=localhost;Database=kartu_keluarga;User ID=root;Password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO datakeluarga (NIK, nama_kepala_keluarga, alamat, kode_pos, rt, rw, jumlah_anggota_keluarga, telepon, email, kode_provinsi, nama_provinsi, kode_kabupaten, nama_kabupaten, kode_kecamatan, nama_kecamatan, kode_desa, nama_desa, nama_dusun, alamat_luar_negeri, kota_luar_negeri, provinsi_negara_bagian_luar_negeri, negara_luar_negeri, kode_pos_luar_negeri, jumlah_anggota_keluarga_luar_negeri, telepon_luar_negeri, email_luar_negeri, kode_negara, nama_negara, kode_perwakilan_ri, nama_perwakilan_ri) VALUES (@NIK, @NamaKepalaKeluarga, @Alamat, @KodePos, @Rt, @Rw, @JumlahAnggotaKeluarga, @Telepon, @Email, @KodeProvinsi, @NamaProvinsi, @KodeKabupaten, @NamaKabupaten, @KodeKecamatan, @NamaKecamatan, @KodeDesa, @NamaDesa, @NamaDusun, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NIK", parentForm.NIKKepalaKeluarga);
                    cmd.Parameters.AddWithValue("@NomorKK", parentForm.NomorKK);
                    cmd.Parameters.AddWithValue("@NamaKepalaKeluarga", parentForm.NamaKepalaKeluarga);
                    cmd.Parameters.AddWithValue("@Alamat", parentForm.Alamat);
                    cmd.Parameters.AddWithValue("@KodePos", parentForm.KodePos);
                    cmd.Parameters.AddWithValue("@Rt", parentForm.Rt);
                    cmd.Parameters.AddWithValue("@Rw", parentForm.Rw);
                    cmd.Parameters.AddWithValue("@JumlahAnggotaKeluarga", parentForm.JumlahAnggotaKeluarga);
                    cmd.Parameters.AddWithValue("@Telepon", parentForm.Telepon);
                    cmd.Parameters.AddWithValue("@Email", parentForm.EMail);
                    cmd.Parameters.AddWithValue("@KodeProvinsi", Kode_Provinsi.Text);
                    cmd.Parameters.AddWithValue("@NamaProvinsi", Nama_Provinsi.Text);
                    cmd.Parameters.AddWithValue("@KodeKabupaten", Kode_Kabupaten.Text);
                    cmd.Parameters.AddWithValue("@NamaKabupaten", Nama_Kabupaten.Text);
                    cmd.Parameters.AddWithValue("@KodeKecamatan", Kode_Kecamatan.Text);
                    cmd.Parameters.AddWithValue("@NamaKecamatan", Nama_Kecamatan.Text);
                    cmd.Parameters.AddWithValue("@KodeDesa", Kode_Kelurahan.Text);
                    cmd.Parameters.AddWithValue("@NamaDesa", Nama_Kelurahan.Text);
                    cmd.Parameters.AddWithValue("@NamaDusun", Nama_Dusun.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                using (dataAlamatWNI = new Data_Alamat_WNI())
                {
                    dataAlamatWNI.ShowDialog();
                }
            }
        }
    }
}
