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
    public partial class Form6 : Form
    {
        private int id;
        private Form7 f7;
        public Form6(Form7 f7, int id)
        {
            this.f7 = f7;
            this.id = id;
            InitializeComponent();
        }

        private void showData(int id)
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();
            Contact u = db.Contacts.SingleOrDefault(us => us.Contact_Id.Equals(this.id));
            textBox1.Text = u.Contact_Name;
            textBox2.Text = u.Contact_Address;
            comboBox1.SelectedIndex = u.Contact_Gender == "Male" ? 0 : 1;
            textBox3.Text = u.Contact_Email;
            textBox4.Text = u.Contact_Phone;
            dateTimePicker1.Value = u.Contact_Birthdate;
            textBox5.Text = u.Contact_NationalId;
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(u.Contact_Category);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            f7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                Contact c = db.Contacts.SingleOrDefault(us => us.Contact_Id.Equals(this.id));
                c.Contact_Name = textBox1.Text;
                c.Contact_Address = textBox2.Text;
                c.Contact_Gender = comboBox1.SelectedItem.ToString();
                c.Contact_Email = textBox3.Text;
                c.Contact_Phone = textBox4.Text;
                c.Contact_Birthdate = dateTimePicker1.Value;
                c.Contact_NationalId = textBox5.Text;
                c.Contact_Category = comboBox2.SelectedItem.ToString();
                db.SaveChanges();

                MessageBox.Show("Updated");
                f7.LoadDataFromDatabase();
                this.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to update.");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();
            comboBox2.DataSource = db.Categories.Select(c => c.CategoryName).ToList();

            showData(this.id);
        }
    }
}
