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
    public partial class FrmGelirİstatistik : Form
    {
        public FrmGelirİstatistik()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmGelirİstatistik_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(ödemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                label2.Text = oku[0].ToString() + " TL";

            }
            bgl.baglanti().Close();

            //ayları comboboxa çekme
            SqlCommand komut2 = new SqlCommand("select distinct(OdemeAy) From Kasa", bgl.baglanti());
            SqlDataReader dR = komut2.ExecuteReader();
            while(dR.Read())
            {
                comboBox1.Items.Add(dR[0].ToString());
            }
            bgl.baglanti().Close();

            //Grafiklere verityabanında veri çekme  
            SqlCommand veri = new SqlCommand("select OdemeAy, sum(ÖdemeMiktar) from Kasa group by OdemeAy", bgl.baglanti());
            SqlDataReader oku3 = veri.ExecuteReader();
            while(oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3[0],oku3[1]);

            }
            bgl.baglanti().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select sum(ÖdemeMiktar) From Kasa where OdemeAy=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader ss = komut3.ExecuteReader();
            while (ss.Read())
            {
               lblaykazanc.Text=ss[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
