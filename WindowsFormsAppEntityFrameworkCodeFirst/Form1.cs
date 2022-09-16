using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;
using WindowsFormsAppEntityFrameworkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext(); // Ef code first ü kullanabilmek için DatabaseContext sınıfımızdan bu şekilde bir nesne oluşturmalıyız.
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Urunler.ToList();// context nesnemizin üzerindeki urunler isimli dbset üzerinden veritabanındaki kayıtları listeliyoruz.
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Urunler.Add(
                    new Urun
                    {
                        Adi = txtUrunAdi.Text,
                        Fiyati = Convert.ToDecimal(txtUrunFiyati.Text),
                        Stok = Convert.ToInt32(txtStokMiktari.Text)
                    }
                    );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

                var kayit = context.Urunler.Find(secilenKayitId);

                txtUrunAdi.Text = kayit.Adi;
                txtUrunFiyati.Text = kayit.Fiyati.ToString();
                txtStokMiktari.Text = kayit.Stok.ToString();

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenKayitId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);

                var kayit = context.Urunler.Find(secilenKayitId);

                kayit.Adi = txtUrunAdi.Text;
                kayit.Fiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                kayit.Stok = Convert.ToInt32(txtStokMiktari.Text);

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Urunler.ToList();
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
                var kayit = context.Urunler.Find(secilenKayitId);
                context.Urunler.Remove(kayit);

                kayit.Adi = txtUrunAdi.Text;
                kayit.Fiyati = Convert.ToDecimal(txtUrunFiyati.Text);
                kayit.Stok = Convert.ToInt32(txtStokMiktari.Text);

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvUrunler.DataSource = context.Urunler.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Urunler.Where(u => u.Adi.Contains(txtAra.Text)).ToList();
        }
    }
}
