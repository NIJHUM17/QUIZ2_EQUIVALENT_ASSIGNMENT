using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_AssignmentFinal
{
    public partial class AllBooks : Form
    {
        public AllBooks()
        {
            InitializeComponent();
            var conn = Database.ConnectDB();
            conn.Open();
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ArrayList books = new ArrayList();
            while(reader.Read())
            {
                Book b = new Book();

                b.Id = reader.GetString(reader.GetOrdinal("Id"));
                b.Name = reader.GetString(reader.GetOrdinal("Name"));
                b.Author = reader.GetString(reader.GetOrdinal("Author"));
                b.Edition = reader.GetString(reader.GetOrdinal("Edition"));

                books.Add(b);
            }
            conn.Close();
            dgvBooks.DataSource = books;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void AllBooks_Load(object sender, EventArgs e)
        {
            var conn = Database.ConnectDB();
            conn.Open();
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBooks.DataSource = dt;
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var conn = Database.ConnectDB();
            conn.Open();
            string query = String.Format("SELECT * FROM Books WHERE Name like '%{0}%'",tbSearch.Text);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBooks.DataSource = dt;
            conn.Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var name = tbSearch.Text;
            new Dashboard(name).Show();
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Book b = new Book();

                b.Id = dgvBooks.SelectedRows[0].Cells[0].Value.ToString();
                b.Name = dgvBooks.SelectedRows[0].Cells[1].Value.ToString();
                b.Author = dgvBooks.SelectedRows[0].Cells[2].Value.ToString();
                b.Edition = dgvBooks.SelectedRows[0].Cells[3].Value.ToString();

                string query = String.Format("SELECT * FROM Books WHERE Name='{0}'", b.Name);
                string output = String.Format("Book Id : {0}" +
                    "\nBook Name : {1}" +
                    "\nBook Author : {2}" +
                    "\nBook Edition : {3}", b.Id, b.Name, b.Author, b.Edition);

                new Dashboard(output, query).Show();
            }
        }
    }
}
