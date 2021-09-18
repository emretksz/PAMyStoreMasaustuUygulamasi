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

namespace PaMyStoreWindowsFormApp.Views.UserForms
{
    public partial class UserAll : Form
    {
        public UserAll()
        {
            InitializeComponent();              
        }
        MyStoreContext db = new MyStoreContext();
        private void UserAll_Load(object sender, EventArgs e)
        {
            dgvKullanici.DataSource = db.Users.ToList();
        }
        int id = 0;
        private void btnSil_Click(object sender, EventArgs e)
        {
            var secilen =  dgvKullanici.SelectedRows[0].DataBoundItem as Users;
          

            Users user = db.Users.Find(secilen.UserId);

            foreach (var item in db.Roles)
            {
                if (secilen.Roles==item)
                {
                    user.Roles.Remove(item);

                }
            }
           
            db.Users.Remove(user);
            db.SaveChanges();
            dgvKullanici.DataSource = db.Users.ToList();


        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            var secilen = dgvKullanici.SelectedRows[0].DataBoundItem as Users;
            id = secilen.UserId;
            UserEdit frm = new UserEdit(id);
            frm.Show();
            this.Hide();
        }
    }
}
