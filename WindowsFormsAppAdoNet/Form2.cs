using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ProductDAL2 productDAL2 = new ProductDAL2();
        private void Form2_Load(object sender, EventArgs e)
        {
            dgvUrunListesi.DataSource = productDAL2.GetProducts();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            productDAL2.Add(
                new Product
                {
                    UrunAdi = txtUrunAdi.Text,
                    StokMiktari = Convert.ToInt32(txtStokMiktari.Text),
                    UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text)
                }
                );
            dgvUrunListesi.DataSource = productDAL2.GetProducts();
            MessageBox.Show("Ürün Eklendi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            productDAL2.Update(
               new Product
               {
                   Id = Convert.ToInt32(lblId.Text),
                   UrunAdi = txtUrunAdi.Text,
                   StokMiktari = Convert.ToInt32(txtStokMiktari.Text),
                   UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text)
               }
               );
            dgvUrunListesi.DataSource = productDAL2.GetProducts();
            MessageBox.Show("Ürün Güncellendi!");
        }

        private void dgvUrunListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dgvUrunListesi.CurrentRow.Cells[0].Value.ToString();
            txtUrunAdi.Text = dgvUrunListesi.CurrentRow.Cells[1].Value.ToString();
            txtUrunFiyati.Text = dgvUrunListesi.CurrentRow.Cells[2].Value.ToString();
            txtStokMiktari.Text = dgvUrunListesi.CurrentRow.Cells[3].Value.ToString();

        }
    }
}
