using PaMyStoreWindowsFormApp.Models.EntityFramework;
using PaMyStoreWindowsFormApp.Views.Home;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       
        MyStoreContext db = new MyStoreContext();  /// Database'in örneğini oluşturdum. Bu örnekten tablolarıma erişim sağladım.
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
       

            string email = txtEmail.Text; 
            string password = txtPassword.Text;

        Users user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password); /// FirsOrDefaul aktif mi pasif mi bakmaz sorguya uyan ilk veriyi getirir.

            if (user!=null) /// kullanıcım boş gelmediyse, böyle biri varsa
            {

                if (user.IsActive==true) /// benim kullanıcım şu an aktif mi ?
                {

                    foreach (var item in user.Roles) /// Bana gelen kullanıcımın Rol listesini kontrol ediyorum
                    {
                        if (item.RolId==1)// bu adam adminse buraya girecek--- admin
                        {
                            //admin
                            AdminPanel frm = new AdminPanel(user);
                            frm.Show();
                            this.Hide();

                        }
                        else// admin değilse buraya girecek yani----- user
                        {
                            //user
                            UserPanel frm = new UserPanel(user);
                            frm.Show();
                            this.Hide();
                        }
                    }

                }
                else // eğer ki kullanıcı şu an aktif değilse 
                {
                    MessageBox.Show("Kullacı Aktif Değil!!");
                }

            }
            else// eğer ki böyle böyle bir kullanıcı yoksa hata mesajım
            {
                lblHata.Text = "Kullanıcı Adı veya Şifre Hatalı!"; 

                //eğer benim kullanıcım yanlış şifre girdiyse timer'ı başlat.
                 timer1.Enabled = true;
                 timer1.Interval = 2000;  // iki saniye saydıktan sonra timer metodumun içindeki blogu çalıştırdı.
                sayacım++;
              
                if (sayacım>=3)
                {
                    lblRandom.Visible = true;
                    txtRobotMusun.Visible = true;
                    btnKontrol.Visible = true;
  
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)  // Timer kullanladık. 
        {
            lblHata.Text = "";
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.Show();
            this.Hide();
        }

        int sayacım = 0;
        private void btnKontrol_Click(object sender, EventArgs e)
        {
        
            if (lblRandom.Text == txtRobotMusun.Text)
            {
                sayacım = 0;
                MessageBox.Show("Robot Değilsin :) Tekrar giriş yapmayı dene");
                lblRandom.Visible = false;
                txtRobotMusun.Visible = false;
                btnKontrol.Visible = false;
                lblRandom.Text = rdb.Next(1000, 9999).ToString();
            }
        }

        Random rdb = new Random();
        private void Login_Load(object sender, EventArgs e)
        {
            lblRandom.Text = rdb.Next(1000, 9999).ToString();
        }
    }
}
