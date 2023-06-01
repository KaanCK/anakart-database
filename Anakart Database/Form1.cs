using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Anakart_Database
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        //public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=blog;Uid=root;Pwd='';");

        MySqlConnection baglan = new MySqlConnection("Server=anakartdatabase.cgttpdchgwta.eu-central-1.rds.amazonaws.com;Database=k_datalar;Uid=admin;Pwd='19751975k';AllowUserVariables=True;UseCompression=True");
        MySqlDataAdapter baglayici = new MySqlDataAdapter();
        MySqlCommand komut = new MySqlCommand();
        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tierlistComboBox.Text == "AM4 Tierlist")
            {
                string sqlsorgusu = "Select * from am4_tierlist";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "sTRX4 Tierlist")
            {
                string sqlsorgusu = "Select * from strx4_tierlist";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "Intel Core Serisi İşlemciler")
            {
                string sqlsorgusu = "Select * from intel_core_processors";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

        }
    }
}
