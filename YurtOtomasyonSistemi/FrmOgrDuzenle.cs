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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id , ad,soyad, TC,telefon,dogum,bolum,mail,odano,veliad,velitel,adres;
        SqlBaglantim bgl = new SqlBaglantim();
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from Ogrenci where Ogrıd=@k1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@k1", TxtxOgrid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme Başarılı");

            //oda aktif sayısı azaltma
            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@ONo", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@ONo", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        
        
        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("update Ogrenci Set Ograd=@p1,Ogrsoyad=@p2,OgrTC=@p3,OgrTelefon=@p4,OgrBolum=@p5,OgrDogum=@p6,OgrMail=@p7,OgrOdaNo=@p8,OgrVeliAdSoyad=@p9,OgrVeliTelefon=@p10,OgrVeliAdres=@p11 where Ogrıd=@p12", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1",TxtOgrAd.Text);
                komut1.Parameters.AddWithValue("@p2",TxtOgrSoyad.Text);
                komut1.Parameters.AddWithValue("@p3",MskdOgrTC.Text);
                komut1.Parameters.AddWithValue("@p4",MskdOgrTelefon.Text);
                komut1.Parameters.AddWithValue("@p5",CmbOgrBolum.Text);
                komut1.Parameters.AddWithValue("@p6",MskdOgrTarih.Text);
                komut1.Parameters.AddWithValue("@p7",TxtOgrMail.Text);
                komut1.Parameters.AddWithValue("@p8",CmbOdaNo.Text);
                komut1.Parameters.AddWithValue("@p9",TxtVeliAdSoyad.Text);
                komut1.Parameters.AddWithValue("@p10",MskdVeliTel.Text);
                komut1.Parameters.AddWithValue("@p11",RichAdres.Text);
                komut1.Parameters.AddWithValue("@p12",TxtxOgrid.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt Başarısız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            TxtxOgrid.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MskdOgrTC.Text = TC;
            MskdOgrTelefon.Text = telefon;
            MskdOgrTarih.Text = dogum;
            CmbOgrBolum.Text = bolum;
            TxtOgrMail.Text = mail;
            CmbOdaNo.Text = odano;
            TxtVeliAdSoyad.Text = veliad;
            MskdVeliTel.Text = velitel;
            RichAdres.Text = adres;
            
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;
            label7.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;
            label8.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;
            label9.Parent = pictureBox1;
            label9.BackColor = Color.Transparent;
            label10.Parent = pictureBox1;
            label10.BackColor = Color.Transparent;
            label11.Parent = pictureBox1;
            label11.BackColor = Color.Transparent;
            label13.Parent = pictureBox1;
            label13.BackColor = Color.Transparent;
            lbl25.Parent = pictureBox1;
            lbl25.BackColor = Color.Transparent;

        }
    }
}
