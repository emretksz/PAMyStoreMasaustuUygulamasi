using PaMyStoreWindowsFormApp.Models.EntityFramework;
using PaMyStoreWindowsFormApp.Views.Store;
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
    public partial class UserPanel : Form
    {

        Users _user; 
        public UserPanel(Users user)
        {
            InitializeComponent();
            _user = user;
        }
       

        private void UserPanel_Load(object sender, EventArgs e)
        {
            MessageBox.Show("User paneli");
            lblKullanici.Text = _user.Name;

        }

        private void btnAlisveris_Click(object sender, EventArgs e)
        {
            StoreForm frm = new StoreForm(_user);
            frm.Show();
            this.Hide();
        }
    }
}
