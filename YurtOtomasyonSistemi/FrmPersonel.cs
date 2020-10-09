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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet6.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into Personel(PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtPersonelad.Text);
                komut1.Parameters.AddWithValue("@p2", Txtgorev.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yönetici Eklendi..");
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut2 = new SqlCommand("delete from Personel where Personelıd=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme Başarılı..");
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);
              
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
                SqlCommand komut3 = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2 where Personelıd=@p3", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", TxtPersonelad.Text);
                komut3.Parameters.AddWithValue("@p2", Txtgorev.Text);
                komut3.Parameters.AddWithValue("@p3", TxtPersonelid.Text);
                komut3.ExecuteNonQuery();
                MessageBox.Show("Güncelleme  Başarılı..");
                this.personelTableAdapter.Fill(this.yurtOtomasyonDataSet6.Personel);
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

            TxtPersonelid.Text = id;
            TxtPersonelad.Text = ad;
            TxtPersonelad.Text = sifre;

        }
    }
}
