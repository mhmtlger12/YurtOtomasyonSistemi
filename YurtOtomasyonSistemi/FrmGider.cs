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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut2 = new SqlCommand("insert into Giderler(Elektrik,Su,Dogalgaz,internet,Gıda,Personel,Diger) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtElektirk.Text);
                komut2.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut2.Parameters.AddWithValue("@p3", TxtDogalGaz.Text);
                komut2.Parameters.AddWithValue("@p4", Txtİnternet.Text);
                komut2.Parameters.AddWithValue("@p5", TxtGıda.Text);
                komut2.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut2.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception)
            {

                MessageBox.Show("Hatalı İşlem Var", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
            
