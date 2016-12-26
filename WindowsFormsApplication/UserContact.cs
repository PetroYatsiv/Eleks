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
    public partial class UserContact : Form
    {
        private int userId { get; set; }

        private ServiceContactReference.ServiceContactClient service { get; set; }

        private int selectedContactId { get; set; }

        public UserContact(int? userId)
        {
            InitializeComponent();
            this.userId = (int)userId;

            service = new ServiceContactReference.ServiceContactClient();
            RefreshTable();

            UserName.Text = service.GetUserName((int)userId);
        }

        private void RefreshTable()
        {
            var contacts = service.GetListContact((int)userId);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            for (int i = 0; i < contacts.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = contacts[i].Name;
                dataGridView1.Rows[i].Cells[1].Value = contacts[i].Phone;
                dataGridView1.Rows[i].Cells[2].Value = contacts[i].Address;
                dataGridView1.Rows[i].Cells[3].Value = contacts[i].Id.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                service.DeleteContact(new DAL.Model.Contact()
                {
                    ContactId = this.selectedContactId,
                    ContactAddress = this.ContactAddress.Text,
                    ContactName = this.ContactName.Text,
                    ContactPhone = this.ContactPhone.Text,
                    UserRef = this.userId
                });

                MessageBox.Show("Successfully!.",
                    "Contact deleted!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                RefreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed!.",
                    ex.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                service.EditContact(new DAL.Model.Contact()
                {
                    ContactId = this.selectedContactId,
                    ContactAddress = this.ContactAddress.Text,
                    ContactName = this.ContactName.Text,
                    ContactPhone = this.ContactPhone.Text,
                    UserRef = this.userId
                });

                MessageBox.Show("Successfully!.",
                    "Contact edited!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);

                RefreshTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed!.",
                    ex.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentCell.RowIndex;
                var value = dataGridView1.Rows[row].Cells[3];
                this.selectedContactId = Convert.ToInt32(value.Value);
                var contact = service.GetListContact((int)userId).Where(s => s.Id == this.selectedContactId).FirstOrDefault();

                this.ContactName.Text = contact.Name;
                this.ContactPhone.Text = contact.Phone;
                this.ContactAddress.Text = contact.Address;

                this.button1.Enabled = true;
                this.button2.Enabled = true;
            }
            catch
            {
                this.ContactName.Text = "";
                this.ContactPhone.Text = "";
                this.ContactAddress.Text = "";
                this.button1.Enabled = false;
                this.button2.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                service.AddContact(new DAL.Model.Contact()
                {
                    ContactAddress = this.textBox2.Text,
                    ContactName = this.textBox4.Text,
                    ContactPhone = this.textBox3.Text,
                    UserRef = this.userId
                });

                MessageBox.Show("Successfully!.",
                    "Contact added!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);

                RefreshTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed!.",
                    ex.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
