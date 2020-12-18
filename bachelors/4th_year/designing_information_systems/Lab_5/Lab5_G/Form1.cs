using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab5_G
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                Refresh_();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void Refresh_()
        {
            SqlCommand command = new SqlCommand("Select * from [Position]", conn);
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(table);
            }
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                string query = String.Format("insert into Position(Name_position, Salary) VALUES(@Name_position, @Salary);");

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlParameter P1 = new SqlParameter();

                    P1.ParameterName= "@Name_position";
                    P1.Value = textBox2.Text;
                    //command.Parameters.AddWithValue("@Name_position", textBox2.Text);
                    command.Parameters.Add(P1);

                    command.Parameters.AddWithValue("@Salary", textBox3.Text);
                    

                    int resoult = command.ExecuteNonQuery();
                }

                Refresh_();
            }
            else
            {
                MessageBox.Show("Enter Name_position and Salary", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string query = String.Format("update Position SET Name_position = '{0}', Salary = '{1}' where id = '{2}'", textBox2.Text, textBox3.Text, textBox1.Text);
                

                //string query = String.Format("update Position SET Name_position = @position, Salary = @Salary where id = @id1");
                //using (SqlCommand command = new SqlCommand(query, conn))
                //{
                //    command.Parameters.AddWithValue("@position", textBox2.Text);
                //    command.Parameters.AddWithValue("@Salary", textBox3.Text);
                //    command.Parameters.Add("@id1", SqlDbType.Int).Value = Convert.ToInt32( textBox1.Text);
                //}

                int resoult = new SqlCommand(query, conn).ExecuteNonQuery();
                Refresh_();
            }
            else
            {
                MessageBox.Show("Enter Name_position and Salary", "Error", MessageBoxButtons.OK);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string query = String.Format("DELETE FROM dbo.Position where Position.Id = {0}", textBox1.Text);
                int resoult = new SqlCommand(query, conn).ExecuteNonQuery();
                Refresh_();
            }
            else
            {
                MessageBox.Show("Enter Name_position and Salary", "Error", MessageBoxButtons.OK);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"IT-PROGER\SQLEXPRESS";
            string database = "Laba4Database2";

            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security = True";

            return new SqlConnection(connString);
        }
    }
}
//SqlParameter P = new SqlParameter("@Name_position", textBox2.Text);
//command.Parameters.Add(P);
