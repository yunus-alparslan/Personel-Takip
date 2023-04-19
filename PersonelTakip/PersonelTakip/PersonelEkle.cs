using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelTakip
{
    public partial class PersonelEkle : Form
    {
        public PersonelEkle()
        {
            InitializeComponent();
        }

        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-0V73418\\SQLEXPRESS;Initial Catalog=PersonelNew;Integrated Security=True");


        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            this.table_PersonelTableAdapter1.Fill(this.personelNewDataSet2.Table_Personel);

            // TODO: This line of code loads data into the 'personelNewDataSet2.Table_Personel' table. You can move, or remove it, as needed.
            comboBox1.Text = "Şehir Yapınız";
            comboBox2.Text = "Pozisyon Seçiniz";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bağlantı.Open();
            SqlCommand personeladd = new SqlCommand("insert into Table_Personel(Personelİsim,PersonelSoyad,PersonelSehir,PersonelMaaş,PersonelPozisyon,PersonelDurum) values(@Q1,@Q2,@Q3,@Q4,@Q5,@Q6)", bağlantı);
            personeladd.Parameters.AddWithValue("@Q1",textBox2.Text);
            personeladd.Parameters.AddWithValue("@Q2", textBox3.Text);
            personeladd.Parameters.AddWithValue("@Q3", comboBox1.Text);
            personeladd.Parameters.AddWithValue("@Q4", maskedTextBox1.Text);
            personeladd.Parameters.AddWithValue("@Q5", comboBox2.Text);

            if (radioButton1.Checked == true)
            {
                personeladd.Parameters.AddWithValue("@Q6", radioButton1.Checked);
            }
            else
            {
                personeladd.Parameters.AddWithValue("@Q6", radioButton1.Checked);
            }

            personeladd.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Eklendi");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Listenlendi");
            this.table_PersonelTableAdapter1.Fill(this.personelNewDataSet2.Table_Personel);
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "Şehir Yapınız";
            textBox3.Text = "";
            comboBox2.Text = "Pozisyon Seçiniz";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
                   radioButton2.Checked = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand dweletd = new SqlCommand("Delete From Table_Personel where id=@AF",bağlantı);
            dweletd.Parameters.AddWithValue("@Af", textBox1.Text);
            dweletd.ExecuteNonQuery();
            bağlantı.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand updater = new SqlCommand("Update Table_Personel Set Personelİsim=@afa where id=@afax", bağlantı);
            updater.Parameters.AddWithValue("@afa", textBox2.Text);
              updater.Parameters.AddWithValue("@afax", textBox1.Text);
              updater.ExecuteNonQuery();
              bağlantı.Close();

              MessageBox.Show("Güncellendi");
        }
    }
}
