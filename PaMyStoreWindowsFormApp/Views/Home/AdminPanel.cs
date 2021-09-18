using PaMyStoreWindowsFormApp.Models.EntityFramework;
using PaMyStoreWindowsFormApp.Views.CategoryForms;
using PaMyStoreWindowsFormApp.Views.ProductForm;
using PaMyStoreWindowsFormApp.Views.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaMyStoreWindowsFormApp.Views.Home
{
    public partial class AdminPanel : Form
    {
        Users _user;
        public AdminPanel(Users user)
        {
            InitializeComponent();

            _user = user;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            lblKullanici.Text = _user.Name;
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            UserAll frm = new UserAll();
            frm.Show();
            this.Hide();


           
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            CategoryForm frm = new CategoryForm();
            frm.Show();
            this.Hide();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            ProductAll frm = new ProductAll();
            frm.Show();
            this.Hide();
        }
    }
}
