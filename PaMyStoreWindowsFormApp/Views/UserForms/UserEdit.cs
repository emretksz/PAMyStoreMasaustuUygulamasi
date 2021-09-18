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
    public partial class UserEdit : Form
    {

        int _id;
        public UserEdit(int id)
        {
            InitializeComponent();
            _id = id;
        }

        MyStoreContext db = new MyStoreContext();
        private void UserEdit_Load(object sender, EventArgs e)
        {
            Users user = db.Users.Find(_id);

            txtIsim.Text = user.Name;
            txtMail.Text = user.Email;
            txtSifre.Text = user.Password;
            txtTcNu.Text = user.UserDetails.TcNu;
            txtYas.Text = user.UserDetails.Age.ToString();
            if (user.UserDetails.Gender == true)
            {
                rdbErkek.Checked = true;
            }
            else
            {
                rdbKadin.Checked = true;
            }
           

            dtpDogum.Value = user.UserDetails.Birthday.Value;
            chkDurum.Checked = user.IsActive.Value;


        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Users user = db.Users.Find(_id);
            user.Email = txtMail.Text;
            user.IsActive = chkDurum.Checked;
            user.Name = txtIsim.Text;
            user.Password = txtSifre.Text;
            user.RegisterDate = DateTime.Now;
            user.UserDetails.Age = Convert.ToByte(txtYas.Text);
            user.UserDetails.Birthday = dtpDogum.Value;
            user.UserDetails.TcNu = txtTcNu.Text;
            if (rdbErkek.Checked == true)
            {
                user.UserDetails.Gender = true;
            }
            else
            {
                user.UserDetails.Gender = false;    
            }
            db.SaveChanges();
            UserAll frm = new UserAll();
            frm.Show();
            this.Close();
        }
    }
}
