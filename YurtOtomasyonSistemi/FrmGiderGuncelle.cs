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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        public string elektrik, su, dogalgaz, Gida, diger, internet, personel, id;

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiderListesi liste = new FrmGiderListesi();
            liste.Show();
            this.Hide();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,internet=@p4,Gıda=@p5,Personel=@p6,Diger=@p7 where Odemeıd=@p8 ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtElektirk.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalGaz.Text);
                komut.Parameters.AddWithValue("@p4", Txtİnternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGıda.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut.Parameters.AddWithValue("@p8", TxtGiderid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDiger.Clear();
                TxtDogalGaz.Clear();
                TxtElektirk.Clear();
                TxtGiderid.Clear();
                TxtGıda.Clear();
                TxtPersonel.Clear();
                TxtSu.Clear();
                Txtİnternet.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme Başarısız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      

        }

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            TxtElektirk.Text = elektrik;
            TxtSu.Text = su;
            TxtDogalGaz.Text = dogalgaz;
            TxtGıda.Text = Gida;
            TxtDiger.Text = diger;
            Txtİnternet.Text = internet;
            TxtPersonel.Text = personel;
            TxtGiderid.Text = id;
        }
    }
}
