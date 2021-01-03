using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard() { }
        public Dashboard(string name)
        {
            InitializeComponent();
            var conn = Database.ConnectDB();
            conn.Open();
            string query = String.Format("SELECT * FROM Books WHERE Name='{0}'",name);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Book b = new Book();
            while (reader.Read())
            {

                b.Id = reader.GetString(reader.GetOrdinal("Id"));
                b.Name = reader.GetString(reader.GetOrdinal("Name"));
                b.Author = reader.GetString(reader.GetOrdinal("Author"));
                b.Edition = reader.GetString(reader.GetOrdinal("Edition"));

            }
                string output = String.Format("Book Id : {0}" +
                    "\nBook Name : {1}" +
                    "\nBook Author : {2}" +
                    "\nBook Edition : {3}",b.Id,b.Name,b.Author,b.Edition);
            conn.Close();
            rtbDashboard.Text = output;
        }
        public Dashboard(string output, string query)
        {
            InitializeComponent();
            var conn = Database.ConnectDB();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Close();
            rtbDashboard.Text = output;
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
