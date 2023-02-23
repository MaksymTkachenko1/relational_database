using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace store
{
    public partial class MainForm : Form
    {
        private SqlConnection connection = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=store;Integrated Security=True");
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM products", connection); 
            DataSet dataBase = new DataSet();
            dataAdapter.Fill(dataBase);
            dataGridView1.DataSource = dataBase.Tables[0];
            this.sellersTableAdapter.Fill(this.storeDataSet1.sellers);
            this.ordersTableAdapter.Fill(this.storeDataSet1.orders);
            this.orderdetailsTableAdapter.Fill(this.storeDataSet1.orderdetails);
            this.buyersTableAdapter.Fill(this.storeDataSet1.buyers);
            this.productsTableAdapter.Fill(this.storeDataSet1.products);
            dataGridView1.AutoGenerateColumns = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            buyersTableAdapter.Update(storeDataSet1);
            orderdetailsTableAdapter.Update(storeDataSet1);
            ordersTableAdapter.Update(storeDataSet1);
            productsTableAdapter.Update(storeDataSet1);
            sellersTableAdapter.Update(storeDataSet1);
        }

        private void buyersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = buyersBindingSource;
            dataGridView1.DataSource = buyersBindingSource;
            label1.Text = "Покупці";
            label2.Hide();
            textBox1.Hide();
            label3.Hide();
            comboBox1.Hide();
            label4.Hide();
            comboBox2.Hide();

        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = orderdetailsBindingSource;
            dataGridView1.DataSource = orderdetailsBindingSource;
            label1.Text = "Деталі замовлення";
            label2.Hide();
            textBox1.Hide();
            label3.Hide();
            comboBox1.Hide();
            label4.Hide();
            comboBox2.Hide();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = ordersBindingSource;
            dataGridView1.DataSource = ordersBindingSource;
            label1.Text = "Замовлення";
            label2.Hide();
            textBox1.Hide();
            label3.Hide();
            comboBox1.Hide();
            label4.Hide();
            comboBox2.Hide();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            bindingNavigator1.BindingSource = productsBindingSource;
            dataGridView1.DataSource = productsBindingSource;
            label1.Text = "Товари";
            label2.Show();
            textBox1.Show();
            label3.Show();
            comboBox1.Show();
            label4.Show();
            comboBox2.Show();
        }

        private void sellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = sellersBindingSource;
            dataGridView1.DataSource = sellersBindingSource;
            label2.Hide();
            textBox1.Hide();
            label3.Hide();
            comboBox1.Hide();
            label4.Hide();
            comboBox2.Hide();
        }

        private void queryEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var queryEdit = new QueryEdit();
            queryEdit.Show();
        }

        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stats = new Stats();
            stats.Show();
        }

        const string ConnectionString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=store;Integrated Security=True";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"name LIKE '%{textBox1.Text}%'";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "rating='5'";
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "rating='4'";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "rating='3'";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    
                    SqlDataAdapter dataAdapter1 = new SqlDataAdapter("SELECT * FROM products ORDER BY name;", connection);
                    DataTable dataTable1 = new DataTable();
                    dataAdapter1.Fill(dataTable1);
                    dataGridView1.DataSource = dataTable1;
                    break;
                case 1:
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT * FROM products ORDER BY price;", connection);
                    DataTable dataTable2 = new DataTable();
                    dataAdapter2.Fill(dataTable2);
                    dataGridView1.DataSource = dataTable2;
                    break;
                case 2:
                    SqlDataAdapter dataAdapter3 = new SqlDataAdapter("SELECT * FROM products ORDER BY brand_name;", connection);
                    DataTable dataTable3 = new DataTable();
                    dataAdapter3.Fill(dataTable3);
                    dataGridView1.DataSource = dataTable3;
                    break;
                case 3:
                    SqlDataAdapter dataAdapter4 = new SqlDataAdapter("SELECT * FROM products ORDER BY category_name;", connection);
                    DataTable dataTable4 = new DataTable();
                    dataAdapter4.Fill(dataTable4);
                    dataGridView1.DataSource = dataTable4;
                    break;
                case 4:
                    SqlDataAdapter dataAdapter5 = new SqlDataAdapter("SELECT * FROM products ORDER BY production_year;", connection);
                    DataTable dataTable5 = new DataTable();
                    dataAdapter5.Fill(dataTable5);
                    dataGridView1.DataSource = dataTable5;
                    break;
                case 5:
                    SqlDataAdapter dataAdapter6 = new SqlDataAdapter("SELECT * FROM products ORDER BY weight;", connection);
                    DataTable dataTable6 = new DataTable();
                    dataAdapter6.Fill(dataTable6);
                    dataGridView1.DataSource = dataTable6;
                    break;
                case 6:
                    SqlDataAdapter dataAdapter7 = new SqlDataAdapter("SELECT * FROM products ORDER BY rating;", connection);
                    DataTable dataTable7 = new DataTable();
                    dataAdapter7.Fill(dataTable7);
                    dataGridView1.DataSource = dataTable7;
                    break;
                case 7:
                    SqlDataAdapter dataAdapter8 = new SqlDataAdapter("SELECT * FROM products ORDER BY quantity;", connection);
                    DataTable dataTable8 = new DataTable();
                    dataAdapter8.Fill(dataTable8);
                    dataGridView1.DataSource = dataTable8;
                    break;
            }
        }
       
        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report1 = new Report1WithAutomatization();
            report1.Show();
        }

        private void report2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report2 = new Report2();
            report2.Show();
        }
    }
}
