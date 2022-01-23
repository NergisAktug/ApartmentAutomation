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

namespace ApartmentAutomation
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlHelper sqlHelper=new SqlHelper();
        private void button1_Click(object sender, EventArgs e)
        {
          
            int Amount =Convert.ToInt32(textBox1.Text);
            DateTime date = dateTimePicker1.Value;
            string My_expenses = "";

            foreach (Control item in groupBox1.Controls)
            {
                if (item is CheckBox && ((CheckBox)item).Checked)
                {
                    My_expenses +=","+item.Text;
                }
            }
            My_expenses = My_expenses.Remove(0, 1);
                
            SqlParameter p1=new SqlParameter("ExpenseName",My_expenses);
            SqlParameter p2=new SqlParameter("Amount",Amount);
            SqlParameter p3=new SqlParameter("CreatedDate",date);

            sqlHelper.ExecuteProcedure("sp_Expenses", p1, p2, p3);

            Get_Data();

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt = sqlHelper.GetTable("Select*from Expenses");
            foreach (DataRow item in dt.Rows)
            {
                listBox1.Items.Add(item["ExpenseName"]).ToString();
                listBox2.Items.Add(item["Amount"]).ToString();
                listBox3.Items.Add(item["CreatedDate"]).ToString();
            }
        }

        public void Get_Data()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            DataTable dt = sqlHelper.GetTable("Select*from Expenses");
            foreach (DataRow item in dt.Rows)
            {
                listBox1.Items.Add(item["ExpenseName"]).ToString();
                listBox2.Items.Add(item["Amount"]).ToString();
                listBox3.Items.Add(item["CreatedDate"]).ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
