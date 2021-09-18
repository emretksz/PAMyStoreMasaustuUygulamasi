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

namespace PaMyStoreWindowsFormApp.Views.Accounts
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        MyStoreContext db = new MyStoreContext();
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            UserDetails detail = new UserDetails();
 
            user.Name = txtIsim.Text;
            user.Password = txtSifre.Text;
            user.Email = txtMail.Text;
            user.RegisterDate = DateTime.Now;
            user.IsActive = true;

            detail.Age = Convert.ToByte(txtYas.Text);
            detail.Birthday = dtpDogum.Value;
            detail.Gender = rdbErkek.Checked == true ? true : rdbKadin.Checked == true;
            detail.TcNu = txtTcNu.Text;


            foreach (var item in db.Roles)   // database'deki rol tablolarındaki veriler dönüldü.
            {
                if (item.RolId==2)  /// rol id'si 2 olan yani user olan item geldiğinde bunu userımın rollerine ekle demiş oldum.
                {
                    user.Roles.Add(item);
                }
            }
            db.Users.Add(user);
            db.UserDetails.Add(detail);
            db.SaveChanges();    /// yaptığım değişiklikleri kaydetmeme yarıyor.



        }
    }
}
