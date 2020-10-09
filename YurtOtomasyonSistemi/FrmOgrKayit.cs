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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Labelde Arka Planda Transparent Yapma
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
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
            //ComboBoxa Öğreni Bölümlerini Eklemek   

            SqlCommand komut = new SqlCommand("Select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbOgrBolum.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();

            //Odaları Listeleme

 
            SqlCommand komut2 = new SqlCommand("select Odano from Odalar where OdaKapasite!=OdaAktif", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbOdaNo.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Öğrenci Kaydetme

            try { 
            SqlCommand komut3 = new SqlCommand("insert into Ogrenci(Ograd,Ogrsoyad,OgrTC,OgrTelefon,OgrBolum,OgrDogum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@P1", TxtOgrAd.Text);
            komut3.Parameters.AddWithValue("@P2", TxtOgrSoyad.Text);
            komut3.Parameters.AddWithValue("@P3", MskdOgrTC.Text);
            komut3.Parameters.AddWithValue("@P4", MskdOgrTelefon.Text);
            komut3.Parameters.AddWithValue("@P5", CmbOgrBolum.Text);
            komut3.Parameters.AddWithValue("@P6", MskdOgrTarih.Text);
            komut3.Parameters.AddWithValue("@P7", TxtOgrMail.Text);
            komut3.Parameters.AddWithValue("@P8" ,CmbOdaNo.Text);
            komut3.Parameters.AddWithValue("@P9", TxtVeliAdSoyad.Text);
            komut3.Parameters.AddWithValue("@P10", MskdVeliTel.Text);
            komut3.Parameters.AddWithValue("@P11",  RichAdres.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            
                MessageBox.Show("Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cek = new SqlCommand("select Ogrıd from Ogrenci", bgl.baglanti());
                SqlDataReader okuy = cek.ExecuteReader();
                while(okuy.Read())
                {
                    label12.Text = okuy[0].ToString();
                }
                bgl.baglanti().Close();



                ///Ogrenci aynı anda borcala da  kaydetme
                SqlCommand yeni = new SqlCommand("insert into Borclar(Ogrıd,OgrAd,OgrSoyad) values (@b1,@b2,@b3)", bgl.baglanti());
                yeni.Parameters.AddWithValue("@b1", label12.Text);
                yeni.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                yeni.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                yeni.ExecuteNonQuery();
                bgl.baglanti().Close();





        }
            catch(Exception)
            {
                MessageBox.Show("Hatalı İşlem Yaptınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Odakapasite arrtırtmas

            SqlCommand komut5 = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@oda1", bgl.baglanti());
            komut5.Parameters.AddWithValue("@oda1", CmbOdaNo.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Başarılı");
}
    }
}

