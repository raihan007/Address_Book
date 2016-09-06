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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

            try
            {
                User u =
                db.Users.SingleOrDefault(
                    user => user.Username == textBox1.Text && user.Password == textBox2.Text);
                if (u != null)
                {
                    this.Hide();
                    Form3 f3 = new Form3(u);
                    f3.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Username or Password.");
            }
        }
    }
}
