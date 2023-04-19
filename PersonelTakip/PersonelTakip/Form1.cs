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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-0V73418\\SQLEXPRESS;Initial Catalog=PersonelNew;Integrated Security=True");


        int sectury = 0;
        string log;
        string[] code2 = { "A", "G", "B" };
        void secturycode()
        {
            Random sec = new Random();
            sectury = sec.Next(1000,1050);

            label4.Text = sectury.ToString() + code2[0] + code2[1];


           


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            secturycode();

        }

        private void adminlogin_Click(object sender, EventArgs e)
        {

            // SECTURY  CODE And Login Connection
            log = txtadminkey.Text;

            if (log.ToString() == label4.Text)
            {

                bağlantı.Open();
                SqlCommand loginadmin = new SqlCommand("Select * From Table_Admin where Kullaniciadi=@Q1 and Sifre=@Q2", bağlantı);
                loginadmin.Parameters.AddWithValue("@Q1", txtadmin.Text);
                loginadmin.Parameters.AddWithValue("@Q2", txtadminps.Text);
                SqlDataReader dat = loginadmin.ExecuteReader();

                if (dat.Read())
                {
                    PersonelEkle personelfrom = new PersonelEkle();
                    personelfrom.Show();
                    this.Hide();


                }
                else
                {
                      MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                


            }
            else { MessageBox.Show("Güvenlik Kodu Yanlış", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            // SECTURY CODE And Login Connection







        }
    }
}
