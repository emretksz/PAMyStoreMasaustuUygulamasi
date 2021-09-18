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

namespace PaMyStoreWindowsFormApp.Views.CategoryForms
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        MyStoreContext db = new MyStoreContext();
        private void btnEkle_Click(object sender, EventArgs e)
        {

            Categories kategori = new Categories();
            kategori.Name = txtKategori.Text;
            kategori.IsActive = chkDurum.Checked;
            kategori.RegisterDate = DateTime.Now;

            db.Categories.Add(kategori);
            db.SaveChanges();
            //dgvKategoriler.DataSource = db.Categories.ToList();
            dgvKategoriler.DataSource = db.Categories.ToList() ;


        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = db.Categories.ToList();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Buton şekil yapıları.
            ///neden rows[0]. Diğer rowlarda neden hata alınıyor.
                    


            var sonuc = dgvKategoriler.SelectedRows[0].DataBoundItem as Categories;
           
            MessageBox.Show(sonuc.Name);
        }
    }
}
