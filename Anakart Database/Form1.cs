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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
            tierlistComboBox.Text = "Lütfen metin seçiniz";
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GC.Collect();
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

            if (tierlistComboBox.Text == "Intel Xeon Serisi İşlemciler")
            {
                string sqlsorgusu = "Select * from intel_xeon_processors";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "Intel Pentium Serisi İşlemciler")
            {
                string sqlsorgusu = "Select * from intel_pentium_processors";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "Intel Celeron Serisi İşlemciler")
            {
                string sqlsorgusu = "Select * from intel_celeron_processors";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "Intel Atom Serisi İşlemciler")
            {
                string sqlsorgusu = "Select * from intel_atom_processors";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "DDR4 Ram Çip Tierlist")
            {
                string sqlsorgusu = "Select * from ddr4_ramchip_tierlist";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }

            if (tierlistComboBox.Text == "SSD Tierlist")
            {
                string sqlsorgusu = "Select * from ssd_tierlist";
                DataTable tablo = new DataTable();

                komut.CommandText = sqlsorgusu;
                komut.Connection = baglan;

                baglayici.SelectCommand = komut;
                baglan.Open();
                baglayici.Fill(tablo);
                baglan.Close();
                dataGridView.DataSource = tablo;
            }
            GC.Collect();
        }

        private void disaaktarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (disaaktarComboBox.Text == "Excel")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.OverwritePrompt = false;
                save.Title = "Excel Dosyaları";
                save.DefaultExt = "xlsx";
                save.Filter = "xlsx Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar(*.*)|*.*";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = true;
                    worksheet = workbook.Sheets["Sayfa1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Excel Dışa Aktarım";
                    for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                }
            }

            if (disaaktarComboBox.Text == "PDF")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.OverwritePrompt = false;
                save.Title = "PDF Dosyaları";
                save.DefaultExt = "pdf";
                save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    PdfPTable pdfTable = new PdfPTable(dataGridView.ColumnCount);

                    // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.
                    pdfTable.DefaultCell.Padding = 3; // hücre duvarı ve veri arasında mesafe
                    pdfTable.WidthPercentage = 80; // hücre genişliği
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT; // yazı hizalaması
                    pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı
                                                          // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // hücre arka plan rengi
                        pdfTable.AddCell(cell);
                    }
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                        }
                    }
                    catch (NullReferenceException)
                    {
                    }
                    using (FileStream stream = new FileStream(save.FileName + ".pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);// sayfa boyutu.
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
            }

            if (disaaktarComboBox.Text == "TXT")
            {
                SaveFileDialog dosyakaydet = new SaveFileDialog();
                dosyakaydet.FileName = "";
                dosyakaydet.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                dosyakaydet.Filter = "Txt Dosyası|*.txt";
                if (dosyakaydet.ShowDialog() == DialogResult.OK)
                {
                    TextWriter txt = new StreamWriter(dosyakaydet.FileName);
                    foreach (DataGridViewColumn sutun in dataGridView.Columns)
                    {
                        txt.Write(sutun.HeaderText + "    ");
                    }
                    txt.Write("\n");
                    foreach (DataGridViewRow satir in dataGridView.Rows)
                    {
                        foreach (DataGridViewCell hucre in satir.Cells)
                        {
                            txt.Write(hucre.Value.ToString() + "     ");
                        }
                        txt.Write("\n");
                    }
                    txt.Close();
                }
            }

            GC.Collect();
        }
    }
}
