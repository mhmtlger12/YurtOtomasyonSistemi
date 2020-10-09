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
    public partial class FrmBolumEkle : Form
    {
        public FrmBolumEkle()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmBolumEkle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand komut = new SqlCommand("insert into Bolumler (Bolumad) values(@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);

            }
            catch(Exception)
            {
                MessageBox.Show("Başarısız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("delete from Bolumler where Bolumıd=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtId.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Var", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            TxtId.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
     
                SqlCommand komut2 = new SqlCommand("update Bolumler set Bolumad=@p1 where Bolumıd=@p2 ", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p2", TxtId.Text);
                komut2.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut2.ExecuteNonQuery();

                MessageBox.Show("Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Var", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolumler);
            }
        }
    }
}
