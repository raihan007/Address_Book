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
    public partial class Form7 : Form
    {
        private int id;
        private Form3 f3;
        private int contactId = 0;
        public Form7(Form3 f3, int id)
        {
            this.f3 = f3;
            this.id = id;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        public void LoadDataFromDatabase()
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

            dataGridView1.DataSource = db.Contacts.Where(c => c.Contact_UserId.Equals(this.id)).ToList();
            if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Selected = false;
            dataGridView1.Columns[10].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(this, this.id);
            f8.ShowDialog();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            contactId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contactId != 0)
            {
                Form6 f6 = new Form6(this, this.contactId);
                f6.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Any Row First.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (contactId != 0)
            {
                try
                {
                    AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                    Contact c = db.Contacts.SingleOrDefault(p => p.Contact_Id.Equals(this.contactId));

                    db.Contacts.Remove(c);
                    db.SaveChanges();

                    MessageBox.Show("Successfully Deleted.");

                    LoadDataFromDatabase();
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to Delete.");
                }
            }
            else
            {
                MessageBox.Show("Select Any Row First.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

            dataGridView1.DataSource = db.Contacts.Where(c => c.Contact_UserId == this.id && (c.Contact_Name.Contains(textBox1.Text) || c.Contact_Email.Contains(textBox1.Text) || c.Contact_Phone.Contains(textBox1.Text))).ToList();
            if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Selected = false;
            dataGridView1.Columns[10].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (contactId != 0)
            {
                Form6 f6 = new Form6(this, this.contactId);
                f6.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select Any Row First.");
            }
        }
    }
}
