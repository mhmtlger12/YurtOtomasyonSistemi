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

namespace YurtOtomasyonSistemi
{
    public partial class FrmYoneticiDuzenle : Form
    {
        public FrmYoneticiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmYoneticiDuzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into Admin(YoneticiAd,YoneticiSifre) values (@p1,@p2)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtYoneticiAd.Text);
                komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yönetici Eklendi..");
                this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;

            string id, ad, sifre;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            Txtid.Text = id;
            TxtYoneticiAd.Text = ad;
            TxtSifre.Text = sifre;

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut2 = new SqlCommand("delete from Admin where Yoneticiıd=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", Txtid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme Başarılı..");
                this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut3 = new SqlCommand("update Admin set YoneticiAd=@p1,YoneticiSifre=@p2 where Yoneticiıd=@p3", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", TxtYoneticiAd.Text);
                komut3.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut3.Parameters.AddWithValue("@p3", Txtid.Text);
                komut3.ExecuteNonQuery();
                MessageBox.Show("Güncelleme  Başarılı..");
                this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
