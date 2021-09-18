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
    
            dgvUrunler.Columns[0].Visible = false;
            dgvUrunler.Columns[1].HeaderText = "Ürün Adı";
            dgvUrunler.Columns[2].HeaderText = "Fiyatı";
            dgvUrunler.Columns[3].HeaderText = "Stok Miktarı";
            dgvUrunler.Columns[4].HeaderText = "Başlık";
            dgvUrunler.Columns[5].HeaderText = "Açıklama";
            dgvUrunler.Columns[6].HeaderText = "Durumu";
            for (int i = 0; i < aktifÜrünler.Count(); i++)
            {
                if (aktifÜrünler[i].IsActive==true)
                {
                  

                    dgvUrunler.Rows[i].Cells[6].Value = "Aktif";
                }
                else
                {
                    dgvUrunler.Rows[i].Cells[6].Value="Pasif";
                }
         
                   
            }
            //dgvUrunler.Columns[7].Visible = false;
            //dgvUrunler.Columns[8].Visible = false;
            //dgvUrunler.Columns[9].Visible = false;
            //dgvUrunler.Columns[10].Visible = false;

            //dgvUrunler.Columns.Add("IsActive", "Durumu");
            //dgvUrunler.Columns.Add("RegisterDate", "Satın Alma Tarihi");
            //dgvUrunler.Columns.Add("CategoryId", "Kategoriler");
            //dgvUrunler.Columns.Add("UserId", "Kullanıcı");
            /////aktif olanların ismini değiştirmek istiyorum.
            //for (int i = 0; i < aktifÜrünler.Count(); i++)
            //{

            //    dgvUrunler.Rows[i].Cells[11].Value = aktifÜrünler[i].IsActive ? "Aktif" : "Pasif";
            //    dgvUrunler.Rows[i].Cells[12].Value = aktifÜrünler[i].RegisterDate.ToString("yyyy-MM-dd");
            //    dgvUrunler.Rows[i].Cells[13].Value = aktifÜrünler[i].Categories.Name;
            //    foreach (var item in aktifÜrünler[i].Users)
            //    {

            //        dgvUrunler.Rows[i].Cells[14].Value = item.Name;
            //    }

            //}
         
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
            //var aktifÜrünler = _user.Products.Where(u => u.IsActive == true).ToList();

            //for (int i = 0; i < aktifÜrünler.Count(); i++)
            //{
            //    dgvUrunler.Columns[0].Visible = false;
            //    dgvUrunler.Rows[i].Cells[1].Value = aktifÜrünler[i].Name;
            //    dgvUrunler.Rows[i].Cells[2].Value = aktifÜrünler[i].Price;
            //    dgvUrunler.Rows[i].Cells[3].Value = aktifÜrünler[i].StockAmount;
            //    dgvUrunler.Rows[i].Cells[4].Value = aktifÜrünler[i].Description;
            //    dgvUrunler.Rows[i].Cells[5].Value = aktifÜrünler[i].Title;
            //    dgvUrunler.Columns[6].Visible = false;
            //    dgvUrunler.Columns[7].Visible = false;
            //    dgvUrunler.Columns[8].Visible = false;
            //    dgvUrunler.Columns[9].Visible = false;
            //    dgvUrunler.Columns[10].Visible = false;
            //    dgvUrunler.Rows[i].Cells[11].Value = aktifÜrünler[i].IsActive ? "Aktif" : "Pasif";
            //    dgvUrunler.Rows[i].Cells[12].Value = aktifÜrünler[i].RegisterDate.ToString("yyyy-MM-dd");
            //    dgvUrunler.Rows[i].Cells[13].Value = aktifÜrünler[i].Categories.Name;
            //    foreach (var item in aktifÜrünler[i].Users)
            //    {
            //        dgvUrunler.Rows[i].Cells[14].Value = item.Name;
            //    }

            //}
            //var urunler = user.Products.ToList();
            //for (int i = 0; i < user.Products.Count(); i++)
            //{
            //    dgvUrunler.Rows[i].Cells[6].Value = urunler[i].IsActive ? "Aktif" : "Pasif";
            //    dgvUrunler.Rows[i].Cells[7].Value = urunler[i].RegisterDate.ToString("yyyy-MM-dd");
            //    dgvUrunler.Rows[i].Cells[8].Value = urunler[i].Categories.Name;
            //    foreach (var item in urunler[i].Users)
            //    {

            //        dgvUrunler.Rows[i].Cells[9].Value = item.Name;
            //    }

            //}
            //    dgvUrunler.Rows[i].Cells[6].Value = urunler[i].IsActive ? "Aktif" : "Pasif";
            //dgvUrunler.DataSource = user.Products.ToList();

            //for (int i = 0; i < aktifÜrünler.Count(); i++)
            //{
            //    dgvUrunler.Rows[i].Cells[1].Value = aktifÜrünler[i].Name;
            //    //dgvUrunler.Rows[i].Cells[2].Value = aktifÜrünler[i].Price;
            //    //dgvUrunler.Rows[i].Cells[3].Value = aktifÜrünler[i].StockAmount;
            //    //dgvUrunler.Rows[i].Cells[4].Value = aktifÜrünler[i].Title;
            //    //dgvUrunler.Rows[i].Cells[5].Value = aktifÜrünler[i].Description;
            //    //dgvUrunler.Rows[i].Cells[6].Value = aktifÜrünler[i].IsActive ? "Aktif" : "Pasif";
            //    //dgvUrunler.Rows[i].Cells[7].Value = aktifÜrünler[i].RegisterDate.ToString("yyyy-MM-dd");
            //    //dgvUrunler.Rows[i].Cells[8].Value = aktifÜrünler[i].Categories.Name;
            //    //foreach (var item in aktifÜrünler[i].Users)
            //    //{

            //    //    dgvUrunler.Rows[i].Cells[9].Value = item.Name;
            //    //}

            //}

            var aktifÜrünler = user.Products.Where(u => u.IsActive == true).ToList();
            var sonla = db.Products.ToList();
            //dgvUrunler.DataSource = aktifÜrünler.ToList();

            for (int i = 0; i < sonla.Count(); i++)
            {

                dgvUrunler.Columns[12].HeaderText = "BU cell ne istiyor";

                //foreach (var item in sonla[i].Users)
                //{

                //    dgvUrunler.Rows[i].Cells[14].Value = item.Name;
                //}
                //dgvUrunler.Rows[i].Cells[12].Value = aktifÜrünler[i].ProductId;
                //dgvUrunler.Rows[i].Cells[12].Value = aktifÜrünler[i].ProductId;

                
                
            }
            dgvUrunler.DataSource = sonla.ToList();
            //dgvUrunler.Columns[11].HeaderText = "deneme";

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
            var silinecek = dgvUrunler.SelectedRows[0].DataBoundItem as Products;
            Users user = db.Users.Find(_user.UserId);
            //Products urun = db.Products.Find(silinecek.ProductId);
            user.Products.Remove(db.Products.Find(silinecek.ProductId));
            db.SaveChanges();
            //var aktifÜrünler = _user.Products.Where(u => u.IsActive == true).ToList();

            //for (int i = 0; i < aktifÜrünler.Count(); i++)
            //{
            //    dgvUrunler.Columns[0].Visible = false;
            //    dgvUrunler.Rows[i].Cells[1].Value = aktifÜrünler[i].Name;
            //    dgvUrunler.Rows[i].Cells[2].Value = aktifÜrünler[i].Price;
            //    dgvUrunler.Rows[i].Cells[3].Value = aktifÜrünler[i].StockAmount;
            //    dgvUrunler.Rows[i].Cells[4].Value = aktifÜrünler[i].Description;
            //    dgvUrunler.Rows[i].Cells[5].Value = aktifÜrünler[i].Title;
            //    dgvUrunler.Columns[6].Visible = false;
            //    dgvUrunler.Columns[7].Visible = false;
            //    dgvUrunler.Columns[8].Visible = false;
            //    dgvUrunler.Columns[9].Visible = false;
            //    dgvUrunler.Columns[10].Visible = false;
            //    dgvUrunler.Rows[i].Cells[11].Value = aktifÜrünler[i].IsActive ? "Aktif" : "Pasif";
            //    dgvUrunler.Rows[i].Cells[12].Value = aktifÜrünler[i].RegisterDate.ToString("yyyy-MM-dd");
            //    dgvUrunler.Rows[i].Cells[13].Value = aktifÜrünler[i].Categories.Name;
            //    foreach (var item in aktifÜrünler[i].Users)
            //    {
            //        dgvUrunler.Rows[i].Cells[14].Value = item.Name;
            //    }


            //}
            dgvUrunler.DataSource = user.Products.ToList();
    
        }
    }
}
