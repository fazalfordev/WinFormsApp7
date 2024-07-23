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
        public Data_Alamat_WNI()
        {
            InitializeComponent();
        }

        public string Alamat => AlamatLN.Text;
        public string Kota => KotaLN.Text;
        public string Provinsi => ProvinsiLN.Text;
        public string Negara => NegaraLN.Text;
        public string KodePos => Kode_PosLN.Text;
        public string JumlahAnggotaKeluarga => Jumlah_Anggota_KeluargaLN.Text;
        public string Telepon => TeleponLN.Text;
        public string Email => EmailLN.Text;
        public string KodeNegara => Kode_NegaraLN.Text;
        public string NamaNegara => textBox1.Text;
        public string KodePerwakilanRI => Kode_Perwakilan_RILN.Text;
        public string NamaPerwakilanRI => textBox2.Text;

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
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
