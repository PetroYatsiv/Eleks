using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var service = new ServiceContactReference.ServiceContactClient();

            var userId = service.Authorization(LoginTxt.Text, PasswordTxt.Text);

            if (userId != null)
            {
                UserContact form = new UserContact(userId);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong login or password!.",
                    "Wrong data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
    }
}
