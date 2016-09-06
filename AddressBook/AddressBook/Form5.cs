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
    public partial class Form5 : Form
    {
        private int id;
        private Form3 f3;
        public Form5(Form3 f3)
        {
            this.f3 = f3;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

            dataGridView1.DataSource = db.Categories.ToList();
            if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Selected = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                Category c = new Category();
                c.CategoryName = textBox2.Text;

                db.Categories.Add(c);
                db.SaveChanges();

                MessageBox.Show("Category Saved!");
                ClearInputField();
                LoadDataFromDatabase();
            }
            catch (Exception)
            {
                MessageBox.Show("Somethings Wrong. Please try again.");
            }
        }

        private void ClearInputField()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Selected = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                Category c = db.Categories.SingleOrDefault(p => p.CategoryId.Equals(this.id));

                db.Categories.Remove(c);
                db.SaveChanges();

                MessageBox.Show("Successfully Deleted.");
                ClearInputField();
                LoadDataFromDatabase();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to Delete.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AddressBookDatabaseEntities db = new AddressBookDatabaseEntities();

                Category c = db.Categories.SingleOrDefault(p => p.CategoryId.Equals(this.id));
                c.CategoryName = textBox2.Text;
                db.SaveChanges();

                MessageBox.Show("Successfully Updated.");
                ClearInputField();
                LoadDataFromDatabase();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to Update.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearInputField();
        }
    }
}
