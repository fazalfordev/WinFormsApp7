using System;
using System.Windows.Forms;

namespace UAS
{
    public partial class Data_Kepala_Keluarga : Form
    {
        public Data_Kepala_Keluarga()
        {
            InitializeComponent();
        }

        // Properties to get form input values
        public string NIKKepalaKeluarga => textBox1.Text;
        public string NomorKK => Nomor_KK.Text;
        public string NamaKepalaKeluarga => Nama_Kepala_Keluarga.Text;
        public string Alamat => Alamat1.Text + " " + Alamat2.Text;
        public string KodePos => Kode_Pos.Text;
        public string Rt => RT.Text;
        public string Rw => RW.Text;
        public string JumlahAnggotaKeluarga => Jumlah_Anggota_Keluarga.Text;
        public string Telepon => telephone.Text;
        public string EMail => Email.Text;

        private void Nama_Kepala_Keluarga_TextChanged(object sender, EventArgs e) { }
        private void Alamat1_TextChanged(object sender, EventArgs e) { }
        private void Alamat2_TextChanged(object sender, EventArgs e) { }
        private void Kode_Pos_TextChanged(object sender, EventArgs e) { }
        private void RT_TextChanged(object sender, EventArgs e) { }
        private void RW_TextChanged(object sender, EventArgs e) { }
        private void Jumlah_Anggota_Keluarga_TextChanged(object sender, EventArgs e) { }
        private void telephone_TextChanged(object sender, EventArgs e) { }
        private void Email_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Nomor_KK_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Data_Wilayah data_Wilayah = new Data_Wilayah(this))
            {
                data_Wilayah.ShowDialog();
            }
        }

        private void Data_Kepala_Keluarga_Load(object sender, EventArgs e) { }
    }
}
