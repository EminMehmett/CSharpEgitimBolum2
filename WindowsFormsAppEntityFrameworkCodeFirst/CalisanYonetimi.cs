using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;
using WindowsFormsAppEntityFrameworkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class CalisanYonetimi : Form
    {
        public CalisanYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void CalisanYonetimi_Load(object sender, EventArgs e)
        {
            dgvCalisanlar.DataSource = context.Calisanlar.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Calisanlar.Add(
                    new Calisan
                    {
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        Bolum = txtBolum.Text,
                        Durum = clbDurum.Text,
                        Maas = txtMaas.Text,
                        İletisim = txtİletisim.Text,
                        Email = txtEmail.Text,
                        Adres = txtAdres.Text
                    }
                    );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvCalisanlar.DataSource = context.Calisanlar.ToList();
                    MessageBox.Show("Çalışan Kaydı Eklendi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }
        }

        private void dgvCalisanlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCalisanlar.CurrentRow.Cells[0].Value);
                var kayit = context.Calisanlar.Find(id);

                txtAd.Text = kayit.Ad;
                txtSoyad.Text = kayit.Soyad;
                txtBolum.Text = kayit.Bolum;
                clbDurum.Text = kayit.Bolum;
                txtMaas.Text = kayit.Maas;
                txtİletisim.Text = kayit.İletisim;
                txtEmail.Text = kayit.Email;
                txtAdres.Text = kayit.Adres;

                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                btnAra.Enabled = true;
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
                int id = Convert.ToInt32(dgvCalisanlar.CurrentRow.Cells[0].Value);
                var kayit = context.Calisanlar.Find(id);

                kayit.Ad = txtAd.Text;
                kayit.Soyad = txtSoyad.Text;
                kayit.Bolum = txtBolum.Text;
                kayit.Durum = clbDurum.Text;
                kayit.Maas = txtMaas.Text;
                kayit.İletisim = txtİletisim.Text;
                kayit.Email = txtEmail.Text;
                kayit.Adres = txtAdres.Text;

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvCalisanlar.DataSource = context.Calisanlar.ToList();
                    MessageBox.Show("Çalışan Kaydı Güncellendi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvCalisanlar.CurrentRow.Cells[0].Value);
                var kayit = context.Calisanlar.Find(id);
                context.Calisanlar.Remove(kayit);

                kayit.Ad = txtAd.Text;
                kayit.Soyad = txtSoyad.Text;
                kayit.Bolum = txtBolum.Text;
                kayit.Durum = clbDurum.Text;
                kayit.Maas = txtMaas.Text;
                kayit.İletisim = txtİletisim.Text;
                kayit.Email = txtEmail.Text;
                kayit.Adres = txtAdres.Text;

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvCalisanlar.DataSource = context.Calisanlar.ToList();
                    MessageBox.Show("Çalışan Kaydı Silindi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }
        }
    }
}
