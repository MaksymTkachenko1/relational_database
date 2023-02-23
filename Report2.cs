using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace store
{
    public partial class Report2 : Form
    {
        private readonly string TemplateFileName = @"C:\Users\Adfmin\Desktop\вторая курсовая\шаблон_товарний_чек.docx";
        public Report2()
        {
            InitializeComponent();
            fillComboBox();
        }
        private void fillComboBox()
        {
            string constring = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=store;Integrated Security=True";
            string query = @"SELECT * FROM products";
            SqlConnection connection = new SqlConnection(constring);
            SqlCommand command1 = new SqlCommand(query, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = command1.ExecuteReader();

                while (myReader.Read())
                {
                    
                    string stringName1 = myReader["name"].ToString();
                    comboBox1.Items.Add(stringName1);
                    string stringName2 = myReader["price"].ToString();
                    comboBox3.Items.Add(stringName2);
                    string stringName3 = myReader["name"].ToString();
                    comboBox4.Items.Add(stringName3);
                    string stringName4 = myReader["price"].ToString();
                    comboBox6.Items.Add(stringName4);
                    string stringName5 = myReader["name"].ToString();
                    comboBox7.Items.Add(stringName5);
                    string stringName6 = myReader["price"].ToString();
                    comboBox8.Items.Add(stringName6);
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(@"Error: " + excep.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value.ToShortDateString();
            var name1 = comboBox1.Text;
            var quantity1 = textBox1.Text;
            var price1 = comboBox3.Text;

            var name2 = comboBox4.Text;
            var quantity2 = textBox2.Text;
            var price2 = comboBox6.Text;

            var name3 = comboBox7.Text;
            var quantity3 = textBox3.Text;
            var price3 = comboBox8.Text;
            var numericSum = Convert.ToInt32(price1) * Convert.ToInt32(quantity1) + Convert.ToInt32(price2) * Convert.ToInt32(quantity2) 
                + Convert.ToInt32(price3) * Convert.ToInt32(quantity3);
            var stringSum = numericSum.ToString();

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordTemplate("{date}", date, wordDocument);
                ReplaceWordTemplate("{name1}", name1, wordDocument);
                ReplaceWordTemplate("{quantity1}", quantity1, wordDocument);
                ReplaceWordTemplate("{price1}", price1, wordDocument);
                ReplaceWordTemplate("{name2}", name2, wordDocument);
                ReplaceWordTemplate("{quantity2}", quantity2, wordDocument);
                ReplaceWordTemplate("{price2}", price2, wordDocument);
                ReplaceWordTemplate("{name3}", name3, wordDocument);
                ReplaceWordTemplate("{quantity3}", quantity3, wordDocument);
                ReplaceWordTemplate("{price3}", price3, wordDocument);
                ReplaceWordTemplate("{sum}", stringSum, wordDocument);

                wordDocument.SaveAs(@"C:\Users\Adfmin\Desktop\вторая курсовая\товарний_чек.docx");
                wordApp.Visible = true;
            }
            catch (Exception excep)
            {
                MessageBox.Show(@"Error: " + excep.Message);
            }
        }
        private void ReplaceWordTemplate(string templateToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: templateToReplace, ReplaceWith: text);
        }
    }
}
