using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyLibrary
{
    public class Class1
    {
        public int HarikaCikarici(int value1, int value2)
        {
            return value1 - value2;
        }

        //Alttaki fonksiyonu sakın web service in içine yazmayın! Aman
        public DataTable FevkaladeArayici(int ID)
        {
            //DataTable ı kullanmak için System.Data; yı include edin
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS;Initial Catalog=MyDataBase;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from MyTable where ID = @p1", conn);
            cmd.Parameters.AddWithValue("@p1", ID);

            DataTable table = new DataTable();

            table.Load(cmd.ExecuteReader());
            conn.Close();
            return table;
        }
    }
}
