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
    public partial class Form2 : Form
    {
        private Form1 f1;
        public Form2(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                User u = new User();
                u.Name = textBox1.Text;
                u.Address = textBox2.Text;
                u.Gender = comboBox1.SelectedItem.ToString();
                u.Email = textBox3.Text; 
                u.Phone = textBox4.Text;
                u.Birthdate = dateTimePicker1.Value;
                u.NationalId = textBox5.Text;
                u.Username = textBox6.Text;
                u.Password = textBox7.Text;

                db.Users.Add(u);
                db.SaveChanges();

                MessageBox.Show("Registration Done.Now you can login!");

                this.Dispose();
                f1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Somethings Wrong. Please try again.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            f1.Show();
        }
    }
}
