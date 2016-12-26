using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService1;
using WindowsFormsApplication.ServiceContactReference;

namespace WindowsFormsApplication
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            var service = new ServiceContactReference.ServiceContactClient();
            
            var user = new User()
            {
                UserName = UserName.Text,
                UserLogin = UserLogin.Text,
                UserPassword = UserPassword.Text
            };

            service.RegisterUser(user);
        }
    }
}
