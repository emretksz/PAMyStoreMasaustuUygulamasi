using PaMyStoreWindowsFormApp.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaMyStoreWindowsFormApp.Views.ProductForm
{
    public partial class ProductAll : Form
    {
        public ProductAll()
        {
            InitializeComponent();
        }
        MyStoreContext db = new MyStoreContext();
        private void btnEkle_Click(object sender, EventArgs e)
        {

            Products urun = new Products();  // yeni ürün nesnesi oluşturuldu

            urun.Name = txtUrunAdi.Text;
            urun.Title = txtBaslik.Text;
            urun.StockAmount = txtStok.Text;
            urun.Price = txtFiyat.Text;
            urun.RegisterDate = DateTime.Now;
            urun.IsActive = chkDurum.Checked;
            urun.Description = txtAciklama.Text;
            urun.CategoryId = Convert.ToInt32(cmbKategori.SelectedValue);  // gelen deger int'e çevrildi

            db.Products.Add(urun);
            db.SaveChanges();
            dgvUrunler.DataSource = db.Products.ToList();

        }

        private void ProductAll_Load(object sender, EventArgs e)
        {
            cmbKategori.DataSource = db.Categories.Where(c => c.IsActive == true).ToList();
            cmbKategori.DisplayMember = "Name";   /// objemin görünecek ismi
            cmbKategori.ValueMember = "CategoryId"; /// combobox'taki olan objelerin valuesu == benşm categoryıD

            dgvUrunler.DataSource = db.Products.ToList();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var secilen = dgvUrunler.SelectedRows[0].DataBoundItem as Products;

            foreach (var item in db.Products)
            {
                Users user = db.Users.Find(item.ProductId); 
                user.Products.Remove(db.Products.Find(item.ProductId));
            }
            Products sil = db.Products.Find(secilen.ProductId);
            db.Products.Remove(sil);
            db.SaveChanges();
            dgvUrunler.DataSource = db.Products.ToList();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            /// DÜZENLE BÖLÜMÜ  BULDUGUM ÜRÜNÜMÜ YENİ VERİLERLE DEĞİŞTİRİYORUM
            var secilen = dgvUrunler.SelectedRows[0].DataBoundItem as Products;
            secilen.Name = txtUrunAdi.Text;
            secilen.Price = txtFiyat.Text;
            secilen.IsActive = chkDurum.Checked;
            secilen.Description = txtAciklama.Text;
            secilen.Title = txtBaslik.Text;
            secilen.StockAmount = txtStok.Text;

            secilen.CategoryId = (int)cmbKategori.SelectedValue;

            db.SaveChanges();
            dgvUrunler.DataSource = db.Products.ToList();

        }

        private void dgvUrunler_DoubleClick(object sender, EventArgs e)
        {
            var secilen = dgvUrunler.SelectedRows[0].DataBoundItem as Products;

            txtUrunAdi.Text = secilen.Name;
            txtBaslik.Text = secilen.Title;
            txtFiyat.Text = secilen.Price;
            txtStok.Text = secilen.StockAmount;
            txtAciklama.Text = secilen.Description;
            chkDurum.Checked = secilen.IsActive;
            if (secilen.Categories.CategoryId != 0)
            {
                cmbKategori.SelectedValue = secilen.CategoryId;
            }
        }
    }
}
