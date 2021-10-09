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

namespace PaMyStoreWindowsFormApp.Views.Store
{
    public partial class StoreForm : Form
    {

        Users _user;
        public StoreForm(Users user)
        {
            InitializeComponent();
            _user = user;
        }

        MyStoreContext db = new MyStoreContext();
        private void StoreForm_Load(object sender, EventArgs e )
        {
            cmbKategori.DataSource = db.Categories.Where(u => u.IsActive == true).ToList();
            cmbKategori.DisplayMember = "Name";
            cmbKategori.ValueMember = "CategoryId";
            //lstUrunler.DataSource = db.Products.Where(p => p.IsActive == true).ToList();
            lstUrunler.DisplayMember = "Name";
            dgvUrunler.DataSource = _user.Products.ToList();
            txtKullanici.Text = _user.Name;

            var aktifÜrünler = _user.Products.Where(u => u.IsActive == true).ToList();

            DataTable tablo = new DataTable();
            tablo.Columns.Add("Ürün Adı", typeof(string));
            tablo.Columns.Add("Fiyatı", typeof(string));
            tablo.Columns.Add("Stok Miktarı", typeof(string));
            tablo.Columns.Add("Başlık", typeof(string));
            tablo.Columns.Add("Açıklama", typeof(string));
            tablo.Columns.Add("Durumu", typeof(string));
            tablo.Columns.Add("Satın Alma Tarihi", typeof(string));
            tablo.Columns.Add("Kategoriler", typeof(string));
            tablo.Columns.Add("Kullanıcı", typeof(string));

            dgvUrunler.DataSource = tablo;
            for (int i = 0; i < aktifÜrünler.Count; i++)
            {
                tablo.Rows.Add(
                    aktifÜrünler[i].Name,
                    aktifÜrünler[i].Price,
                    aktifÜrünler[i].StockAmount,
                    aktifÜrünler[i].Title,
                    aktifÜrünler[i].Description,
                    aktifÜrünler[i].IsActive ? "Aktif" : "Pasif".ToString(),
                    aktifÜrünler[i].RegisterDate.ToString("yyyy-MM-dd"),
                    aktifÜrünler[i].Categories.Name,
                    _user.Name

                    );
            }
         
        }

        private void btnEkle_Click(object sender, EventArgs e) /// hata alıyoruz burası düzeltilmesi gerekiyor cell mi hatalı row mu ??
        {
            Users user = db.Users.Find(_user.UserId); //aliyi bul getir;

            foreach (var urun in lstUrunler.SelectedItems)
            {
                user.Products.Add(urun as Products);
                //product eklemek istediğim için döngümden bana sadece obje döndüğü için hata aldım
                //o yüzden AS PRODUCT YAZARAK ONU PRODUCT TİPİNDE BİR OBJE OLDUĞUNU BELİRTMİŞ OLDUM
            }
            db.SaveChanges();
          
            var aktifÜrünler = user.Products.Where(u => u.IsActive == true).ToList();
            var sonla = db.Products.ToList();
            //dgvUrunler.DataSource = aktifÜrünler.ToList();
            DataTable tablo = new DataTable();
            tablo.Columns.Add("Ürün Adı", typeof(string));
            tablo.Columns.Add("Fiyatı", typeof(string));
            tablo.Columns.Add("Stok Miktarı", typeof(string));
            tablo.Columns.Add("Başlık", typeof(string));
            tablo.Columns.Add("Açıklama", typeof(string));
            tablo.Columns.Add("Durumu", typeof(string));
            tablo.Columns.Add("Satın Alma Tarihi", typeof(string));
            tablo.Columns.Add("Kategoriler", typeof(string));
            tablo.Columns.Add("Kullanıcı", typeof(string));

            dgvUrunler.DataSource = tablo;
            for (int i = 0; i < aktifÜrünler.Count; i++)
            {
                tablo.Rows.Add(
                    aktifÜrünler[i].Name,
                    aktifÜrünler[i].Price,
                    aktifÜrünler[i].StockAmount,
                    aktifÜrünler[i].Title,
                    aktifÜrünler[i].Description,
                    aktifÜrünler[i].IsActive ? "Aktif" : "Pasif".ToString(),
                    aktifÜrünler[i].RegisterDate.ToString("yyyy-MM-dd"),
                    aktifÜrünler[i].Categories.Name,
                    _user.Name

                    );
            }

        }

        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var secilen = lstUrunler.SelectedItem as Products;

            if (lstUrunler.SelectedIndex != -1)
            {
                txtBaslik.Text = secilen.Title;
                txtAciklama.Text = secilen.Description;
                txtFiyat.Text = secilen.Price;
                txtStok.Text = secilen.StockAmount;
            }
            else
                MessageBox.Show("Ürün seçmedin");
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categories deneme = cmbKategori.SelectedItem as Categories;
            for (int i = 0; i < db.Products.Count(); i++)
            {
                lstUrunler.DataSource = db.Products.Where(c => c.CategoryId == deneme.CategoryId).ToList();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var silinecek = dgvUrunler.SelectedRows[0].Cells[0].Value.ToString();
            List<Products> listem = db.Products.Where(u => u.Name == silinecek).ToList();
            Users user = db.Users.Find(_user.UserId);
            for (int i = 0; i < listem.Count; i++)
            {
            user.Products.Remove(listem[i]);
            }
            db.SaveChanges();
            //DataTable tablo = new DataTable();
            //tablo.Columns.Add("Ürün Adı", typeof(string));
            //tablo.Columns.Add("Fiyatı", typeof(string));
            //tablo.Columns.Add("Stok Miktarı", typeof(string));
            //tablo.Columns.Add("Başlık", typeof(string));
            //tablo.Columns.Add("Açıklama", typeof(string));
            //tablo.Columns.Add("Durumu", typeof(string));
            dgvUrunler.Rows.RemoveAt(dgvUrunler.SelectedRows[0].Index);
            db.SaveChanges();
    
        }
    }
}
