using PaMyStoreWindowsFormApp.Views.Accounts;
using PaMyStoreWindowsFormApp.Views.CategoryForms;
using PaMyStoreWindowsFormApp.Views.ProductForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaMyStoreWindowsFormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
