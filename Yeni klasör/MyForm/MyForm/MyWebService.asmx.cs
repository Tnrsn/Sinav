using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace MyForm
{
    /// <summary>
    /// Summary description for MyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {
        //!!!!!!!!!!!!!!Eğer webservice i değiştirirsen referanslarını güncellemeyi unutma!!!!!!!!!!!!!!!!!!!!!!!!!

        [WebMethod]
        public int HarikaToplayici(int value1, int value2)
        {
            return value1 + value2;
        }
        [WebMethod]
        public void MuhtesemSil(int ID)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS;Initial Catalog=MyDataBase;Integrated Security=True");
            conn.Open();

            //******************************Burada sql kodu yaz
            SqlCommand cmd = new SqlCommand("Delete from MyTable where ID = @p1", conn);
            //Bu satır @p1 değerini yazınca hangi değerden bahsettiğimizi tanımlıyor yani burada ID den bahsediyoruz
            cmd.Parameters.AddWithValue("@p1", ID);
            //Bu alttaki satır sql kodunu çalıştırıyor
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
