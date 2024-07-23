using System;
using System.Windows.Forms;

namespace UAS
{
    public partial class Data_Kepala_Keluarga : Form
    {
        public Data_Kepala_Keluarga()
        {
            InitializeComponent();
            AssignEventHandlers();
        }

        // Properties to get form input values
        public string NIKKepalaKeluarga => GetConcatenatedText(textBox1, textBox5, textBox6, textBox7);
        public string NomorKK => GetConcatenatedText(Nomor_KK, textBox2, textBox3, textBox4);
        public string NamaKepalaKeluarga => Nama_Kepala_Keluarga.Text;
        public string Alamat => $"{Alamat1.Text} {Alamat2.Text}";
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
        private void Data_Kepala_Keluarga_Load(object sender, EventArgs e) { }
        private void Nomor_KK_TextChanged(object sender, EventArgs e)
        {
            if (Nomor_KK.Text.Length == 4)
            {
                textBox2.Focus();
            }
        }
        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true; // Suppress the key press if it's not a digit or control key
        }
        private string GetConcatenatedText(params TextBox[] textBoxes)
        {
            string concatenatedText = string.Join("", Array.ConvertAll(textBoxes, tb => tb.Text.Trim()));
            return concatenatedText.Length == 16 ? concatenatedText : null;
        }
        private void AutoTab(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text.Length == 4)
                this.SelectNextControl(textBox, true, true, true, true);
        }
        private void AssignEventHandlers()
        {
            // Assigning TextChanged and KeyPress event handlers
            foreach (var tb in new[] { Nomor_KK, textBox2, textBox3, textBox4, textBox1, textBox5, textBox6, textBox7 })
            {
                tb.TextChanged += AutoTab;
                tb.KeyPress += Numeric_KeyPress;
            }

            Jumlah_Anggota_Keluarga.KeyPress += Numeric_KeyPress;
            telephone.KeyPress += Numeric_KeyPress;
        }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Data_Wilayah data_Wilayah = new Data_Wilayah(this))
            {
                data_Wilayah.ShowDialog();
            }
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
