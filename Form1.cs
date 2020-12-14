using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_099
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBox1.Text;
            string NamaCustomer = textBox2.Text;
            string NoTelpon = textBox3.Text;
            int JumlahPemesanan = int.Parse(textBox4.Text);
            string IDLokasi = textBox5.Text;

            var a = service.pemesanan(IDPemesanan, NamaCustomer, NoTelpon, JumlahPemesanan, IDLokasi);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBox1.Text;
            string NamaCustomer = textBox2.Text;
            string NoTelpon = textBox3.Text;
            var a = service.editpemesanan(IDPemesanan, NamaCustomer, NoTelpon);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string IDPemesanan = textBox1.Text;

            var a = service.deletePemesanan(IDPemesanan);
            MessageBox.Show(a);
            TampilData();
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            textBox4.Enabled = true;
            textBox5.Enabled = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;

            textBox1.Enabled = true;
        }

        private void TampilData()
        {
            var List = service.Pemesanan1();
            dtPemesanan.DataSource = List;
        }

        private void dtPemesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[0].Value);
            textBox2.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[1].Value);
            textBox3.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[2].Value);
            textBox4.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[3].Value);
            textBox5.Text = Convert.ToString(dtPemesanan.Rows[e.RowIndex].Cells[4].Value);

            textBox4.Enabled = false;
            textBox5.Enabled = false;

            button2.Enabled = true;
            button3.Enabled = true;

            button1.Enabled = false;
            textBox1.Enabled = false;
        }
    }
}
