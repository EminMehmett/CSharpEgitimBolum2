using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkDbFirst
{
    public partial class UrunYonetimi2 : Form
    {
        public UrunYonetimi2()
        {
            InitializeComponent();
        }

        UrunYonetimiAdoNetEntities context = new UrunYonetimiAdoNetEntities();

        private void UrunYonetimi2_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Products.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Products.Add(new Products
                {
                    UrunAdi = txtUrunAdi.Text,
                    UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text),
                    StokMiktari = Convert.ToInt32(txtStokMiktari.Text)
                });
                context.SaveChanges();
                dgvUrunler.DataSource = context.Products.ToList();
                MessageBox.Show("Kayıt Eklendi!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

            var kayit = context.Products.Find(secilenKayitId);

            txtUrunAdi.Text = kayit.UrunAdi;
            txtUrunFiyati.Text = kayit.UrunFiyati.ToString();
            txtStokMiktari.Text = kayit.StokMiktari.ToString();

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

                var kayit = context.Products.Find(secilenKayitId);

                kayit.UrunAdi = txtUrunAdi.Text;
                kayit.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                kayit.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);

                int sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    MessageBox.Show("Kayıt Güncellendi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

                var kayit = context.Products.Find(secilenKayitId);

                context.Products.Remove(kayit);

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Products.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
                else MessageBox.Show("Kayıt Silinemedi!");

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }
    }
}
