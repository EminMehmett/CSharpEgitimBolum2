using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppEntityFrameworkDbFirst
{
    public partial class KategoriYonetimi2 : Form
    {
        public KategoriYonetimi2()
        {
            InitializeComponent();
        }

        UrunYonetimiAdoNetEntities context = new UrunYonetimiAdoNetEntities();

        private void KategoriYonetimi2_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = context.Kategoriler.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                context.Kategoriler.Add(new Kategoriler
                {
                    KategoriAdi = txtKategoriAdi.Text,
                    Durum = cbDurum.Checked
                }
                );
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kategori Eklendi!");
                }
                else MessageBox.Show("Kayıt Eklenemedi!");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenKategoriId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);

            var kayit = context.Kategoriler.Find(secilenKategoriId);

            txtKategoriAdi.Text = kayit.KategoriAdi;
            cbDurum.Checked = Convert.ToBoolean(kayit.Durum);

            btnGüncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenkayitId = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value);

                var kayit = context.Kategoriler.Find(secilenkayitId);

                kayit.KategoriAdi = txtKategoriAdi.Text;
                kayit.Durum = Convert.ToBoolean(cbDurum.Checked);

                var sonuc = context.SaveChanges();

                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
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
                int secilenKayitId = Convert.ToInt16(dgvKategoriler.CurrentRow.Cells[0].Value);

                var kayit = context.Kategoriler.Find(secilenKayitId);

                context.Kategoriler.Remove(kayit);

                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kategori Silindi!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu!" + hata.Message);
            }
        }
    }
}
