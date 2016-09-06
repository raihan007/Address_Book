using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Form4 : Form
    {
        private int id;
        private Form3 f3;
        public Form4(Form3 f3, int id)
        {
            this.f3 = f3;
            this.id = id;
            InitializeComponent();
            showData(this.id);
        }

        private void showData(int id)
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();
            User u = db.Users.SingleOrDefault(us => us.UserId.Equals(this.id));
            textBox1.Text = u.Name;
            textBox2.Text = u.Address;
            comboBox1.SelectedIndex = u.Gender == "Male" ? 0 : 1;
            textBox3.Text = u.Email;
            textBox4.Text = u.Phone;
            dateTimePicker1.Value = u.Birthdate;
            textBox5.Text = u.NationalId;
            textBox6.Text = u.Username;
            textBox7.Text = u.Password;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                User user = db.Users.SingleOrDefault(us => us.UserId.Equals(this.id));
                user.Name = textBox1.Text;
                user.Address = textBox2.Text;
                user.Gender = comboBox1.SelectedItem.ToString();
                user.Email = textBox3.Text;
                user.Phone = textBox4.Text;
                user.Birthdate = dateTimePicker1.Value;
                user.NationalId = textBox5.Text;
                user.Username = textBox6.Text;
                user.Password = textBox7.Text;

                db.SaveChanges();

                MessageBox.Show("Updated");
                showData(user.UserId);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to update.");
            }
        }
    }
}
