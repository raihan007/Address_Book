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
    public partial class Form8 : Form
    {
        private Form7 f1;
        private int id;
        public Form8(Form7 f1,int id)
        {
            this.f1 = f1;
            this.id = id;
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                Contact u = new Contact();
                u.Contact_Name = textBox1.Text;
                u.Contact_Address = textBox2.Text;
                u.Contact_Gender = comboBox1.SelectedItem.ToString();
                u.Contact_Email = textBox3.Text; 
                u.Contact_Phone = textBox4.Text;
                u.Contact_Birthdate = dateTimePicker1.Value;
                u.Contact_NationalId = textBox5.Text;
                u.Contact_Category = comboBox2.SelectedItem.ToString();
                u.Contact_UserId = this.id;
                db.Contacts.Add(u);
                db.SaveChanges();

                MessageBox.Show("Saved.");

                this.Dispose();
                f1.LoadDataFromDatabase();
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

        private void Form8_Load(object sender, EventArgs e)
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();
            comboBox2.DataSource = db.Categories.Select(c => c.CategoryName).ToList();
        }
    }
}
