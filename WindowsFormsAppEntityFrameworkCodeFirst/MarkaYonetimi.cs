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
    public partial class MarkaYonetimi : Form
    {
        public MarkaYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void MarkaYonetimi_Load(object sender, EventArgs e)
        {
            dgvMarkalar.DataSource = context.Markalar.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Markalar.Add(
                    new Marka
                    {
                        Adi = txtMarkaAdi.Text,
                        Alan = txtMarkaAlanı.Text
                    }
                    );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvMarkalar.DataSource = context.Markalar.ToList();
                    MessageBox.Show("Marka Kaydı Eklendi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvMarkalar.CurrentRow.Cells[0].Value);

            var kayit = context.Markalar.Find(id);

            txtMarkaAdi.Text = kayit.Adi;
            txtMarkaAlanı.Text = kayit.Alan;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dgvMarkalar.CurrentRow.Cells[0].Value);

                var kayit = context.Markalar.Find(id);

                kayit.Adi = txtMarkaAdi.Text;
                kayit.Alan = txtMarkaAlanı.Text;

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvMarkalar.DataSource = context.Markalar.ToList();
                    MessageBox.Show("Marka Kaydı Güncellendi!");
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
                int id = Convert.ToInt32(dgvMarkalar.CurrentRow.Cells[0].Value);

                var kayit = context.Markalar.Find(id);

                context.Markalar.Remove(kayit);

                kayit.Adi = txtMarkaAdi.Text;
                kayit.Alan = txtMarkaAlanı.Text;

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvMarkalar.DataSource = context.Markalar.ToList();
                    MessageBox.Show("Marka Kaydı Silindi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!", hata.Message);
            }

        }
    }
}
