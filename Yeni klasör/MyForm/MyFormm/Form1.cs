using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFormm.localhost;
using MyLibrary;
using System.Data.SqlClient;

namespace MyFormm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Web service fonksiyonlarının çalışması için web service i açmayı unutma
            MyWebService myObj = new MyWebService();
            string myStr = myObj.HarikaToplayici(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString();

            MessageBox.Show(myStr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 myObj = new Class1();
            MessageBox.Show(myObj.HarikaCikarici(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] myStr = File.ReadAllLines(@"C:\\Users\\tnrsn\\Desktop\\py\\test.nur");
            foreach (var item in myStr)
            {
                MessageBox.Show(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDataBaseDataSet.MyTable' table. You can move, or remove it, as needed.
            this.myTableTableAdapter.Fill(this.myDataBaseDataSet.MyTable);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS;Initial Catalog=MyDataBase;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into MyTable (name, surname, age) values (@p1, @p2, @p3)", conn);
            cmd.Parameters.AddWithValue("@p1", textBox3.Text);
            cmd.Parameters.AddWithValue("@p2", textBox4.Text);
            cmd.Parameters.AddWithValue("@p3", Convert.ToInt32(textBox5.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            this.myTableTableAdapter.Fill(this.myDataBaseDataSet.MyTable);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyWebService myObj = new MyWebService();
            myObj.MuhtesemSil(Convert.ToInt32(textBox6.Text));
            this.myTableTableAdapter.Fill(this.myDataBaseDataSet.MyTable);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class1 obj = new Class1();
            dataGridView1.DataSource = obj.FevkaladeArayici(Convert.ToInt32(textBox6.Text));
        }
    }
}
