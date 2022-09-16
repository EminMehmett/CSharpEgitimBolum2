using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppEntityFrameworkCodeFirst.Data;
using WindowsFormsAppEntityFrameworkCodeFirst.Entities;

namespace WindowsFormsAppEntityFrameworkCodeFirst
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            dgvKullanıcılar.DataSource = context.Kullanıcılar.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Kullanıcılar.Add(
                    new Kullanıcı
                    {
                        Adi = txtKullaniciAdi.Text,
                        Telefon = Convert.ToInt32(txtTelefon.Text),
                        Email = txtEmail.Text,
                        Adres = txtAdres.Text
                    }

                    );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKullanıcılar.DataSource = context.Kullanıcılar.ToList();
                    MessageBox.Show("Kullanıcı Kaydı Eklendi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }
        }

        private void dgvKullanıcılar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvKullanıcılar.CurrentRow.Cells[0].Value);
                var kayit = context.Kullanıcılar.Find(id);

                txtKullaniciAdi.Text = kayit.Adi;
                txtTelefon.Text = Convert.ToInt32(kayit.Telefon).ToString();
                txtEmail.Text = kayit.Email;
                txtAdres.Text = kayit.Email;

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
                int id = Convert.ToInt32(dgvKullanıcılar.CurrentRow.Cells[0].Value);
                var kayit = context.Kullanıcılar.Find(id);

                kayit.Adi = txtKullaniciAdi.Text;
                kayit.Telefon = Convert.ToInt32(txtTelefon.Text);
                kayit.Email = txtEmail.Text;
                kayit.Adres = txtAdres.Text;

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKullanıcılar.DataSource = context.Kullanıcılar.ToList();
                    MessageBox.Show("Kullanıcı Kaydı Güncellendi!");
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
                int id = Convert.ToInt32(dgvKullanıcılar.CurrentRow.Cells[0].Value);
                var kayit = context.Kullanıcılar.Find(id);
                context.Kullanıcılar.Remove(kayit);

                kayit.Adi = txtKullaniciAdi.Text;
                kayit.Telefon = Convert.ToInt32(txtTelefon.Text);
                kayit.Email = txtEmail.Text;
                kayit.Adres = txtAdres.Text;

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKullanıcılar.DataSource = context.Kullanıcılar.ToList();
                    MessageBox.Show("Kullanıcı Kaydı Silindi!");
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }
        }
    }
}
