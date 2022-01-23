using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentAutomation
{
   
    internal class SqlHelper
    {
        public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }

        public SqlHelper()
        {
            ConnectionString = @"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=ApartmentAutomation;Persist Security Info=True;User ID=udemy;Password=1";
            Connection = new SqlConnection(ConnectionString);
        }

        public void ExecuteProcedure(string ProgName,params SqlParameter[] ps)
        {
            SqlCommand command= new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = ProgName;//proceedure adı verilir
            command.Parameters.AddRange(ps);//Dizi seklide gelen parametreleri Procedure gonderilir.
            command.Connection = Connection;
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();

        }

        public DataTable GetTable(string query)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter(query,ConnectionString);
            DataTable dt=new DataTable();
            adapter.Fill(dt);
            return dt;
        }

    }
}
