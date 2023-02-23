using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace store
{
    public partial class Stats : Form
    {
        const string ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=store;Integrated Security=True";
        public Stats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = "SELECT TOP 10 name, rating FROM products ORDER BY rating DESC;";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(query, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = "SELECT TOP 10 name, production_year FROM products ORDER BY production_year DESC;";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(query, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = "SELECT TOP 10 name, price FROM products ORDER BY price DESC;";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(query, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = "SELECT TOP 10 name, price FROM products ORDER BY price;";
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(query, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
    }
}
