using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace store
{
    public partial class Report1WithAutomatization : Form
    {
        private readonly string TemplateFileName = @"C:\Users\Adfmin\Desktop\вторая курсовая\шаблон_клієнт_року.docx";
        public Report1WithAutomatization()
        {
            InitializeComponent();
            fillComboBox();
        }
        private void fillComboBox() 
        {
            string constring = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=store;Integrated Security=True";
            /*задача автоматизації - підбір особливого клієнта для акційного розіграшу клієнт року
            string query1 = "SELECT TOP 1 order_id, MAX(sum) FROM orderdetails GROUP BY order_id ORDER BY MAX(sum) DESC;";//order_id=19;
            string query2 = "SELECT buyer_id FROM orders WHERE order_id = 19";//buyer_id=19*/
            string query = $"SELECT * FROM buyers WHERE buyer_id = 19";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader myReader;
            try
            {
                conn.Open();
                myReader = command.ExecuteReader();
                
                while (myReader.Read()) 
                {
                    string stringName1 = myReader["first_name"].ToString();
                    comboBox1.Items.Add(stringName1);
                    string stringName2 = myReader["last_name"].ToString();
                    comboBox2.Items.Add(stringName2);
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(@"Error: " + excep.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var firstName = comboBox1.Text;
            var lastName = comboBox2.Text;

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordTemplate("{firstName}", firstName, wordDocument);
                ReplaceWordTemplate("{lastName}", lastName, wordDocument);
                wordDocument.SaveAs(@"C:\Users\Adfmin\Desktop\вторая курсовая\клієнт_року.docx");
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
