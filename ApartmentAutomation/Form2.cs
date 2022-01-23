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

/*
 T-SQL

use
ApartmentAutomation
go

create table Revenues(
Id int NOT NULL IDENTITY(1, 1),
FlatNu int,
Amaount int,
CreatedDate DateTime,
Primary Key(Id)
);


create table Expenses(
Id int NOT NULL IDENTITY(1, 1),
ExpenseName nvarchar(60),
Amount int,
CreatedDate DateTime,
Primary Key(Id)
)
 
 */


namespace ApartmentAutomation
{
     public partial class Form2 : Form
    {
        SqlHelper sqlHelper = new SqlHelper();
        SqlConnection connection = new SqlConnection(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=ApartmentAutomation;User ID=udemy;Password=1");
        public Form2()
        {
            InitializeComponent();
            //Camel syntax
            SqlDataAdapter adapter =new SqlDataAdapter("Select FlatNu,Amaount,CreatedDate from Revenues;", connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
           DataTable dataTable=new DataTable();
           adapter.Fill(dataTable);

            /*for (int i =0; i < dataTable.Rows.Count; i++)
            {
                listBox1.DataSource = dataTable.Rows[i]["FlatNu"].ToString();
                listBox2.DataSource = dataTable.Rows[i]["Amaount"].ToString();
                listBox3.DataSource =dataTable.Rows[i]["CreatedDate"].ToString();
            }*/
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int FlatNu =Convert.ToInt32(comboBox1.Text);
            int Amount =Convert.ToInt32(textBox1.Text);
            DateTime date = dateTimePicker1.Value;
            SqlParameter p1=new SqlParameter("FlatNu", FlatNu);
            SqlParameter p2 = new SqlParameter("Amaount", Amount);
            SqlParameter p3 = new SqlParameter("CreatedDate", date);
            sqlHelper.ExecuteProcedure("sp_Get_Payment", p1, p2, p3);

            Get_Load();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = sqlHelper.GetTable("Select*from Revenues");

            foreach (DataRow item in dt.Rows)//DataRow, DataTable icindeki herbir satir
            {
                listBox1.Items.Add(item["FlatNu"]).ToString();
                listBox2.Items.Add(item["Amaount"]).ToString();
                listBox3.Items.Add(item["CreatedDate"]).ToString();
            }
        }
        public void Get_Load()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            DataTable dt = sqlHelper.GetTable("Select*from Revenues");

            foreach (DataRow item in dt.Rows)//DataRow, DataTable icindeki herbir satir
            {
                listBox1.Items.Add(item["FlatNu"]).ToString();
                listBox2.Items.Add(item["Amaount"]).ToString();
                listBox3.Items.Add(item["CreatedDate"]).ToString();
            }
        }
    }
}
